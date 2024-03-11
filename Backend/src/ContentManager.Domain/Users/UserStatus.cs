using ContentManager.Domain.Abstractions;

namespace ContentManager.Domain.Users;

public sealed record UserStatus : Enumeration
{
    public static readonly UserStatus Activated = new(0, nameof(Activated));
    public static readonly UserStatus Deactivated = new(1, nameof(Deactivated));

    private UserStatus(ushort id, string name) : base(id, name)
    {
    }
}