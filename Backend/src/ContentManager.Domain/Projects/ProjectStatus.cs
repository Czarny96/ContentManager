using ContentManager.Domain.Abstractions;

namespace ContentManager.Domain.Projects;

public sealed record ProjectStatus : Enumeration
{
    public static readonly ProjectStatus Activated = new(0, nameof(Activated));
    public static readonly ProjectStatus Deactivated = new(1, nameof(Deactivated));

    private ProjectStatus(ushort id, string name) : base(id, name)
    {
    }
}