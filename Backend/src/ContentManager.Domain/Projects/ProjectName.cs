namespace ContentManager.Domain.Projects;

public sealed record ProjectName
{
    public string? Value { get; private set; }

    public ProjectName(string value)
    {
        if (string.IsNullOrEmpty(value))
        {
            // ToDo: Add custom exception
            throw new ArgumentException("Project name is required. ");
        }

        Value = value;
    }
}