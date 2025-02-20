using Microsoft.EntityFrameworkCore;
using Npgsql;
using Pixiepin.Backend.Application.Exceptions;
using Pixiepin.Backend.Application.Interfaces;
using Pixiepin.Backend.Application.Interfaces.Repositories;
using Pixiepin.Backend.Domain.Entities.Common;
using Pixiepin.Backend.Persistence.Contexts;
using Pixiepin.Backend.Persistence.Repositories;

namespace Pixiepin.Backend.Persistence;

public class UnitOfWork(ApplicationDbContext context) : IUnitOfWork {
    private readonly ApplicationDbContext context = context;
    private readonly Dictionary<Type, object> repositories = [];
    private bool disposed;


    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default) {
        using var transaction = await this.context.Database.BeginTransactionAsync(cancellationToken);
        try {
            var result = await this.context.SaveChangesAsync(cancellationToken);
            await transaction.CommitAsync(cancellationToken);
            return result;
        } catch (DbUpdateException dbUpdateException) when (dbUpdateException.InnerException is PostgresException postgresException) {
            if (postgresException.SqlState == "23505")
                throw new EntityAlreadyExistException(dbUpdateException.InnerException!.Message);

            throw;
        } catch {
            throw;
        }
    }


    protected virtual void Dispose(bool disposing) {
        if (!this.disposed) {
            if (disposing) {
                this.context.Dispose();
            }
            this.disposed = true;
        }
    }

    public void Dispose() {
        this.Dispose(true);
        GC.SuppressFinalize(this);
    }

    public IReadRepository<TEntity> GetReadRepository<TEntity>() where TEntity : BaseEntity {
        var entityType = typeof(TEntity);
        if (!this.repositories.TryGetValue(entityType, out var repository)) {
            repository = new ReadRepository<TEntity>(this.context);
            this.repositories[entityType] = repository;
        }

        return (IReadRepository<TEntity>)repository!;
    }
    public IWriteRepository<TEntity> GetWriteRepository<TEntity>() where TEntity : BaseEntity {
        var entityType = typeof(TEntity);
        if (!this.repositories.TryGetValue(entityType, out var repository)) {
            repository = new WriteRepository<TEntity>(this.context);
            this.repositories[entityType] = repository;
        }

        return (IWriteRepository<TEntity>)repository!;
    }
}
