using ContentManager.Domain.Users;

namespace ContentManager.Domain;

public interface IUserRepository
{
    Task Add(User user, CancellationToken cancellationToken);
    Task<User?> GetByEmail(EmailAddress email, CancellationToken cancellationToken);
}