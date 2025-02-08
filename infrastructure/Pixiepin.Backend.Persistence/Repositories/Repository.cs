using Microsoft.EntityFrameworkCore;
using Pixiepin.Backend.Domain.Entities.Common;
using Pixiepin.Backend.Persistence.Contexts;

namespace Pixiepin.Backend.Persistence.Repositories;

public abstract class Repository<TEntity>(ApplicationDbContext context) where TEntity : BaseEntity {
    protected ApplicationDbContext Context { get; } = context;
    protected DbSet<TEntity> Table => this.Context.Set<TEntity>();
}
