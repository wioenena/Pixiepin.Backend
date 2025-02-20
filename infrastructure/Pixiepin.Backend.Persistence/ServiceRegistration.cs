using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Pixiepin.Backend.Application.Interfaces;
using Pixiepin.Backend.Application.Interfaces.Services;
using Pixiepin.Backend.Persistence.Contexts;
using Pixiepin.Backend.Persistence.Services;
using Pixiepin.Backend.Persistence.Settings;

namespace Pixiepin.Backend.Persistence;

public static class ServiceRegistration {
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration) {
        _ = services.AddDbContext<ApplicationDbContext>();
        _ = services.AddScoped<IUnitOfWork, UnitOfWork>();
        _ = services.AddSingleton<IPasswordService, PasswordService>();
        _ = services.AddSingleton<IJWTService, JWTService>();
        _ = services.Configure<JWTSettings>(configuration.GetSection("JWTSettings"));
        return services;
    }
}
