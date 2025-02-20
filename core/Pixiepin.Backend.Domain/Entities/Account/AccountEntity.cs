using Pixiepin.Backend.Domain.Entities.Common;

namespace Pixiepin.Backend.Domain.Entities.Account;

public sealed class AccountEntity : BaseEntity {
    public required string Username { get; set; }
    public string? Email { get; set; }
    public required string Password { get; set; }
    public DateTime? LastLoginAt { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required string CompanyName { get; set; }
    public string? AccessToken { get; set; }
    public string? RefreshToken { get; set; }
}
