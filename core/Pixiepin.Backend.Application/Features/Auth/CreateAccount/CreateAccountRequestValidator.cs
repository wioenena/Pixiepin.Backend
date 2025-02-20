using FluentValidation;

namespace Pixiepin.Backend.Application.Features.Auth.CreateAccount;

public class CreateAccountRequestValidator : AbstractValidator<CreateAccountRequest> {
    public CreateAccountRequestValidator() {
        _ = this.RuleFor(r => r.username)
            .NotEmpty()
            .MinimumLength(3)
            .MaximumLength(50)
            .WithMessage("Username must be between 3 and 50 characters.");
        _ = this.RuleFor(r => r.email)
            .EmailAddress()
            .When(r => r.email is not null)
            .WithMessage("Email is not a valid email address.");
        _ = this.RuleFor(r => r.password)
            .NotEmpty()
            .WithMessage("Password is required.");
        _ = this.RuleFor(r => r.firstName)
            .NotEmpty()
            .WithMessage("First name is required.");
        _ = this.RuleFor(r => r.lastName)
            .NotEmpty()
            .WithMessage("Last name is required.");
        _ = this.RuleFor(r => r.companyName)
            .NotEmpty()
            .WithMessage("Company name is required.");
    }
}
