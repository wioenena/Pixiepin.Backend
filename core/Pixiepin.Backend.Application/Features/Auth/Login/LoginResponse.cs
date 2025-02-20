namespace Pixiepin.Backend.Application.Features.Auth.Login;

public sealed record LoginResponse(Guid accountId, string accessToken, string refreshToken);
