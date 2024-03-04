using Microsoft.EntityFrameworkCore;

namespace ContentManager.Infrastructure.EntityFramework;

public interface IDbContext
{
    DbSet<TEntity> Set<TEntity>() where TEntity : class;
}