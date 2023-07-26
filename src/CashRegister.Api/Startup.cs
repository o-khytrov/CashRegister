using System.Reflection;
using System.Text;
using CashRegister.Api.Options;
using CashRegister.Api.Persistence.Repositories;
using CashRegister.Api.Services;
using CashRegister.Models.Options;
using CashRegister.Models.Services;
using DinkToPdf;
using DinkToPdf.Contracts;
using FluentMigrator.Runner;
using Microsoft.Extensions.PlatformAbstractions;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace CashRegister.Api;

public class Startup
{
    public void ConfigureServices(IServiceCollection services, IConfiguration configuration)
    {
        services.AddMvc();
        services
            .AddControllers()
            .AddNewtonsoftJson(o =>
            {
                o.SerializerSettings.ContractResolver = new DefaultContractResolver();
                o.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
            });

        Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
        services.Configure<ConnectionStrings>(configuration.GetSection(nameof(ConnectionStrings)));

        services.AddSingleton(typeof(IConverter), new SynchronizedConverter(new PdfTools()));
        services.AddScoped<IViewRenderService, ViewRenderService>();
        services.AddSingleton<IAvailabilityService, AvailabilityService>();
        services.AddSingleton<PdfService>();
        services.AddEndpointsApiExplorer();
        services.Configure<DfsOptions>(o =>
        {
            o.ApiCmd = "http://fs.tax.gov.ua:8609/fs/cmd";
            o.ApiDoc = "http://fs.tax.gov.ua:8609/fs/doc";
            o.ApiPck = "http://fs.tax.gov.ua:8609/fs/pck";
        });
        services.Configure<KeyStorageOptions>(configuration.GetSection(nameof(KeyStorageOptions)));
        services.AddSingleton<DfsHttpClient>();
        services.AddSingleton<DfsService>();

        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        services.AddSingleton<IUserRepository, UserRepository>();
        services.AddAuthentication("BasicAuthentication")
            .AddScheme<AuthOptions, BasicAuthenticationHandler>("BasicAuthentication", null);

        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "CashRegister.Api", Version = "v1" });
            c.AddSecurityDefinition("basic", new OpenApiSecurityScheme
            {
                Name = "Authorization",
                Type = SecuritySchemeType.Http,
                Scheme = "basic",
                In = ParameterLocation.Header,
                Description = "Basic Authorization header using the Bearer scheme."
            });
            c.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "basic"
                        }
                    },
                    new string[] { }
                }
            });
            var xmlCommentsFile = Path.Combine(PlatformServices.Default.Application.ApplicationBasePath,
                Assembly.GetExecutingAssembly()?.GetName().Name + ".xml");
            if (File.Exists(xmlCommentsFile))
            {
                c.IncludeXmlComments(xmlCommentsFile);
            }
        });
        services.AddFluentMigratorCore()
            .ConfigureRunner(c => c
                .AddSqlServer()
                .WithGlobalConnectionString(configuration.GetConnectionString(nameof(ConnectionStrings.CashRegisterDb)))
                .ScanIn(Assembly.GetExecutingAssembly()).For.All());
        services.AddSingleton<Repository>();
        services.AddMemoryCache();
    }

    public void Configure(WebApplication app)
    {
        app.UseDeveloperExceptionPage();
        app.UseSwagger();
        app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "CashRegister.Api v1"));
        app.UseMiddleware<ApiResponseWrapperMiddleware>();
        app.UseRouting();
        app.UseAuthentication();
        app.UseAuthorization();

        app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
    }
}