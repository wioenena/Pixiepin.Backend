using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Pixiepin.Backend.Persistence.Contexts;

public sealed class ApplicationDbContext(IConfiguration configuration, ILoggerFactory loggerFactory) : DbContext {
    private readonly IConfiguration configuration = configuration;
    private readonly ILoggerFactory loggerFactory = loggerFactory;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
        _ = optionsBuilder
                .UseNpgsql(this.configuration.GetConnectionString("PostgreSQL"))
                .EnableDetailedErrors()
                .UseLoggerFactory(this.loggerFactory);
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder) {
        _ = modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}
