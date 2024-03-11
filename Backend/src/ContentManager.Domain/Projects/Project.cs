using ContentManager.Domain.Users;

namespace ContentManager.Domain.Projects;

public class Project(ProjectId projectId, ProjectName name, UserStatus status, IReadOnlyCollection<ProjectPermission> permission)
{
    private readonly List<ProjectPermission> _projectPermissions = permission.ToList();
    
    public ProjectId Id { get; private set; } = projectId;
    public ProjectName Name { get; private set; } = name;
    public UserStatus Status { get; private set; } = status;
    public IReadOnlyCollection<ProjectPermission> Permissions => _projectPermissions;
}