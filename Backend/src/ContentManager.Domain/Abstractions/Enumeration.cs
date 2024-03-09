using System.Reflection;

namespace ContentManager.Domain.Abstractions;

public abstract record Enumeration
{
    public ushort Id { get; }
    public string Name { get; }

    protected Enumeration(ushort id, string name) =>
        (Id, Name) = (id, name);
    
    public static T FromId<T>(ushort id) where T : class
    {
        var @object = GetAll<T>()
            .SingleOrDefault(x => string.Equals(x.))
    }
    
    private static IEnumerable<T> GetAll<T>(ushort id) where T : class =>
        typeof(T).GetFields(
                BindingFlags.Public |
                BindingFlags.Static |
                BindingFlags.DeclaredOnly
            )
            .Select(x => x.GetValue(null))
            .Cast<T>();
}