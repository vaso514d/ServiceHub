using Microsoft.AspNetCore.Mvc;
using ServiceHubAPI.Clients;
using ServiceHubAPI.Entities;
using ServiceHubAPI.Entities.Scorring;
using System.Text.Encodings.Web;
using System.Text.Json;

namespace ServiceHubAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DroolesController : ControllerBase
    {
        private DroolesClient client;
        private readonly IConfiguration configuration;
        private JsonSerializerOptions options;

        public DroolesController(IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            this.client = new DroolesClient(httpClientFactory);
            this.configuration = configuration;
            
            options = new JsonSerializerOptions
            {
                Encoder = JavaScriptEncoder.Default,
                PropertyNameCaseInsensitive = true,
                WriteIndented = true
            };
        }

        [Route("GeServerContainers")]
        [HttpGet]
        public IActionResult GeServerContainers()
        {
            var str = client.GeServerContainers().Result;

            return Ok(str);
        }

        [Route("GeServiceContainersDmn")]
        [HttpGet]
        public IActionResult GeServiceContainersDmn(string containerId)
        {
            var str = client.GeServiceContainersDmn(containerId).Result;

            return Ok(str);
        }

        [Route("GetCreditHistoryDicision")]
        [HttpPost]
        public IActionResult GetCreditHistoryDicision(CreditHistoryRequest request)
        {
            var str = client.PostModelToGetDicision(
                configuration.GetValue<string>("Drools:ModelID"),
                configuration.GetValue<string>("Drools:CreditHistoryModelID"), 
                JsonSerializer.Serialize(request, options)
            ).Result;
            var score = JsonSerializer.Deserialize<CreditHistoryResponse>(str);

            return Ok(score);
        }

        [Route("GetFinancialsDicision")]
        [HttpPost]
        public IActionResult GetFinancialsDicision(FinancialsCalculatorRequest request)
        {
            var str = client.PostModelToGetDicision(
                configuration.GetValue<string>("Drools:ModelID"),
                configuration.GetValue<string>("Drools:Financials"), 
                JsonSerializer.Serialize(request, options)
            ).Result;
            var score = JsonSerializer.Deserialize<FinancialsCalculatorResponse>(str);

            return Ok(score);
        }

        [Route("GetBusinessOperationsDicision")]
        [HttpPost]
        public IActionResult GetBusinessOperationsDicision(BusinessOperationsRequest request)
        {
            var str = client.PostModelToGetDicision(
                configuration.GetValue<string>("Drools:ModelID"),
                configuration.GetValue<string>("Drools:BusinessOperations"), 
                JsonSerializer.Serialize(request, options)
            ).Result;
            var score = JsonSerializer.Deserialize<BusinessOperationsResponse>(str);

            return Ok(score);
        }

        [Route("GetAdjustmentFactorsDicision")]
        [HttpPost]
        public IActionResult GetAdjustmentFactorsDicision(AdjustmentFactorsRequest request)
        {
            var str = client.PostModelToGetDicision(
                configuration.GetValue<string>("Drools:ModelID"), 
                configuration.GetValue<string>("Drools:AdjustmentFactors"), 
                JsonSerializer.Serialize(request, options)
            ).Result;
            var score = JsonSerializer.Deserialize<AdjustmentFactorsResponse>(str);

            return Ok(score);
        }

        [Route("GetScorringDicision")]
        [HttpPost]
        public IActionResult GetScorringDicision(ScorringRequest request)
        {
            var str = client.PostModelToGetDicision(
                configuration.GetValue<string>("Drools:ModelID"),
                configuration.GetValue<string>("Drools:CreditHistoryModelID"), 
                JsonSerializer.Serialize(request.CreditHistory, options)
            ).Result;
            var creditHistory = JsonSerializer.Deserialize<CreditHistoryResponse>(str);

            str = client.PostModelToGetDicision(
                configuration.GetValue<string>("Drools:ModelID"), 
                configuration.GetValue<string>("Drools:Financials"), 
                JsonSerializer.Serialize(request.FinancialsCalculator, options)
            ).Result;
            var financials = JsonSerializer.Deserialize<FinancialsCalculatorResponse>(str);

            str = client.PostModelToGetDicision(
                configuration.GetValue<string>("Drools:ModelID"), 
                configuration.GetValue<string>("Drools:BusinessOperations"), 
                JsonSerializer.Serialize(request.BusinessOperations, options)
            ).Result;
            var businessOperations = JsonSerializer.Deserialize<BusinessOperationsResponse>(str);

            str = client.PostModelToGetDicision(
                configuration.GetValue<string>("Drools:ModelID"), 
                configuration.GetValue<string>("Drools:AdjustmentFactors"), 
                JsonSerializer.Serialize(request.AdjustmentFactors, options)
            ).Result;
            var adjustmentFactors = JsonSerializer.Deserialize<AdjustmentFactorsResponse>(str);

            var finalRequest = new FinalScoreRequest
            {
                CreditHistoryResponse = creditHistory,
                FinancialsCalculatorResponse = financials,
                BusinessOperationsResponse = businessOperations,
                AdjustmentFactorsResponse = adjustmentFactors
            };

            str = client.PostModelToGetDicision(
                configuration.GetValue<string>("Drools:ModelID"), 
                configuration.GetValue<string>("Drools:FinalScore"), 
                JsonSerializer.Serialize(finalRequest, options)
            ).Result;
            var finalScore = JsonSerializer.Deserialize<FinalScoreResponse>(str);

            return Ok(finalScore);
        }
    }
}
