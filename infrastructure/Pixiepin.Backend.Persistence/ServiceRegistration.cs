using Microsoft.Extensions.DependencyInjection;
using Pixiepin.Backend.Application.Interfaces;
using Pixiepin.Backend.Persistence.Contexts;

namespace Pixiepin.Backend.Persistence;

public static class ServiceRegistration {
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services) {
        _ = services.AddDbContext<ApplicationDbContext>();
        _ = services.AddScoped<IUnitOfWork, UnitOfWork>();
        return services;
    }
}
