using ContentManager.Domain.Users;

namespace ContentManager.Domain.Projects;

public sealed class ProjectPermission(UserId userId, ProjectPermissionType permissionType)
{
    public UserId UserId { get; private set; } = userId;
    public ProjectPermissionType PermissionType { get; private set; } = permissionType;
}