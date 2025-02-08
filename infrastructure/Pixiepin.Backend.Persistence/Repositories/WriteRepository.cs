using Microsoft.EntityFrameworkCore;
using Pixiepin.Backend.Application.Interfaces.Repositories;
using Pixiepin.Backend.Domain.Entities.Common;
using Pixiepin.Backend.Persistence.Contexts;

namespace Pixiepin.Backend.Persistence.Repositories;

public class WriteRepository<TEntity>(ApplicationDbContext context) : Repository<TEntity>(context), IWriteRepository<TEntity> where TEntity : BaseEntity {
    public async Task<bool> AddAsync(TEntity entity)
        => (await this.Table.AddAsync(entity)).State == EntityState.Added;

    public bool Remove(TEntity entity) => this.Table.Remove(entity).State == EntityState.Deleted;
    public bool Update(TEntity entity) => this.Table.Update(entity).State == EntityState.Modified;
}
