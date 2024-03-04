using ContentManager.Application.Abstractions;
using ContentManager.Infrastructure.EntityFramework.DbModelConfiguration;
using Microsoft.EntityFrameworkCore;

namespace ContentManager.Infrastructure.EntityFramework;

public class ContentManagerDbContext(DbContextOptions<ContentManagerDbContext> options)
    : DbContext(options), IUnitOfWork, IDbContext
{
    public Task CommitAsync(CancellationToken cancellationToken = default) =>
        SaveChangesAsync(cancellationToken);

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfiguration(new UserEntityConfiguration());
    }
}