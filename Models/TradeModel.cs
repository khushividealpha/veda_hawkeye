namespace report_generate.Models
{
    public class TradeModel
    {
        public DateOnly Date { get; set; }
        public int TradeNo { get; set; }

        public string? Code { get; set; }
        public string? Exchange { get; set; }
        public int Long { get; set; }
        public int Short { get; set; }
        public string CP {get;set;}
        public string? Contract { get; set; }
        public string? Currency { get; set; }
        public Decimal Strike { get; set; }
        public Decimal TradePrice { get; set; }
        public Decimal Comms { get; set; }


    }
}
