using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace Pixiepin.Backend.Application;

public static class ServiceRegistration {
    public static IServiceCollection AddApplicationServices(this IServiceCollection services) {
        var assembly = Assembly.GetExecutingAssembly();
        _ = services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(assembly));
        return services;
    }
}
