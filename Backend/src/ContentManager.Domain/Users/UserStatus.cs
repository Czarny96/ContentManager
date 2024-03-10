using ContentManager.Domain.Abstractions;

namespace ContentManager.Domain.Users;

public sealed record UserStatus : Enumeration
{
    public static UserStatus Owner = new(0, nameof(Owner));
    public static UserStatus Administrator = new(1, nameof(Administrator));
    public static UserStatus Editor = new(2, nameof(Editor));
    
    private UserStatus(ushort id, string name) : base(id, name) { }
}