using Microsoft.EntityFrameworkCore;
using Pixiepin.Backend.Application.Interfaces.Repositories;
using Pixiepin.Backend.Domain.Entities.Common;
using Pixiepin.Backend.Persistence.Contexts;

namespace Pixiepin.Backend.Persistence.Repositories;

public class ReadRepository<TEntity>(ApplicationDbContext context) : Repository<TEntity>(context), IReadRepository<TEntity> where TEntity : BaseEntity {
    public async Task<IEnumerable<TEntity>> GetAllAsync()
        => await this.Table.ToListAsync();
    public async Task<TEntity?> GetByIdAsync(Guid id)
        => await this.Table.FindAsync(id);
}
