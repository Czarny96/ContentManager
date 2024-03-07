using ContentManager.Domain.Users;

namespace ContentManager.Application.Users;

public interface IJwtService
{
    string GenerateToken(User user);
}