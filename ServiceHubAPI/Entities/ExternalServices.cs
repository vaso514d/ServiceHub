using System.ComponentModel;

namespace ServiceHubAPI.Entities
{
    public static class ExternalServices
    {
        public const string DroolsServiceName = "DroolsScoringService";

        //public const string ModelID = "Linx_1.0.0-SNAPSHOT";
        //public const string CreditHistoryModelID = "RGC - Credit History";
        //public const string Financials = "RGC - Financials";
        //public const string BusinessOperations = "RGC - Business Operations";
        //public const string AdjustmentFactors = "RGC - Adjustment Factors - LTV";
        //public const string FinalScore = "RGC - Final Score";
    }

    public enum ServiceEnum
    {
        [Description("DroolsScoringService")]
        Drools = 1
    }

    public static class MyEnumExtensions
    {
        public static string Description(this ServiceEnum val)
        {
            DescriptionAttribute[] attributes = (DescriptionAttribute[])val
                .GetType()
                .GetField(val.ToString())
                .GetCustomAttributes(typeof(DescriptionAttribute), false);

            return attributes.Any() ? attributes[0].Description : string.Empty;
        }
    }
}
