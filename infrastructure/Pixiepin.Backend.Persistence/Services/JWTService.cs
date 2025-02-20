using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Pixiepin.Backend.Application.Interfaces.Services;
using Pixiepin.Backend.Persistence.Settings;


namespace Pixiepin.Backend.Persistence.Services;

public sealed class JWTService(IOptions<JWTSettings> jwtSettings) : IJWTService {
    private readonly IOptions<JWTSettings> jwtSettings = jwtSettings;

    public string GenerateAccessToken(string id) => this.GenerateToken(id, DateTime.UtcNow.AddMinutes(this.jwtSettings.Value.TokenExpirationInMinutes));
    public string GenerateRefreshToken(string id) => this.GenerateToken(id, DateTime.UtcNow.AddMinutes(this.jwtSettings.Value.RefreshTokenExpirationInMinutes));

    public string GenerateToken(string id, DateTime expireDate) {
        var secret = this.jwtSettings.Value.Secret;
        var issuer = this.jwtSettings.Value.Issuer;
        var audience = this.jwtSettings.Value.Audience;

        SymmetricSecurityKey securityKey = new(Encoding.UTF8.GetBytes(secret));
        JwtSecurityToken jwtToken = new(
            issuer: issuer,
            audience: audience,
            claims: [new("id", id)],
            notBefore: DateTime.UtcNow,
            expires: expireDate,
            signingCredentials: new(securityKey, SecurityAlgorithms.HmacSha256)
        );

        return new JwtSecurityTokenHandler().WriteToken(jwtToken);
    }
}
