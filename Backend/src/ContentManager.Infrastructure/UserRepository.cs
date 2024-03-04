using ContentManager.Domain;
using ContentManager.Domain.Users;
using ContentManager.Infrastructure.EntityFramework;

namespace ContentManager.Infrastructure;

public class UserRepository : IUserRepository
{
    private readonly IDbContext _context;

    public UserRepository(IDbContext context)
    {
        _context = context;
    }

    public async Task Add(User user, CancellationToken cancellationToken) =>
        await _context.Set<User>().AddAsync(user, cancellationToken);
}