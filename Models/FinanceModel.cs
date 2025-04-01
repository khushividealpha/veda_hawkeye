namespace report_generate.Models
{
    public class FinanceModel
    {
        public string CcyCode { get; set; }
        public decimal CcyRate { get; set; }
        public decimal OpeningBalance { get; set; }
        public decimal Payments { get; set; }
        public decimal BrokerageAndfees { get; set; }
        public decimal Vat { get; set; }
        public decimal Premium { get; set; }
        public decimal ProfitLoss { get; set; }
        public decimal EndlingBalance { get; set; }
        public decimal ForwardLineUnrealised { get; set; }
        public decimal OpenTradeEquity { get; set; }
        public decimal DailyOptionValue { get; set; }
        public decimal AccountValAtMKT { get; set; }
        public decimal InitialMargin { get; set; }
        public decimal TotalAvailableMargin { get; set; }


    }
}
