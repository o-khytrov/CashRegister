using System.Globalization;
using System.Text;
using CashRegister.Api;
using FluentMigrator.Runner;

Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

var webApplicationOptions = new WebApplicationOptions()
{
    Args = args,
    ContentRootPath = AppContext.BaseDirectory,
    ApplicationName = System.Diagnostics.Process.GetCurrentProcess().ProcessName
};

var builder = WebApplication.CreateBuilder(webApplicationOptions);

var startup = new Startup();

builder.Host.UseWindowsService(o => o.ServiceName = "CashRegister.Api");

startup.ConfigureServices(builder.Services, builder.Configuration);

var webApplication = builder.Build();

startup.Configure(webApplication);

MigrateDb(webApplication);

await webApplication.RunAsync();

public partial class Program
{
    private static void MigrateDb(IHost host)
    {
        var runner = host.Services.CreateScope().ServiceProvider.GetRequiredService<IMigrationRunner>();
        runner.ListMigrations();
        runner.MigrateUp();
    }
}