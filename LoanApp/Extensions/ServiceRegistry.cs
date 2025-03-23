using LoanApp.Dtos;
using LoanApp.Services.Implementations;
using LoanApp.Services.Interfaces;
using Serilog;
namespace LoanApp.Extensions;

public static class ServiceRegistration
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var appSettingsSection = configuration.GetSection("AppSettings");
        services.Configure<AppSettings>(appSettingsSection);
        var appSettings = appSettingsSection.Get<AppSettings>();

        services.AddScoped<ILoanApplicationService, LoanApplicationService>();

        Log.Logger = new LoggerConfiguration()
          .MinimumLevel.Debug()
          .MinimumLevel.Override("Microsoft", Serilog.Events.LogEventLevel.Warning)
          .Enrich.FromLogContext()
          .WriteTo.File(appSettings.LogPath, rollingInterval: RollingInterval.Day)
          //.WriteTo.Console(restrictedToMinimumLevel: Serilog.Events.LogEventLevel.Information)
          .CreateLogger();

        return services;
    }
}

