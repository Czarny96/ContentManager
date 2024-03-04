using System.Diagnostics;
using MediatR;
using ArgumentException = System.ArgumentException;

namespace ContentManager.Application.Users;

public record CreateUser(
    string Email,
    string Password,
    string ConfirmPassword
) : IRequest;

public class CreateUserHandler : IRequestHandler<CreateUser>
{
    public Task Handle(CreateUser request, CancellationToken cancellationToken)
    {
        if (request.Password != request.ConfirmPassword)
        {
            // Todo: Add custom exception
            throw new ArgumentException("Passwords are different");
        }

        // ToDo: CreateUser
        return Task.CompletedTask;
    }
}