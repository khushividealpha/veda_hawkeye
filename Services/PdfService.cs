using DinkToPdf.Contracts;
using DinkToPdf;
using System;
using System.Runtime.InteropServices;

namespace report_generate.Services
{
    public class PdfService : IPdfService
    {
        private readonly IConverter _pdfConverter;

        public PdfService(IConverter pdfConverter)
        {
           EnsureWkHtmlToXLoaded();
            _pdfConverter = pdfConverter;

        }

        public byte[] GeneratePdf(string headerPath, string footerPath, string htmlContent)
        {        
            var globalSettings = new GlobalSettings
            {
                ColorMode = ColorMode.Color,
                Orientation = Orientation.Portrait,
                PaperSize = PaperKind.A2
            };

            var objectSettings = new ObjectSettings
            {
                PagesCount = true,
                HtmlContent = htmlContent,

                HeaderSettings = { HtmUrl = headerPath, Spacing = 5 }, 
                FooterSettings = { HtmUrl = footerPath, Spacing = 25,  Right = "Page [page] of [toPage]" ,  Left = $"Printed on {DateTime.Now:dd-MMM-yyyy}"
           },
                WebSettings = { DefaultEncoding = "utf-8" }
            };

            var pdfDoc = new HtmlToPdfDocument()
            {
                GlobalSettings = globalSettings,
                Objects = { objectSettings }
            };

            try
            {
                return _pdfConverter.Convert(pdfDoc);
            }        
            catch (Exception ex)
            {
                throw new InvalidOperationException("An error occurred while generating the PDF.", ex);
            }
        }

        private void EnsureWkHtmlToXLoaded()
        {

            const string dllName = "wkhtmltox";
            string dllPath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, dllName + ".dll");
            if (!NativeLibrary.TryLoad(dllName, out _))
            {
                throw new DllNotFoundException($"Unable to load the DLL '{dllName}'. Ensure it is present in the output directory and all dependencies are installed.");
            }
        }
    }
}
