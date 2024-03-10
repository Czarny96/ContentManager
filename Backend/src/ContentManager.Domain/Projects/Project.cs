namespace ContentManager.Domain.Projects;

public class Project(ProjectId projectId, ProjectName name, ProjectStatus status, ProjectPermission permission)
{
    public ProjectId Id { get; private set; } = projectId;
    public ProjectName Name { get; private set; } = name;
    public ProjectStatus Status { get; private set; } = status;
    public ProjectPermission Permission { get; private set; } = permission;
}