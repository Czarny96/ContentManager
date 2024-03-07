using ContentManager.Application;

namespace ContentManager.Infrastructure;

// ToDo: Learn how to do it better
public class PasswordService : IPasswordService
{
    public string EncryptPassword(string password) =>
        BCrypt.Net.BCrypt.HashPassword(password, 13);

    public bool VerifyPassword(string password, string basePassword) =>
        BCrypt.Net.BCrypt.EnhancedVerify(password, basePassword);
}