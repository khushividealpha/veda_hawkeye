namespace report_generate.Services
{
    public interface IPdfService
    {
        byte[] GeneratePdf(string headerPath, string footerPath, string htmlContent);

    }
}
