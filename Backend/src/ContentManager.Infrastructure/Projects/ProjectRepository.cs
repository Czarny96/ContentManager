using ContentManager.Domain.Projects;
using ContentManager.Domain.Users;
using ContentManager.Infrastructure.EntityFramework;

namespace ContentManager.Infrastructure.Projects;

internal class ProjectRepository : IProjectRepository
{
    private readonly IDbContext _context;

    public ProjectRepository(IDbContext context)
    {
        _context = context;
    }

    public IReadOnlyCollection<Project> GetAll(UserId userId, CancellationToken cancellationToken) =>
        _context
            .Set<Project>()
            .Where(x => x.Permissions.Any(x => x.UserId == userId))
            .ToList()
            .AsReadOnly();

    public async Task Add(Project project, CancellationToken cancellationToken) =>
        await _context.Set<Project>().AddAsync(project, cancellationToken);
}