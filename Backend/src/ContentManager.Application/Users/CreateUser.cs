using ContentManager.Application.Abstractions;
using ContentManager.Domain;
using ContentManager.Domain.Users;
using MediatR;
using ArgumentException = System.ArgumentException;

namespace ContentManager.Application.Users;

public record CreateUser(
    string Email,
    string Password,
    string ConfirmPassword
) : IRequest<CreateUserResponse>;

public record CreateUserResponse(string Token);

public class CreateUserHandler : IRequestHandler<CreateUser, CreateUserResponse>
{
    
    private readonly IUserRepository _userRepository;
    private readonly IPasswordService _passwordService;
    private readonly IJwtService _jwtService;
    private readonly IUnitOfWork _unitOfWork;
    
    public CreateUserHandler(IUserRepository userRepository, IPasswordService passwordService, 
        IJwtService jwtService, IUnitOfWork unitOfWork)
    {
        _userRepository = userRepository;
        _passwordService = passwordService;
        _jwtService = jwtService;
        _unitOfWork = unitOfWork;
    }

    public async Task<CreateUserResponse> Handle(CreateUser request, CancellationToken cancellationToken)
    {
        if (request.Password != request.ConfirmPassword)
        {
            // Todo: Add custom exception
            throw new ArgumentException("Passwords are different");
        }

        var user = await _userRepository.GetByEmail(new EmailAddress(request.Email), cancellationToken);

        if (user is not null)
        {
            // ToDo: Add custom exception
            throw new ArgumentException("User with this email address already exists.");
        }

        //var hashPassword = _passwordService.EncryptPassword(request.Password);
        
        var newUser =
            new User(
                new UserId(),
                new EmailAddress(request.Email),
                new Password(request.Password, Guid.NewGuid()),
                UserStatus.Owner
            );
        
        await _userRepository.Add(newUser, cancellationToken);
        await _unitOfWork.CommitAsync(cancellationToken);

        var token = _jwtService.GenerateToken(newUser);
        
        return new(token);
    }
}