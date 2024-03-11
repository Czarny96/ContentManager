using ContentManager.Domain.Abstractions;

namespace ContentManager.Domain.Projects;

public sealed record ProjectPermissionType : Enumeration
{
    public static ProjectPermissionType Owner = new(0, nameof(Owner));
    public static ProjectPermissionType Administrator = new(1, nameof(Administrator));
    public static ProjectPermissionType Editor = new(2, nameof(Editor));
    
    private ProjectPermissionType(ushort id, string name) : base(id, name) { }
}