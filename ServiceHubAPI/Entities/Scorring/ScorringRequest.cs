using System.Text.Json.Serialization;

namespace ServiceHubAPI.Entities.Scorring
{
    #region RGC - Credit History
    /*
     * Linx_1.0.0-SNAPSHOT
     * RGC - Credit History
     */
    public class CreditHistoryRequest
    {
        public Business Business { get; set; }
        public Shareholder Shareholder { get; set; }
    }

    public class Business
    {
        [JsonPropertyName("CR Grade")]
        public CrGrade CrGrade { get; set; }
    }

    public class Shareholder
    {
        [JsonPropertyName("CR Grade")]
        public CrGrade CrGrade { get; set; }
    }

    /*
     * Newtonsoft
     * [JsonConverter(typeof(StringEnumConverter))]
     * */
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum CrGrade
    { 
        A, 
        B, 
        C1, 
        C2, 
        C3, 
        D1, 
        D2, 
        D3, 
        E1, 
        E2, 
        E3, 
        [JsonPropertyName("No Score")]
        NoScore
    }

    public class CreditHistoryResponse
    {
        [JsonPropertyName("RGC - Credit History Score")]
        public decimal? RGCCreditHistoryScore { get; set; }
        
        [JsonPropertyName("Business Score")]
        public decimal? BusinessScore { get; set; }
        public Business Business { get; set; }
        
        [JsonPropertyName("Shareholder Score")]
        public decimal? ShareholderScore { get; set; }
        public Shareholder Shareholder { get; set; }
    }
    #endregion

    #region RGC - Financials
    /*
     * Linx_1.0.0-SNAPSHOT
     * RGC - Financials
     */
    public class FinancialsCalculatorRequest
    {
        //Debt Service Coverage Ratio
        public decimal DSCR { get; set; }
        //Average bank account balance to new loan monthly payment
        public decimal BLR { get; set; }
        [JsonPropertyName("Gross Profit Margin")]
        public GrossProfitMargin GrossProfitMargin { get; set; }
        //Last 3 months (if seasonal business last 12 months) profit or loss
        [JsonPropertyName("Profit or Loss")]
        public ProfitOrLoss ProfitOrLoss { get; set; }
        [JsonPropertyName("Sales Growth Rate")]
        public decimal SalesGrowthRate { get; set; }
        //Total Loans to EBITDA
        public decimal EBITDA { get; set; }
    }

    public class GrossProfitMargin
    {
        [JsonPropertyName("GrossProfitMargin")]
        public decimal GrossProfitMarginValue { get; set; }
        public BusinessSector BusinessSector { get; set; }
    }

    /*
     * Newtonsoft
     * [JsonConverter(typeof(StringEnumConverter))]
     * */
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum BusinessSector
    {
        Trade, 
        Service, 
        Manufacturing
    }

    /*
     * Newtonsoft
     * [JsonConverter(typeof(StringEnumConverter))]
     * */
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum ProfitOrLoss
    {
        Yes,
        No
    }
    
    public class FinancialsCalculatorResponse
    {
        //Debt Service Coverage Ratio
        public decimal DSCR { get; set; }
        [JsonPropertyName("DSCR Score")]
        public decimal DSCRScore { get; set; }
        
        //Average bank account balance to new loan monthly payment
        public decimal BLR { get; set; }
        [JsonPropertyName("BLR Score")]
        public decimal BLRScore { get; set; }
        
        [JsonPropertyName("Gross Profit Margin")]
        public GrossProfitMargin GrossProfitMargin { get; set; }
        [JsonPropertyName("GrossProfitMargin Score")]
        public decimal GrossProfitMarginScore { get; set; }
        
        //Last 3 months (if seasonal business last 12 months) profit or loss
        [JsonPropertyName("Profit or Loss")]
        public ProfitOrLoss ProfitOrLoss { get; set; }
        [JsonPropertyName("Profit or Loss Score")]
        public decimal ProfitOrLossScore { get; set; }
        
        [JsonPropertyName("Sales Growth Rate")]
        public decimal SalesGrowthRate { get; set; }
        [JsonPropertyName("Sales Growth Rate Score")]
        public decimal SalesGrowthRateScore { get; set; }
        
        //Total Loans to EBITDA
        public decimal EBITDA { get; set; }
        [JsonPropertyName("EBITDA Score")]
        public decimal EBITDAScore { get; set; }
        
        [JsonPropertyName("RGC - Financial Score")]
        public decimal RGCFinancialScore { get; set; }
    }
    #endregion

    #region RGC - Business Operations
    /*
     * Linx_1.0.0-SNAPSHOT
     * RGC - Business Operations
     */
    public class BusinessOperationsRequest
    {
        [JsonPropertyName("Company Operations Durations")]
        public decimal CompanyOperationsDurations { get; set; }

        [JsonPropertyName("Dependance on Large Buyers")]
        public decimal DependanceOnLargeBuyers { get; set; }

        [JsonPropertyName("Reported to Actual Revenue")]
        public decimal ReportedToActualRevenue { get; set; }

        [JsonPropertyName("Full Time Employees")]
        public decimal FullTimeEmployees { get; set; }

        public decimal Shareholders { get; set; }

        [JsonPropertyName("Loan Purpose")]
        public decimal LoanPurpose { get; set; }
    }
    
    public class BusinessOperationsResponse
    {
        [JsonPropertyName("Company Operations Durations")]
        public decimal CompanyOperationsDurations { get; set; }
        [JsonPropertyName("Company Operations Durations Score")]
        public decimal CompanyOperationsDurationsScore { get; set; }

        [JsonPropertyName("Dependance on Large Buyers")]
        public decimal DependanceOnLargeBuyers { get; set; }
        [JsonPropertyName("Dependance on Large Buyers Score")]
        public decimal DependanceOnLargeBuyersScore { get; set; }

        [JsonPropertyName("Reported to Actual Revenue")]
        public decimal ReportedToActualRevenue { get; set; }
        [JsonPropertyName("Reported to Actual Revenue Score")]
        public decimal ReportedToActualRevenueScore { get; set; }

        [JsonPropertyName("Full Time Employees")]
        public decimal FullTimeEmployees { get; set; }
        [JsonPropertyName("Full Time Employees Score")]
        public decimal FullTimeEmployeesScore { get; set; }

        public decimal Shareholders { get; set; }
        [JsonPropertyName("Shareholders Score")]
        public decimal? ShareholdersScore { get; set; }

        [JsonPropertyName("Loan Purpose")]
        public decimal LoanPurpose { get; set; }
        [JsonPropertyName("Loan Purpose Score")]
        public decimal LoanPurposeScore { get; set; }
        
        [JsonPropertyName("RGC - Business Operations Score")]
        public decimal RGCBusinessOperationsScore { get; set; }
    }
    #endregion

    #region RGC - Adjustment Factors - LTV
    /*
     * Linx_1.0.0-SNAPSHOT
     * RGC - Adjustment Factors - LTV
     */
    public class AdjustmentFactorsRequest
    {
        public ExpertJudgement ExpertJudgement { get; set; }

        public YesNo SHRealEstate { get; set; }

        public YesNo TaxDisputes { get; set; }

        public YesNo AnnualSales { get; set; }

        public YesNo BusinessRealEstate { get; set; }

        public decimal LTV { get; set; }
    }

    /*
     * Newtonsoft
     * [JsonConverter(typeof(StringEnumConverter))]
     * */
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum YesNo
    {
        Yes,
        No
    }

    /*
     * Newtonsoft
     * [JsonConverter(typeof(StringEnumConverter))]
     * */
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum ExpertJudgement
    {
        Positive,
        Negative,
        Risky,
        Neutral
    }

    public class AdjustmentFactorsResponse
    {
        public ExpertJudgement ExpertJudgement { get; set; }
        [JsonPropertyName("ExpertJudgement Score")]
        public decimal ExpertJudgementScore { get; set; }

        public YesNo SHRealEstate { get; set; }
        [JsonPropertyName("SHRealEstate Score")]
        public decimal SHRealEstateScore { get; set; }

        public YesNo TaxDisputes { get; set; }
        [JsonPropertyName("TaxDisputes Score")]
        public decimal TaxDisputesScore { get; set; }

        public YesNo AnnualSales { get; set; }
        [JsonPropertyName("AnnualSales Score")]
        public decimal AnnualSalesScore { get; set; }

        public YesNo BusinessRealEstate { get; set; }
        [JsonPropertyName("BusinessRealEstate Score")]
        public decimal BusinessRealEstateScore { get; set; }

        public decimal LTV { get; set; }
        [JsonPropertyName("LTV Score")]
        public decimal LTVScore { get; set; }

        [JsonPropertyName("AdjustmentFactors Final Score")]
        public decimal AdjustmentFactorsFinalScore { get; set; }
    }
    #endregion

    #region RGC - Final Score
    /*
     * Linx_1.0.0-SNAPSHOT
     * RGC - Final Score
     */
    public class ScorringRequest
    {
        public CreditHistoryRequest CreditHistory { get; set; }

        public FinancialsCalculatorRequest FinancialsCalculator { get; set; }

        public BusinessOperationsRequest BusinessOperations { get; set; }

        public AdjustmentFactorsRequest AdjustmentFactors { get; set; }
    }
    
    public class FinalScoreRequest
    {
        [JsonPropertyName("Credit History")]
        public CreditHistoryResponse CreditHistoryResponse { get; set; }

        [JsonPropertyName("Financials Score")]
        public FinancialsCalculatorResponse FinancialsCalculatorResponse { get; set; }

        [JsonPropertyName("Business Operations Score")]
        public BusinessOperationsResponse BusinessOperationsResponse { get; set; }

        [JsonPropertyName("Adjustment Factors Score")]
        public AdjustmentFactorsResponse AdjustmentFactorsResponse { get; set; }
    }
    
    public class FinalScoreResponse
    {
        [JsonPropertyName("Credit History")]
        public CreditHistoryResponse CreditHistoryResponse { get; set; }

        [JsonPropertyName("Financials Score")]
        public FinancialsCalculatorResponse FinancialsCalculatorResponse { get; set; }

        [JsonPropertyName("Business Operations Score")]
        public BusinessOperationsResponse BusinessOperationsResponse { get; set; }

        [JsonPropertyName("Adjustment Factors Score")]
        public AdjustmentFactorsResponse AdjustmentFactorsResponse { get; set; }

        [JsonPropertyName("RGC Grade")]
        public string RGCGrade { get; set; }

        [JsonPropertyName("RGC Final Score")]
        public decimal RGCFinalScore { get; set; }
    }
    #endregion
}
