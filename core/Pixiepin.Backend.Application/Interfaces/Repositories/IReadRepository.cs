using Pixiepin.Backend.Domain.Entities.Common;

namespace Pixiepin.Backend.Application.Interfaces.Repositories;

public interface IReadRepository<TEntity> where TEntity : BaseEntity {
    public Task<TEntity?> GetByIdAsync(Guid id);
    public Task<IEnumerable<TEntity>> GetAllAsync();
}
