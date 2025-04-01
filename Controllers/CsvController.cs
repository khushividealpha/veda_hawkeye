using Microsoft.AspNetCore.Mvc;
using VedaHawkeyeApi.Interfaces;

namespace VedaHawkeyeApi.Controllers
{
    [Route("api")]
    [ApiController]
    public class CsvController : ControllerBase
    {
        private readonly ICsvService _csvService;
        public CsvController(ICsvService csvService)
        {
            _csvService = csvService;
        }


        [HttpPost("upload/netposition")]
        public async Task<IActionResult> UploadNetPosition( IFormFile file)
        {
            if (file == null || file.Length == 0)
                return BadRequest("No file uploaded.");

            string outputPath = Path.Combine(Directory.GetCurrentDirectory(), $"netposition_{DateTime.UtcNow:yyyyMMddHHmmss}.csv");

            await _csvService.ExportNetPositionAsync(file.OpenReadStream(), outputPath);
            return Ok(new { Message = "Net Position CSV generated successfully.", FilePath = outputPath });
        }

        [HttpPost("upload/openposition")]
        public async Task<IActionResult> UploadOpenPosition( IFormFile file)
        {
            if (file == null || file.Length == 0)
                return BadRequest("No file uploaded.");

            string outputPath = Path.Combine(Directory.GetCurrentDirectory(), $"openposition_{DateTime.UtcNow:yyyyMMddHHmmss}.csv");

            await _csvService.ExportOpenPositionAsync(file.OpenReadStream(), outputPath);
            return Ok(new { Message = "Open Position CSV generated successfully.", FilePath = outputPath });
        }

        [HttpPost("upload")]
        public async Task<IActionResult> UploadFile(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                return BadRequest("No file uploaded.");
            }

            try
            {
                using var stream = file.OpenReadStream();
                var result = await _csvService.ProcessFileAsync(stream);

                return Ok(new { Message = "File processed successfully", Data = result });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "Error processing file", Error = ex.Message });
            }
        }
        [HttpPost("upload/v2")]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> UploadTradeFile( IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                return BadRequest("File is required.");
            }

            var headers = await _csvService.ReadHeadersFromCsvAsync(file.OpenReadStream());
            return Ok(headers);
        }
    }
}
