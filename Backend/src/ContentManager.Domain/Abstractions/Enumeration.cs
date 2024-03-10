using System.Reflection;
using System.Runtime.CompilerServices;

namespace ContentManager.Domain.Abstractions;

public abstract record Enumeration
{
    public ushort Id { get; }
    public string Name { get; }

    protected Enumeration(ushort id, string name) =>
        (Id, Name) = (id, name);
    
    public static T FromId<T>(ushort id) where T : Enumeration
    {
        var @object = GetAll<T>()
            .SingleOrDefault(x => x.Id == id);
        
        if (@object is null)
        {
            // ToDo: Add custom exception
            throw new ArgumentException($"Possible values for {typeof(T)}: {string.Join(",", GetAll<T>().Select(x => $"{x.Id} ({x.Name})"))}", nameof(id));
        }

        return @object;
    }
    
    private static IEnumerable<T> GetAll<T>() where T : Enumeration =>
        typeof(T).GetFields(
                BindingFlags.Public |
                BindingFlags.Static |
                BindingFlags.DeclaredOnly
            )
            .Select(x => x.GetValue(null))
            .Cast<T>();
}