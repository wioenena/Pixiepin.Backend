using MediatR;

namespace Pixiepin.Backend.Application.Features.Auth.CreateAccount;

public sealed record CreateAccountRequest(
    string? username,
    string? email,
    string? password,
    string? firstName,
    string? lastName,
    string? companyName
) : IRequest<CreateAccountResponse>;
