namespace Pixiepin.Backend.Application.Interfaces.Services;

public interface IPasswordService {
    public string Hash(string normalPassword);
    public bool Validate(string normalPassword, string hashedPassword);
}
