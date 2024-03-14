namespace ContentManager.Domain.Projects;

public class Project(ProjectId id, ProjectName name, ProjectStatus status)
{
    private readonly List<ProjectPermission> _projectPermissions = new();
    
    public ProjectId Id { get; private set; } = id;
    public ProjectName Name { get; private set; } = name;
    public IReadOnlyCollection<ProjectPermission> Permissions => _projectPermissions;
    public ProjectStatus Status { get; private set; } = status;
}