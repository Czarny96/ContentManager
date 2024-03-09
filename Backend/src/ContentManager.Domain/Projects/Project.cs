namespace ContentManager.Domain.Projects;

public class Project(ProjectId projectId, ProjectName name)
{
    public ProjectId Id { get; private set; } = projectId;
    public ProjectName Name { get; private set; } = name;
}