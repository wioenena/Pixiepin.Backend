namespace Pixiepin.Backend.Persistence.Settings;

public sealed class JWTSettings {
    public required string Secret { get; set; }
    public required string Issuer { get; set; }
    public required string Audience { get; set; }
    public required ushort TokenExpirationInMinutes { get; set; }
    public required ushort RefreshTokenExpirationInMinutes { get; set; }
}
