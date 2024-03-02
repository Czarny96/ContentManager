using ContentManager.Application.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace ContentManager.Infrastructure.EntityFramework;

public class ContentManagerDbContext(DbContextOptions<ContentManagerDbContext> options)
    : DbContext(options), IUnitOfWork
{
    public Task CommitAsync(CancellationToken cancellationToken = default) =>
        SaveChangesAsync(cancellationToken);
}