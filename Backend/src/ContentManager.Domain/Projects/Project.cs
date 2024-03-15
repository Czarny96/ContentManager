using ContentManager.Domain.Users;

namespace ContentManager.Domain.Projects;

public class Project(ProjectId id, ProjectName name, ProjectStatus status)
{
    private readonly List<ProjectPermission> _projectPermissions = new();
    
    public ProjectId Id { get; private set; } = id;
    public ProjectName Name { get; private set; } = name;
    public IReadOnlyCollection<ProjectPermission> Permissions => _projectPermissions;
    public ProjectStatus Status { get; private set; } = status;

    public static Project Create(ProjectName name, ProjectStatus status, ProjectPermission projectPermission)
    {
        var project = new Project(new ProjectId(), name, status);
        project.AddPermission(projectPermission);

        return project;
    }
    
    private void AddPermission(ProjectPermission projectPermission)
    {
        _projectPermissions.Add(projectPermission);
    }
}