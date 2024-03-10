using ContentManager.Domain.Users;

namespace ContentManager.Domain.Projects;

public sealed class ProjectPermission(ProjectId projectId, UserId userId)
{
    public ProjectId ProjectId { get; private set; } = projectId;
    public UserId UserId { get; private set; } = userId;
}