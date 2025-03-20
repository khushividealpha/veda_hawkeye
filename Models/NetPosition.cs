namespace VedaHawkeyeApi.Models
{
    public class NetPosition
    {

  
        public string? Grouping { get; set; }
        public string? InstrumentCode { get; set; }

        public string? InstrumentDescription { get; set; }
        public int TotalBuy { get; set; }
        public int TotalSell { get; set; }
        public int NetPos { get; set; }
        public decimal BuyAverage { get; set; }
        public decimal SellAverage { get; set; } 
        public string? Exchange { get; set; }
        public string? MaturityDate { get; set; }
        public string? TradeType { get; set; }     
        public decimal? StrikePrice { get; set; }
    }
}
