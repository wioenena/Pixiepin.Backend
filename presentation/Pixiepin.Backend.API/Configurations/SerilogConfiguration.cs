using Serilog;

namespace Pixiepin.Backend.API.Configurations;

public static class SerilogConfiguration {

    public static IServiceCollection ApplySerilogConfiguration(this IServiceCollection services) {
#pragma warning disable CA1305 // Specify IFormatProvider
        var loggerConfiguration = new LoggerConfiguration()
            .MinimumLevel.Information()
            .MinimumLevel.Override("Microsoft", Serilog.Events.LogEventLevel.Information)
            .MinimumLevel.Override("Microsoft.EntityFrameworkCore", Serilog.Events.LogEventLevel.Information)
            .WriteTo.Console();
#pragma warning restore CA1305 // Specify IFormatProvider

        Log.Logger = loggerConfiguration.CreateLogger();

        _ = services.AddSerilog();
        return services;
    }
}
