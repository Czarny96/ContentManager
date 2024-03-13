using ContentManager.Domain.Users;

namespace ContentManager.Domain.Projects;

public interface IProjectRepository
{
    IReadOnlyCollection<Project> GetAll(UserId userId,
        IReadOnlyCollection<ProjectPermissionType> permissionTypes, CancellationToken cancellationToken);
}