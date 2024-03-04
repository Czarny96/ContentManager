namespace ContentManager.Domain.Users;

public sealed record UserId
{
    public Guid Id { get; private set; }

    public UserId()
    {
        Id = Guid.NewGuid();
    }

    public UserId(Guid id)
    {
        if (id.Equals(Guid.Empty))
        {
            // ToDo: Add custom exception
            throw new ArgumentException("Id is required and cannot be Guid.Empty.");
        }

        Id = id;
    }
}