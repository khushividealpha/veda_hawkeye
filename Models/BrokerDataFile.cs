namespace VedaHawkeyeApi.Models
{
    public class BrokerDataFile
    {
        public DateOnly Report_Date { get; set; }
        public string? Client_No { get; set; }
        public string? Com_Type { get; set; }  
        public string? Exch_cd { get; set; }
        public string? Com_cd { get; set; }    
        public decimal? Strike_Price { get; set; }
        public DateOnly Trade_Date { get; set; }
        public string? Buy_Sell { get; set; }  
        public int? Traded_Qty { get; set; }
        public decimal? Traded_Price { get; set; }
        public string? Settle_Curr_Cd { get; set; }    
        public string? Order_Id { get; set; }

    }
}
