using MediatR;
using Pixiepin.Backend.Application.Interfaces;
using Pixiepin.Backend.Application.Interfaces.Services;
using Pixiepin.Backend.Domain.Entities.Account;

namespace Pixiepin.Backend.Application.Features.Auth.CreateAccount;

public class CreateAccountHandler(IUnitOfWork unitOfWork, IPasswordService passwordService) : IRequestHandler<CreateAccountRequest, CreateAccountResponse> {
    private readonly IUnitOfWork unitOfWork = unitOfWork;
    private readonly IPasswordService passwordService = passwordService;

    public async Task<CreateAccountResponse> Handle(CreateAccountRequest request, CancellationToken cancellationToken) {
        var writeRepository = this.unitOfWork.GetWriteRepository<AccountEntity>();
        AccountEntity account = new() {
            Username = request.username!,
            Email = request.email,
            Password = this.passwordService.Hash(request.password!),
            FirstName = request.firstName!,
            LastName = request.lastName!,
            CompanyName = request.companyName!
        };

        _ = await writeRepository.AddAsync(account);
        _ = await this.unitOfWork.SaveChangesAsync(cancellationToken);
        var response = new CreateAccountResponse(account.Id);
        return response;
    }
}
