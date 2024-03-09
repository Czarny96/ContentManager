using ContentManager.Domain.Users;

namespace ContentManager.Domain.Projects;

public sealed class ProjectPermission
{
    public ProjectId ProjectId { get; private set; }
    public UserId UserId { get; private set; }
}