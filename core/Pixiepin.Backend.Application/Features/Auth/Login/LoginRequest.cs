using MediatR;

namespace Pixiepin.Backend.Application.Features.Auth.Login;

public sealed record LoginRequest(
    string? usernameOrEmail,
    string? password
) : IRequest<LoginResponse>;
