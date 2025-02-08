using System;
using Pixiepin.Backend.Domain.Entities.Common;

namespace Pixiepin.Backend.Application.Interfaces.Repositories;

public interface IWriteRepository<TEntity> where TEntity : BaseEntity {
    public Task<bool> AddAsync(TEntity entity);
    public bool Remove(TEntity entity);
    public bool Update(TEntity entity);
}
