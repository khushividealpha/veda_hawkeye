using CsvHelper.Configuration.Attributes;

namespace VedaHawkeyeApi.Models
{
    public class BrokerTrades
    {
        [Name("Transaction ID")]
        public string? TransactionID { get; set; }

        [Name("Business Date")]
        public DateOnly? BusinessDate { get; set; }

        [Name("Trade Date")]
        public DateOnly? TradeDate { get; set; }

        [Name("Action")]
        public string? Action { get; set; }

        [Name("Account Id")]
        public string? AccountId { get; set; }

        [Name("Family Group")]
        public string? FamilyGroup { get; set; }

        [Name("Account Name")]
        public string? AccountName { get; set; }

        [Name("Exchange")]
        public string? Exchange { get; set; }

        [Name("Currency")]
        public string? Currency { get; set; }

        [Name("Exchange Code")]
        public string? ExchangeCode { get; set; }

        [Name("Instrument Code")]
        public string? InstrumentCode { get; set; }

        [Name("Instrument Name")]
        public string? InstrumentName { get; set; }

        [Name("Trade Type")]
        public string? TradeType { get; set; }

        [Name("Option Style")]
        public string? OptionStyle { get; set; }

        [Name("Buy/Sell")]
        public string? BuySell { get; set; }

        [Name("Abs Quantity")]
        public int? AbsQuantity { get; set; }

        [Name("Net Quantity")]
        public int? NetQuantity { get; set; }

        [Name("Prompt")]
        public string? Prompt { get; set; }

        [Name("Trade Price")]
        public decimal? TradePrice { get; set; }

        [Name("Strike Price")]
        public decimal? StrikePrice { get; set; }

        [Name("Market Price")]
        public decimal? MarketPrice { get; set; }

        [Name("Premium")]
        public decimal? Premium { get; set; }

        [Name("MtM")]
        public decimal? MtM { get; set; }

        [Name("Trade Value")]
        public decimal? TradeValue { get; set; }

        [Name("Total Charge")]
        public decimal? TotalCharge { get; set; }

        [Name("Commission")]
        public decimal? Commission { get; set; }

        [Name("Exchange Fee")]
        public decimal? ExchangeFee { get; set; }

        [Name("Clearing Fee")]
        public decimal? ClearingFee { get; set; }

        [Name("NFA Fee")]
        public decimal? NfaFee { get; set; }

        [Name("Average Price")]
        public decimal? AveragePrice { get; set; }

        [Name("Average Price Basis")]
        public string? AveragePriceBasis { get; set; }

        [Name("Average Price Premium/Discount")]
        public string? AveragePricePremiumDiscount { get; set; }

        [Name("Delivery Type")]
        public string? DeliveryType { get; set; }

        [Name("Days To Maturity")]
        public int? DaysToMaturity { get; set; }

        [Name("Maturity Date")]
        public string? MaturityDate { get; set; }

        [Name("OTC Indicator")]
        public string? OtcIndicator { get; set; }

        [Name("OTC Type")]
        public string? OtcType { get; set; }

        [Name("Average Price Start Date")]
        public string? AveragePriceStartDate { get; set; }

        [Name("Average Price End Date")]
        public string? AveragePriceEndDate { get; set; }

        [Name("FX Rate")]
        public string? FxRate { get; set; }
    }
}
