namespace VedaHawkeyeApi.Models
{
    public class FillReport
    {
        public string Symbol { get; set; }
        public int Qty { get; set; }
        public decimal FillP { get; set; }
        public int Ord { get; set; }
        public DateOnly Expiration { get; set; }

    }
}
