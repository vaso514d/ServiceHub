using Microsoft.AspNetCore.Components;
using ServiceHubAPI.Entities;
using System.Text;

namespace ServiceHubAPI.Clients
{
    public class DroolesClient: ComponentBase
    {
        private readonly IHttpClientFactory httpClientFactory;
        public DroolesClient(IHttpClientFactory httpClientFactory) 
        { 
            this.httpClientFactory = httpClientFactory;
        }

        public async Task<string?> GeServerContainers()
        {
            using (var httpClient = httpClientFactory.CreateClient(ExternalServices.DroolsServiceName))
            {
                var response = await httpClient.GetAsync($"server/containers");
                var check = response.EnsureSuccessStatusCode();

                var resJson = response.Content.ReadAsStringAsync();
                return resJson.Result;
            }
        }

        public async Task<string?> GeServiceContainersDmn(string containerId)
        {
            using (var httpClient = httpClientFactory.CreateClient(ExternalServices.DroolsServiceName))
            {
                var response = await httpClient.GetAsync($"server/containers/{containerId}/dmn");
                var check = response.EnsureSuccessStatusCode();

                var resJson = response.Content.ReadAsStringAsync();
                return resJson.Result;
            }
        }

        public async Task<string?> PostModelToGetDicision(string containerId, string modelId, string modelJson)
        {
            using (var httpClient = httpClientFactory.CreateClient(ExternalServices.DroolsServiceName))
            {
                var context = new StringContent(modelJson, Encoding.UTF8, "application/json");

                var response = await httpClient.PostAsync($"server/containers/{containerId}/dmn/models/{modelId}", context);
                var check = response.EnsureSuccessStatusCode();

                var resJson = response.Content.ReadAsStringAsync();
                return resJson.Result;
            }
        }
    }
}
