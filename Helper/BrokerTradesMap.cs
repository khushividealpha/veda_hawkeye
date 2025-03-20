using CsvHelper.Configuration;
using System.Globalization;
using VedaHawkeyeApi.Models;

namespace VedaHawkeyeApi.Helper
{
    public class BrokerTradesMap : ClassMap<BrokerTrades>
    {
        public BrokerTradesMap()
        {

            Map(m => m.TransactionID).Name("Transaction ID");
            Map(m => m.BusinessDate).Name("Business Date");
            Map(m => m.TradeDate).Name("Trade Date");
            Map(m => m.Action).Name("Action");
            Map(m => m.AccountId).Name("Account Id");
            Map(m => m.FamilyGroup).Name("Family Group");
            Map(m => m.AccountName).Name("Account Name");
            Map(m => m.Exchange).Name("Exchange");
            Map(m => m.Currency).Name("Currency");
            Map(m => m.ExchangeCode).Name("Exchange Code");
            Map(m => m.InstrumentCode).Name("Instrument Code");
            Map(m => m.InstrumentName).Name("Instrument Name");
            Map(m => m.TradeType).Name("Trade Type");
            Map(m => m.OptionStyle).Name("Option Style");
            Map(m => m.BuySell).Name("Buy/Sell");
            Map(m => m.AbsQuantity).Name("Abs Quantity");
            Map(m => m.NetQuantity).Name("Net Quantity");
            Map(m => m.Prompt).Name("Prompt");
            Map(m => m.TradePrice).Name("Trade Price");
            Map(m => m.StrikePrice).Name("Strike Price");
            Map(m => m.MarketPrice).Name("Market Price");
            Map(m => m.Premium).Name("Premium");
            Map(m => m.MtM).Name("MtM");
            Map(m => m.TradeValue).Name("Trade Value");
            Map(m => m.TotalCharge).Name("Total Charge");
            Map(m => m.Commission).Name("Commission");
            Map(m => m.ExchangeFee).Name("Exchange Fee");
            Map(m => m.ClearingFee).Name("Clearing Fee");
            Map(m => m.NfaFee).Name("NFA Fee");
            Map(m => m.AveragePrice).Name("Average Price");
            Map(m => m.AveragePriceBasis).Name("Average Price Basis");
            Map(m => m.AveragePricePremiumDiscount).Name("Average Price Premium/Discount");
            Map(m => m.DeliveryType).Name("Delivery Type");
            Map(m => m.DaysToMaturity).Name("Days To Maturity");
            Map(m => m.MaturityDate).Name("Maturity Date");
            Map(m => m.OtcIndicator).Name("OTC Indicator");
            Map(m => m.OtcType).Name("OTC Type");
            Map(m => m.AveragePriceStartDate).Name("Average Price Start Date");
            Map(m => m.AveragePriceEndDate).Name("Average Price End Date");
            Map(m => m.FxRate).Name("FX Rate");
        }
    }
}

