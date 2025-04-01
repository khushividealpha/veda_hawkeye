using Microsoft.AspNetCore.Mvc;
using report_generate.Models;
using report_generate.Services;
using System.Text;

namespace report_generate.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PdfController : ControllerBase
    {
        private readonly IPdfService _pdfService;
        private readonly IWebHostEnvironment _env;
        public PdfController(IPdfService pdfService, IWebHostEnvironment env)
        {
            _pdfService = pdfService;
            _env = env;
        }


        [HttpGet("generate-finance-report")]
        public IActionResult GenerateFinancePdf()
        {
            List<FinanceModel> financeData = new List<FinanceModel>
    {
        new FinanceModel { CcyCode = "USD", CcyRate = 1.0m, OpeningBalance = 10000, Payments = 500, BrokerageAndfees = 50, Vat = 5, Premium = 20, ProfitLoss = 200, EndlingBalance = 10665, ForwardLineUnrealised = 50, OpenTradeEquity = 300, DailyOptionValue = 15, AccountValAtMKT = 11000, InitialMargin = 2000, TotalAvailableMargin = 9000 },
        new FinanceModel { CcyCode = "EUR", CcyRate = 0.9m, OpeningBalance = 8000, Payments = 300, BrokerageAndfees = 30, Vat = 3, Premium = 15, ProfitLoss = 100, EndlingBalance = 8182, ForwardLineUnrealised = 40, OpenTradeEquity = 250, DailyOptionValue = 12, AccountValAtMKT = 8500, InitialMargin = 1800, TotalAvailableMargin = 6700 }
    };

            List<AccountBalancesModel> accountBalancesData = new List<AccountBalancesModel>
    {
        new AccountBalancesModel { RefenceNumber = 101, ShortDescription = "Deposit", Debit = 0, Credit = 5000, RunningValue = 5000 },
        new AccountBalancesModel { RefenceNumber = 102, ShortDescription = "Withdrawal", Debit = 2000, Credit = 0, RunningValue = 3000 },
        new AccountBalancesModel { RefenceNumber = 103, ShortDescription = "Trade Profit", Debit = 0, Credit = 1500, RunningValue = 4500 },
              new AccountBalancesModel { RefenceNumber = 101, ShortDescription = "Deposit", Debit = 0, Credit = 5000, RunningValue = 5000 },
        new AccountBalancesModel { RefenceNumber = 102, ShortDescription = "Withdrawal", Debit = 2000, Credit = 0, RunningValue = 3000 },
        new AccountBalancesModel { RefenceNumber = 103, ShortDescription = "Trade Profit", Debit = 0, Credit = 1500, RunningValue = 4500 },
                new AccountBalancesModel { RefenceNumber = 101, ShortDescription = "Deposit", Debit = 0, Credit = 5000, RunningValue = 5000 },
        new AccountBalancesModel { RefenceNumber = 102, ShortDescription = "Withdrawal", Debit = 2000, Credit = 0, RunningValue = 3000 },
        new AccountBalancesModel { RefenceNumber = 103, ShortDescription = "Trade Profit", Debit = 0, Credit = 1500, RunningValue = 4500 },
                new AccountBalancesModel { RefenceNumber = 101, ShortDescription = "Deposit", Debit = 0, Credit = 5000, RunningValue = 5000 },
        new AccountBalancesModel { RefenceNumber = 102, ShortDescription = "Withdrawal", Debit = 2000, Credit = 0, RunningValue = 3000 },
        new AccountBalancesModel { RefenceNumber = 103, ShortDescription = "Trade Profit", Debit = 0, Credit = 1500, RunningValue = 4500 },
                new AccountBalancesModel { RefenceNumber = 101, ShortDescription = "Deposit", Debit = 0, Credit = 5000, RunningValue = 5000 },
        new AccountBalancesModel { RefenceNumber = 102, ShortDescription = "Withdrawal", Debit = 2000, Credit = 0, RunningValue = 3000 },
        new AccountBalancesModel { RefenceNumber = 103, ShortDescription = "Trade Profit", Debit = 0, Credit = 1500, RunningValue = 4500 },
                new AccountBalancesModel { RefenceNumber = 101, ShortDescription = "Deposit", Debit = 0, Credit = 5000, RunningValue = 5000 },
        new AccountBalancesModel { RefenceNumber = 102, ShortDescription = "Withdrawal", Debit = 2000, Credit = 0, RunningValue = 3000 },
        new AccountBalancesModel { RefenceNumber = 103, ShortDescription = "Trade Profit", Debit = 0, Credit = 1500, RunningValue = 4500 },
                new AccountBalancesModel { RefenceNumber = 101, ShortDescription = "Deposit", Debit = 0, Credit = 5000, RunningValue = 5000 },
        new AccountBalancesModel { RefenceNumber = 102, ShortDescription = "Withdrawal", Debit = 2000, Credit = 0, RunningValue = 3000 },
        new AccountBalancesModel { RefenceNumber = 103, ShortDescription = "Trade Profit", Debit = 0, Credit = 1500, RunningValue = 4500 },
                new AccountBalancesModel { RefenceNumber = 101, ShortDescription = "Deposit", Debit = 0, Credit = 5000, RunningValue = 5000 },
        new AccountBalancesModel { RefenceNumber = 102, ShortDescription = "Withdrawal", Debit = 2000, Credit = 0, RunningValue = 3000 },
        new AccountBalancesModel { RefenceNumber = 103, ShortDescription = "Trade Profit", Debit = 0, Credit = 1500, RunningValue = 4500 },
                new AccountBalancesModel { RefenceNumber = 101, ShortDescription = "Deposit", Debit = 0, Credit = 5000, RunningValue = 5000 },
        new AccountBalancesModel { RefenceNumber = 102, ShortDescription = "Withdrawal", Debit = 2000, Credit = 0, RunningValue = 3000 },
        new AccountBalancesModel { RefenceNumber = 103, ShortDescription = "Trade Profit", Debit = 0, Credit = 1500, RunningValue = 4500 }
    };
            List<TradeModel> tradeData = new List<TradeModel>
        {
            new TradeModel { Date = DateOnly.FromDateTime(DateTime.UtcNow), TradeNo = 1, Code = "AAPL", Exchange = "NASDAQ", Long = 10, Short = 0, Contract = "AAPL2025", Currency = "USD", Strike = 150.5m, TradePrice = 150.5m, Comms = 2.5m },
            new TradeModel { Date = DateOnly.FromDateTime(DateTime.UtcNow), TradeNo = 2, Code = "GOOGL", Exchange = "NASDAQ", Long = 0, Short = 5, Contract = "GOOGL2025", Currency = "USD", Strike = 2800.75m, TradePrice = 2800.75m, Comms = 3.0m },
            new TradeModel { Date = DateOnly.FromDateTime(DateTime.UtcNow), TradeNo = 3, Code = "TSLA", Exchange = "NASDAQ", Long = 3, Short = 0, Contract = "TSLA2025", Currency = "USD", Strike = 700.25m, TradePrice = 700.25m, Comms = 1.8m } ,new TradeModel { Date = DateOnly.FromDateTime(DateTime.UtcNow), TradeNo = 1, Code = "AAPL", Exchange = "NASDAQ", Long = 10, Short = 0, Contract = "AAPL2025", Currency = "USD", Strike = 150.5m, TradePrice = 150.5m, Comms = 2.5m },
            new TradeModel { Date = DateOnly.FromDateTime(DateTime.UtcNow), TradeNo = 2, Code = "GOOGL", Exchange = "NASDAQ", Long = 0, Short = 5, Contract = "GOOGL2025", Currency = "USD", Strike = 2800.75m, TradePrice = 2800.75m, Comms = 3.0m },
            new TradeModel { Date = DateOnly.FromDateTime(DateTime.UtcNow), TradeNo = 3, Code = "TSLA", Exchange = "NASDAQ", Long = 3, Short = 0, Contract = "TSLA2025", Currency = "USD", Strike = 700.25m, TradePrice = 700.25m, Comms = 1.8m } ,new TradeModel { Date = DateOnly.FromDateTime(DateTime.UtcNow), TradeNo = 1, Code = "AAPL", Exchange = "NASDAQ", Long = 10, Short = 0, Contract = "AAPL2025", Currency = "USD", Strike = 150.5m, TradePrice = 150.5m, Comms = 2.5m },
            new TradeModel { Date = DateOnly.FromDateTime(DateTime.UtcNow), TradeNo = 2, Code = "GOOGL", Exchange = "NASDAQ", Long = 0, Short = 5, Contract = "GOOGL2025", Currency = "USD", Strike = 2800.75m, TradePrice = 2800.75m, Comms = 3.0m },
            new TradeModel { Date = DateOnly.FromDateTime(DateTime.UtcNow), TradeNo = 3, Code = "TSLA", Exchange = "NASDAQ", Long = 3, Short = 0, Contract = "TSLA2025", Currency = "USD", Strike = 700.25m, TradePrice = 700.25m, Comms = 1.8m }, new TradeModel { Date = DateOnly.FromDateTime(DateTime.UtcNow), TradeNo = 1, Code = "AAPL", Exchange = "NASDAQ", Long = 10, Short = 0, Contract = "AAPL2025", Currency = "USD", Strike = 150.5m, TradePrice = 150.5m, Comms = 2.5m },
            new TradeModel { Date = DateOnly.FromDateTime(DateTime.UtcNow), TradeNo = 2, Code = "GOOGL", Exchange = "NASDAQ", Long = 0, Short = 5, Contract = "GOOGL2025", Currency = "USD", Strike = 2800.75m, TradePrice = 2800.75m, Comms = 3.0m },
            new TradeModel { Date = DateOnly.FromDateTime(DateTime.UtcNow), TradeNo = 3, Code = "TSLA", Exchange = "NASDAQ", Long = 3, Short = 0, Contract = "TSLA2025", Currency = "USD", Strike = 700.25m, TradePrice = 700.25m, Comms = 1.8m } ,new TradeModel { Date = DateOnly.FromDateTime(DateTime.UtcNow), TradeNo = 1, Code = "AAPL", Exchange = "NASDAQ", Long = 10, Short = 0, Contract = "AAPL2025", Currency = "USD", Strike = 150.5m, TradePrice = 150.5m, Comms = 2.5m },
            new TradeModel { Date = DateOnly.FromDateTime(DateTime.UtcNow), TradeNo = 2, Code = "GOOGL", Exchange = "NASDAQ", Long = 0, Short = 5, Contract = "GOOGL2025", Currency = "USD", Strike = 2800.75m, TradePrice = 2800.75m, Comms = 3.0m },
            new TradeModel { Date = DateOnly.FromDateTime(DateTime.UtcNow), TradeNo = 3, Code = "TSLA", Exchange = "NASDAQ", Long = 3, Short = 0, Contract = "TSLA2025", Currency = "USD", Strike = 700.25m, TradePrice = 700.25m, Comms = 1.8m } ,new TradeModel { Date = DateOnly.FromDateTime(DateTime.UtcNow), TradeNo = 1, Code = "AAPL", Exchange = "NASDAQ", Long = 10, Short = 0, Contract = "AAPL2025", Currency = "USD", Strike = 150.5m, TradePrice = 150.5m, Comms = 2.5m },
            new TradeModel { Date = DateOnly.FromDateTime(DateTime.UtcNow), TradeNo = 2, Code = "GOOGL", Exchange = "NASDAQ", Long = 0, Short = 5, Contract = "GOOGL2025", Currency = "USD", Strike = 2800.75m, TradePrice = 2800.75m, Comms = 3.0m },
            new TradeModel { Date = DateOnly.FromDateTime(DateTime.UtcNow), TradeNo = 3, Code = "TSLA", Exchange = "NASDAQ", Long = 3, Short = 0, Contract = "TSLA2025", Currency = "USD", Strike = 700.25m, TradePrice = 700.25m, Comms = 1.8m } ,new TradeModel { Date = DateOnly.FromDateTime(DateTime.UtcNow), TradeNo = 1, Code = "AAPL", Exchange = "NASDAQ", Long = 10, Short = 0, Contract = "AAPL2025", Currency = "USD", Strike = 150.5m, TradePrice = 150.5m, Comms = 2.5m },
            new TradeModel { Date = DateOnly.FromDateTime(DateTime.UtcNow), TradeNo = 2, Code = "GOOGL", Exchange = "NASDAQ", Long = 0, Short = 5, Contract = "GOOGL2025", Currency = "USD", Strike = 2800.75m, TradePrice = 2800.75m, Comms = 3.0m },
            new TradeModel { Date = DateOnly.FromDateTime(DateTime.UtcNow), TradeNo = 3, Code = "TSLA", Exchange = "NASDAQ", Long = 3, Short = 0, Contract = "TSLA2025", Currency = "USD", Strike = 700.25m, TradePrice = 700.25m, Comms = 1.8m } ,new TradeModel { Date = DateOnly.FromDateTime(DateTime.UtcNow), TradeNo = 1, Code = "AAPL", Exchange = "NASDAQ", Long = 10, Short = 0, Contract = "AAPL2025", Currency = "USD", Strike = 150.5m, TradePrice = 150.5m, Comms = 2.5m },
            new TradeModel { Date = DateOnly.FromDateTime(DateTime.UtcNow), TradeNo = 2, Code = "GOOGL", Exchange = "NASDAQ", Long = 0, Short = 5, Contract = "GOOGL2025", Currency = "USD", Strike = 2800.75m, TradePrice = 2800.75m, Comms = 3.0m },
            new TradeModel { Date = DateOnly.FromDateTime(DateTime.UtcNow), TradeNo = 3, Code = "TSLA", Exchange = "NASDAQ", Long = 3, Short = 0, Contract = "TSLA2025", Currency = "USD", Strike = 700.25m, TradePrice = 700.25m, Comms = 1.8m } ,new TradeModel { Date = DateOnly.FromDateTime(DateTime.UtcNow), TradeNo = 1, Code = "AAPL", Exchange = "NASDAQ", Long = 10, Short = 0, Contract = "AAPL2025", Currency = "USD", Strike = 150.5m, TradePrice = 150.5m, Comms = 2.5m },
            new TradeModel { Date = DateOnly.FromDateTime(DateTime.UtcNow), TradeNo = 2, Code = "GOOGL", Exchange = "NASDAQ", Long = 0, Short = 5, Contract = "GOOGL2025", Currency = "USD", Strike = 2800.75m, TradePrice = 2800.75m, Comms = 3.0m },
            new TradeModel { Date = DateOnly.FromDateTime(DateTime.UtcNow), TradeNo = 3, Code = "TSLA", Exchange = "NASDAQ", Long = 3, Short = 0, Contract = "TSLA2025", Currency = "USD", Strike = 700.25m, TradePrice = 700.25m, Comms = 1.8m }
        };
            List<OpenPositions> openPositions = new List<OpenPositions>
            {
                new OpenPositions
                {
                    Date = DateOnly.FromDateTime(DateTime.UtcNow),
                    TradeNo = 1,
                    Code = "AAPL",
                    Exchange = 1, // Example Exchange ID
                    Long = 10,
                    Short = 0,
                    Expiry = new DateOnly(2025, 12, 31), // Example Expiry Date
                    CP = 1, // Example Call/Put Flag
                    Strike = 150.5m,
                    TradePrice = 150.5m,
                    ExchanePrice = 151.0m,
                    Currency = "USD",
                    DebitCredit = -2.5m
                },
                new OpenPositions
                {
                    Date = DateOnly.FromDateTime(DateTime.UtcNow),
                    TradeNo = 2,
                    Code = "GOOGL",
                    Exchange = 1,
                    Long = 0,
                    Short = 5,
                    Expiry = new DateOnly(2025, 12, 31),
                    CP = 0,
                    Strike = 2800.75m,
                    TradePrice = 2800.75m,
                    ExchanePrice = 2805.0m,
                    Currency = "USD",
                    DebitCredit = -3.0m
                },
                new OpenPositions
                {
                    Date = DateOnly.FromDateTime(DateTime.UtcNow),
                    TradeNo = 3,
                    Code = "TSLA",
                    Exchange = 1,
                    Long = 3,
                    Short = 0,
                    Expiry = new DateOnly(2025, 12, 31),
                    CP = 1,
                    Strike = 700.25m,
                    TradePrice = 700.25m,
                    ExchanePrice = 705.0m,
                    Currency = "USD",
                    DebitCredit = -1.8m
                }
            };
        
                // Prepare the dynamic data
                string financeRows = GenerateFinanceRows(financeData);
                string accountBalanceRows = GenerateAccountBalanceRows(accountBalancesData);
                string tradeRows = GenerateTradeRows(tradeData);
                string openPosition = GenerateOpenPositionRows(openPositions);

                // Load template paths
                string templatePath = Path.Combine(_env.ContentRootPath, "Template", "FinanceReport.html");
                string headerPath = Path.Combine(_env.ContentRootPath, "Template", "Header.html");
                string footerPath = Path.Combine(_env.ContentRootPath, "Template", "Footer.html");

       
                // Read the template content
                string htmlContent = System.IO.File.ReadAllText(templatePath);
                string headerContent = System.IO.File.ReadAllText(headerPath);
                string footerContent = System.IO.File.ReadAllText(footerPath);

                // Replace placeholders in the main HTML content
                htmlContent = htmlContent
                    .Replace("{{FinanceRows}}", financeRows)
                    .Replace("{{AccountBalanceRows}}", accountBalanceRows)
                    .Replace("{{TradeRows}}", tradeRows)
                    .Replace("{{OpenPositionRows}}", openPosition);
                string tempHeaderPath = Path.Combine(_env.ContentRootPath, "TempFiles", "Header.html");
                string tempFooterPath = Path.Combine(_env.ContentRootPath, "TempFiles", "Footer.html");
                Directory.CreateDirectory(Path.Combine(_env.ContentRootPath, "TempFiles"));
                System.IO.File.WriteAllText(tempHeaderPath, headerContent);
                System.IO.File.WriteAllText(tempFooterPath, footerContent);
                byte[] pdfBytes = _pdfService.GeneratePdf(tempHeaderPath, tempFooterPath, htmlContent); 
                System.IO.File.Delete(tempHeaderPath);
                System.IO.File.Delete(tempFooterPath);
                return File(pdfBytes, "application/pdf", "FinanceReport.pdf");
            }
        private string GenerateOpenPositionRows(List<OpenPositions> openPosition)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var item in openPosition)
            {
                sb.AppendFormat(
                    "<tr><td>{0}</td><td>{1}</td><td>{2}</td><td>{3}</td><td>{4}</td><td>{5}</td><td>{6}</td><td>{7}</td><td>{8}</td><td>{9}</td><td>{10}</td><td>{11}</td><td>{12}</td></tr>",
                    item.Date, item.TradeNo, item.Code, item.Exchange, item.Long, item.Short, item.Expiry, item.CP,
                    item.Strike, item.TradePrice, item.ExchanePrice, item.Currency, item.DebitCredit
                );
            }
            return sb.ToString();
        }

        private string GenerateTradeRows(List<TradeModel> tradeData)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var item in tradeData)
            {
                sb.AppendFormat("<tr><td>{0}</td><td>{1}</td><td>{2}</td><td>{3}</td><td>{4}</td><td>{5}</td><td>{6}</td><td>{7}</td><td>{8}</td><td>{9}</td><td>{10}</td><td>{11}</td></tr>",
                    item.Date, item.TradeNo, item.Code, item.Exchange, item.Long, item.Short,item.CP,item.Contract, item.Currency,item.Strike,item.TradePrice, item.Comms);
            }
            return sb.ToString();
        }

        private string GenerateAccountBalanceRows(List<AccountBalancesModel> accountBalancesData)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var item in accountBalancesData)
            {
                sb.AppendFormat("<tr><td>{0}</td><td>{1}</td><td>{2}</td><td>{3}</td><td>{4}</td></tr>",
                    item.RefenceNumber, item.ShortDescription, item.Debit, item.Credit, item.RunningValue);
            }
            return sb.ToString();
        }

        private string GenerateFinanceRows(List<FinanceModel> financeData)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var item in financeData)
            {
                sb.AppendFormat("<tr><td>{0}</td><td>{1}</td><td>{2}</td><td>{3}</td><td>{4}</td><td>{5}</td><td>{6}</td><td>{7}</td><td>{8}</td><td>{9}</td><td>{10}</td><td>{11}</td><td>{12}</td><td>{13}</td><td>{14}</td></tr>",
                    item.CcyCode,item.CcyRate, item.OpeningBalance, item.Payments, item.BrokerageAndfees,item.Vat,item.Premium,item.ProfitLoss, item.EndlingBalance,item.ForwardLineUnrealised,item.OpenTradeEquity,item.DailyOptionValue,item.AccountValAtMKT,item.InitialMargin,item.TotalAvailableMargin);
            }
            return sb.ToString();
        }
    }
}
