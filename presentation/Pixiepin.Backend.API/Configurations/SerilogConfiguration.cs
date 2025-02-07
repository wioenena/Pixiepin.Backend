using Serilog;

namespace Pixiepin.Backend.API.Configurations;

public static class SerilogConfiguration {

    public static IServiceCollection ApplySerilogConfiguration(this IServiceCollection services) {
#pragma warning disable CA1305 // Specify IFormatProvider
        var loggerConfiguration = new LoggerConfiguration()
            .WriteTo.Console();
#pragma warning restore CA1305 // Specify IFormatProvider
#if DEBUG
        loggerConfiguration.MinimumLevel.Debug();
#else
        loggerConfiguration.MinimumLevel.Information();
#endif
        Log.Logger = loggerConfiguration.CreateLogger();

        _ = services.AddSerilog();
        return services;
    }
}
