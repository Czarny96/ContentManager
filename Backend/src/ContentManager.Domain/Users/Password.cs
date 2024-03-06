using System.Text.RegularExpressions;

namespace ContentManager.Domain.Users;

public sealed partial record Password
{
    [GeneratedRegex(Pattern, RegexOptions.Compiled)]
    private static partial Regex PasswordRegex();
    
    private const string Pattern = @"^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{10,}$";
    private readonly byte[] _appSalt = [31, 0x30, 0x30, 0x63, 0x6f, 0x6d, 0x6d, 0x69, 0x74, 0x6f, 0x77];
    
    public string Value { get; private set; }
    public Guid Salt { get; private set; }
    
    public Password(string value, Guid salt)
    {
        if (string.IsNullOrEmpty(value))
        {
            // ToDo: Add custom exception
            throw new ArgumentException("Password is required");
        }
        
        if (!PasswordRegex().IsMatch(value))
        {
            // ToDo: Add custom exception
            throw new ArgumentException("Invalid password pattern");
        }

        if (salt == Guid.Empty)
        {
            // ToDo: Add custom exception
            throw new ArgumentException("Invalid password salt");
        }

        var hashPassword = BCrypt.Net.BCrypt.HashPassword(value, 13);
        
        Value = hashPassword;
        Salt = salt;
    }
}