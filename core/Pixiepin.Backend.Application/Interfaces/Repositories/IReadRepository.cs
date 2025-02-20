using System.Linq.Expressions;
using Pixiepin.Backend.Domain.Entities.Common;

namespace Pixiepin.Backend.Application.Interfaces.Repositories;

public interface IReadRepository<TEntity> where TEntity : BaseEntity {
    public Task<TEntity?> GetByIdAsync(Guid id);
    public Task<IEnumerable<TEntity>> GetAllAsync();
    public Task<TEntity?> FindByExpression(Expression<Func<TEntity, bool>> expression);
}
