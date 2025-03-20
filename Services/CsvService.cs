using CsvHelper;
using CsvHelper.Configuration;
using System.Globalization;
using VedaHawkeyeApi.Helper;
using VedaHawkeyeApi.Interfaces;
using VedaHawkeyeApi.Models;

namespace VedaHawkeyeApi.Services
{
    public class CsvService : ICsvService
    {
        public async Task<List<BrokerTrades>> ReadCsvAsync(Stream fileStream)
        {
            try
            {
                using var memoryStream = new MemoryStream();
                await fileStream.CopyToAsync(memoryStream);
                memoryStream.Position = 0;
                var trades = new List<BrokerTrades>();


                using (var stream = new StreamReader(memoryStream))
                using (var csv = new CsvReader(stream, new CsvConfiguration(CultureInfo.InvariantCulture)
                {
                    BadDataFound = context => Console.WriteLine($"Bad data found: {context.RawRecord}"),
                    HeaderValidated = null 
                }))
                {
                    csv.Context.RegisterClassMap<BrokerTradesMap>(); 
                    trades = csv.GetRecords<BrokerTrades>().ToList();
                }

                return trades;
            }


            catch (Exception ex)
            {
                throw new Exception("Error reading CSV file", ex);
            }
        }
        public async Task<List<BrokerDataFile>> ReadBrokerDatFileAsync(Stream fileStream, string outputPath)
        {
            try
            {
                using var memoryStream = new MemoryStream();
                await fileStream.CopyToAsync(memoryStream);
                memoryStream.Position = 0;
                var trades = new List<BrokerDataFile>();


                using (var stream = new StreamReader(memoryStream))
                using (var csv = new CsvReader(stream, new CsvConfiguration(CultureInfo.InvariantCulture)
                {
                    BadDataFound = context => Console.WriteLine($"Bad data found: {context.RawRecord}"),
                    HeaderValidated = null
                }))
                {
                    csv.Context.RegisterClassMap<BrokerTradesMap>();
                    trades = csv.GetRecords<BrokerDataFile>().ToList();
                }

                return trades;
            }


            catch (Exception ex)
            {
                throw new Exception("Error reading CSV file", ex);
            }
        }
        public async Task ExportNetPositionAsync(Stream fileStream, string outputPath)
        {
            var trades = await ReadCsvAsync(fileStream);

            var netPositions = trades
                .Where(t => !string.IsNullOrEmpty(t.InstrumentCode))
                .GroupBy(t => new { t.InstrumentCode, t.Exchange, t.MaturityDate, t.TradeType,t.StrikePrice })
                .Select(g => new NetPosition
                {
                    InstrumentCode = g.Key.InstrumentCode,
                    InstrumentDescription = g.FirstOrDefault()?.InstrumentName,
                    Exchange = g.Key.Exchange,
                    MaturityDate = g.Key.MaturityDate,
                    TradeType = g.Key.TradeType,
                    Grouping = $"{g.Key.InstrumentCode}-{g.Key.TradeType}-{g.Key.MaturityDate}-{g.Key.Exchange}-{g.Key.StrikePrice}",
                    StrikePrice = g.Key.StrikePrice,

                    TotalBuy = g.Sum(t => t.BuySell == "Buy" ? t.AbsQuantity ?? 0 : 0),
                    TotalSell = g.Sum(t => t.BuySell == "Sell" ? t.AbsQuantity ?? 0 : 0),
                    NetPos = g.Sum(t => t.NetQuantity ?? 0),

                    BuyAverage = g.Where(t => t.BuySell == "Buy" && t.AbsQuantity.HasValue)
                                  .Sum(t => (t.AbsQuantity ?? 0) * (t.TradePrice ?? 0)) /
                                  (g.Where(t => t.BuySell == "Buy").Sum(t => t.AbsQuantity ?? 0) == 0 ? 1 :
                                   g.Where(t => t.BuySell == "Buy").Sum(t => t.AbsQuantity ?? 0)),

                    SellAverage = g.Where(t => t.BuySell == "Sell" && t.AbsQuantity.HasValue)
                                   .Sum(t => (t.AbsQuantity ?? 0) * (t.TradePrice ?? 0)) /
                                   (g.Where(t => t.BuySell == "Sell").Sum(t => t.AbsQuantity ?? 0) == 0 ? 1 :
                                    g.Where(t => t.BuySell == "Sell").Sum(t => t.AbsQuantity ?? 0))
                })
                .ToList();

            await WriteCsvAsync(outputPath, netPositions);
            Console.WriteLine("Net Position CSV file has been generated at " + outputPath);
        }

        public async Task ExportOpenPositionAsync(Stream fileStream, string outputPath)
        {
            var trades = await ReadCsvAsync(fileStream);

            var openPositions = trades
                .Where(t => !string.IsNullOrEmpty(t.AccountId) && !string.IsNullOrEmpty(t.InstrumentCode))
                .Select(t => new OpenPosition
                {                                                  
                    Strike_Price = t.StrikePrice ?? 0,                        
                    Buy_Sell = t.BuySell,
                    Traded_Qty = t.AbsQuantity ?? 0,
                    Traded_Price = t.TradePrice ?? 0,          
                    ComType = (t.TradeType?.ToLower() == "call" || t.TradeType?.ToLower() == "put") ? "Option" :
                      (t.TradeType?.ToLower() == "future") ? "Future" : "Other"
                })
                .ToList();
            await WriteCsvAsync(outputPath, openPositions);
         
        }

        private async Task WriteCsvAsync<T>(string outputPath, List<T> records)
        {
            using (var writer = new StreamWriter(outputPath))
            using (var csv = new CsvWriter(writer, new CsvConfiguration(CultureInfo.InvariantCulture)))
            {
                await csv.WriteRecordsAsync(records);
            }
        }

        public async Task<List<Dictionary<string, object>>> ProcessFileAsync(Stream fileStream)
        {
            var records = new List<Dictionary<string, object>>();

            try
            {
                using var memoryStream = new MemoryStream();
                await fileStream.CopyToAsync(memoryStream);
                memoryStream.Seek(0, SeekOrigin.Begin);

                using var reader = new StreamReader(memoryStream);
                using var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)
                {
                    BadDataFound = context => Console.WriteLine($"Bad data found: {context.RawRecord}"),
                    HeaderValidated = null,
                    MissingFieldFound = null
                });

                csv.Read();
                csv.ReadHeader();
                var headers = csv.HeaderRecord; // Dynamically get the headers

                while (csv.Read())
                {
                    var record = new Dictionary<string, object>();

                    foreach (var header in headers)
                    {
                        record[header] = csv.GetField(header);
                    }

                    records.Add(record);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading file: {ex.Message}");
                throw;
            }

            return records;
        }
    }
}
