using System.Text.RegularExpressions;

namespace ContentManager.Domain.Users;

public sealed partial record Password
{
    public string Value { get; private set; }
    public Guid Salt { get; private set; }
    
    public Password(string value, Guid salt)
    {
        if (string.IsNullOrEmpty(value))
        {
            // ToDo: Add custom exception
            throw new ArgumentException("Password is required");
        }

        if (salt == Guid.Empty)
        {
            // ToDo: Add custom exception
            throw new ArgumentException("Invalid password salt");
        }
        
        Value = value;
        Salt = salt;
    }
}