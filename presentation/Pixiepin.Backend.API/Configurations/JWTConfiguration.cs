using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Pixiepin.Backend.Persistence.Settings;

namespace Pixiepin.Backend.API.Configurations;

public static class JWTConfiguration {
    public static IServiceCollection ApplyJWTConfiguration(this IServiceCollection services, bool isDevelopment) {
        _ = services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(jwtOptions => {
            var jwtSettings = services.BuildServiceProvider().GetRequiredService<IOptions<JWTSettings>>();
            jwtOptions.RequireHttpsMetadata = !isDevelopment;
            jwtOptions.SaveToken = true;
            jwtOptions.TokenValidationParameters = new() {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = jwtSettings.Value.Issuer,
                ValidAudience = jwtSettings.Value.Audience,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.Value.Secret)),
                ClockSkew = TimeSpan.Zero
            };
        });
        return services;
    }
}
