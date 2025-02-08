using Pixiepin.Backend.Application.Interfaces.Repositories;
using Pixiepin.Backend.Domain.Entities.Account;
using Pixiepin.Backend.Domain.Entities.Common;

namespace Pixiepin.Backend.Application.Interfaces;

public interface IUnitOfWork : IDisposable {
    public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    public IReadRepository<TEntity> GetReadRepository<TEntity>() where TEntity : BaseEntity;
    public IWriteRepository<TEntity> GetWriteRepository<TEntity>() where TEntity : BaseEntity;
}

