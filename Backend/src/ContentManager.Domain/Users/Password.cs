using System.Text.RegularExpressions;

namespace ContentManager.Domain.Users;

// ToDo: Add salt
public sealed partial record Password
{
    [GeneratedRegex(Pattern, RegexOptions.Compiled)]
    private static partial Regex PasswordRegex();
    
    private const string Pattern = @"^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{10,}$";
    
    public string Value { get; private set; }

    public Password(string value)
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

        Value = value;
    }
}