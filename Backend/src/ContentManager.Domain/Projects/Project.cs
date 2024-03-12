namespace ContentManager.Domain.Projects;

public class Project(ProjectId id, ProjectName name)
{
    private readonly List<ProjectPermission> _projectPermissions = new();
    
    public ProjectId Id { get; private set; } = id;
    public ProjectName Name { get; private set; } = name;
    public IReadOnlyCollection<ProjectPermission> Permissions => _projectPermissions;
}