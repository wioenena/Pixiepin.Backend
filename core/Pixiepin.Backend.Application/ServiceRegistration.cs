using System.Reflection;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Pixiepin.Backend.Application.Behaviors;

namespace Pixiepin.Backend.Application;

public static class ServiceRegistration {
    public static IServiceCollection AddApplicationServices(this IServiceCollection services) {
        var assembly = Assembly.GetExecutingAssembly();
        _ = services.AddMediatR(config => {
            _ = config.RegisterServicesFromAssembly(assembly);
            _ = config.AddOpenBehavior(typeof(ValidationBehavior<,>));
        });

        _ = services.AddValidatorsFromAssembly(assembly);
        return services;
    }
}
