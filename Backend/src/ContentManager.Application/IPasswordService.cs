namespace ContentManager.Application;

public interface IPasswordService
{
    string EncryptPassword(string password);
    bool VerifyPassword(string password, string basePassword);
}