using ContentManager.Domain.Users;

namespace ContentManager.Domain.Projects;

public interface IProjectRepository
{
    IReadOnlyCollection<Project> GetAll(UserId userId, CancellationToken cancellationToken);
}