using FluentValidation;

namespace Pixiepin.Backend.Application.Features.Auth.Login;

public sealed class LoginValidator : AbstractValidator<LoginRequest> {
    public LoginValidator() {
        _ = this.RuleFor(r => r.usernameOrEmail)
            .NotEmpty()
            .WithMessage("Username or email is required.");
        _ = this.RuleFor(r => r.password)
            .NotEmpty()
            .WithMessage("Password is required.");
    }
}
