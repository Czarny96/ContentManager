namespace ContentManager.Domain.Users;

public class User(UserId id, EmailAddress email, Password password, UserStatus userStatus)
{
    public UserId Id { get; private set; } = id;
    public EmailAddress Email { get; private set; } = email;
    public Password Password { get; private set; } = password;
    public UserStatus Status { get; private set; } = userStatus;
}