namespace ContentManager.Domain.Users;

public record AuthenticationResult(string Token, bool Success, IEnumerable<string> Errors);