using MediatR;
using Pixiepin.Backend.Application.Exceptions;
using Pixiepin.Backend.Application.Interfaces;
using Pixiepin.Backend.Application.Interfaces.Services;
using Pixiepin.Backend.Domain.Entities.Account;

namespace Pixiepin.Backend.Application.Features.Auth.Login;

public sealed class LoginHandler(IUnitOfWork unitOfWork, IPasswordService passwordService, IJWTService jwtService) : IRequestHandler<LoginRequest, LoginResponse> {
    private readonly IUnitOfWork unitOfWork = unitOfWork;
    private readonly IPasswordService passwordService = passwordService;
    private readonly IJWTService jwtService = jwtService;

    public async Task<LoginResponse> Handle(LoginRequest request, CancellationToken cancellationToken) {
        var readRepository = this.unitOfWork.GetReadRepository<AccountEntity>();
        var account = await readRepository.FindByExpression(a => a.Username == request.usernameOrEmail || a.Email == request.usernameOrEmail) ?? throw new AccountNotFoundException($"Account with username or email '{request.usernameOrEmail}' not found.");

        if (!this.passwordService.Validate(request.password!, account.Password))
            throw new InvalidPasswordException($"Invalid password for account with username or email '{request.usernameOrEmail}'.");

        var accountIdString = account.Id.ToString();
        var accessToken = this.jwtService.GenerateAccessToken(accountIdString);
        var refreshToken = this.jwtService.GenerateRefreshToken(accountIdString);
        account.AccessToken = accessToken;
        account.RefreshToken = refreshToken;
        _ = await this.unitOfWork.SaveChangesAsync(cancellationToken);
        return new(account.Id, accessToken, refreshToken);
    }
}
