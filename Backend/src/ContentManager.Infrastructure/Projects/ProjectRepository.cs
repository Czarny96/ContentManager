using ContentManager.Domain.Projects;
using ContentManager.Domain.Users;
using ContentManager.Infrastructure.EntityFramework;
using Microsoft.EntityFrameworkCore;

namespace ContentManager.Infrastructure.Projects;

internal class ProjectRepository : IProjectRepository
{
    private readonly IDbContext _context;

    public ProjectRepository(IDbContext context)
    {
        _context = context;
    }

    public IReadOnlyCollection<Project> GetAll(UserId userId,
        IReadOnlyCollection<ProjectPermissionType> permissionTypes, CancellationToken cancellationToken) =>
        _context
            .Set<Project>()
            .Where(x => x.Permissions.Any(x => x.UserId == userId && permissionTypes.Contains(x.PermissionType)))
            .ToList()
            .AsReadOnly();

}