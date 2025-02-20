namespace Pixiepin.Backend.Application.Interfaces.Services;

public interface IJWTService {
    public string GenerateToken(string id, DateTime expireDate);
    public string GenerateAccessToken(string id);
    public string GenerateRefreshToken(string id);
}
