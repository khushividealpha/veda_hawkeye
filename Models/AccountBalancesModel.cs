namespace report_generate.Models
{
    public class AccountBalancesModel
    {
        public int RefenceNumber { get; set; }
        public string? ShortDescription { get; set; }
        public decimal Debit { get; set; }
        public decimal Credit { get; set; }
        public decimal RunningValue { get; set; }
    }
}
