using VedaHawkeyeApi.Models;

namespace VedaHawkeyeApi.Interfaces
{
    public interface ICsvService
    {
        Task<List<BrokerTrades>> ReadCsvAsync(Stream fileStream);
        Task ExportNetPositionAsync(Stream fileStream, string outputPath);
        Task ExportOpenPositionAsync(Stream fileStream, string outputPath);
      //  Task ReadBrokerDatFileAsync(Stream fileStream, string outputPath);
         Task<List<Dictionary<string, object>>> ProcessFileAsync(Stream fileStream);
    }
}