namespace ContentManager.Domain.Projects;

public sealed record ProjectId
{
    public Guid Id { get; private set; }

    public ProjectId()
    {
        Id = Guid.NewGuid();
    }

    public ProjectId(Guid id)
    {
        if (id.Equals(Guid.Empty))
        {
            // ToDo: Add custom exception
            throw new ArgumentException("Id is required and cannot be Guid.Empty");
        }

        Id = id;
    }
}