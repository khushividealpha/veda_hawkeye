namespace report_generate.Models
{
    public class OpenPositions
    {
        public DateOnly Date { get; set; }
     public int TradeNo { get; set; }
     public string? Code { get; set; }
     public int Exchange { get; set; }
     public int Long { get; set; }
     public int Short { get; set; }
     public DateOnly Expiry { get; set; }
     public int CP { get; set; }
     public decimal Strike { get; set; }
     public decimal TradePrice { get; set; }
     public decimal ExchanePrice { get; set; }
     public string? Currency { get; set; }
     public decimal DebitCredit { get; set; }
  
    }
}
