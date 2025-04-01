using DinkToPdf;
using DinkToPdf.Contracts;
using report_generate.Services;
using System.Runtime.InteropServices;
using VedaHawkeyeApi.Interfaces;
using VedaHawkeyeApi.Services;
using MediatR;
using System.Reflection;

try
{
    var builder = WebApplication.CreateBuilder(args);

    // Add services to the container.
    var pathToNativeLibrary = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "wkhtmltox.dll");

    if (File.Exists(pathToNativeLibrary))
    {
        Console.WriteLine($"Loading native library from: {pathToNativeLibrary}");
        NativeLibrary.Load(pathToNativeLibrary);
    }
    else
    {
        Console.WriteLine("⚠️ Native library (libwkhtmltox.dll) not found!");
    }

    builder.Services.AddSingleton(typeof(IConverter), new SynchronizedConverter(new PdfTools()));
    builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

    builder.Services.AddControllers();
    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

    builder.Services.AddScoped<IPdfService, PdfService>();
    builder.Services.AddScoped<ICsvService, CsvService>();
    var app = builder.Build();

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseHttpsRedirection();

    app.UseAuthorization();

    app.MapControllers();

    app.Run();
}
catch(Exception ex)
{

}

