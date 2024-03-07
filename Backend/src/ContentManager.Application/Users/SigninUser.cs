using ContentManager.Domain;
using ContentManager.Domain.Users;
using MediatR;

namespace ContentManager.Application.Users;

public record SigninUser(string Email, string Password) : IRequest<SigninUserResponse>;

public record SigninUserResponse(string Token);

internal class SigninHandler : IRequestHandler<SigninUser, SigninUserResponse>
{
    private IUserRepository _userRepository;
    private readonly IPasswordService _passwordService;
    private IJwtService _jwtService;
    
    public SigninHandler(IUserRepository userRepository, IPasswordService passwordService, IJwtService jwtService)
    {
        _userRepository = userRepository;
        _passwordService = passwordService;
        _jwtService = jwtService;
    }
    
    public async Task<SigninUserResponse> Handle(SigninUser request, CancellationToken cancellationToken)
    {
        // ToDo: Add custom exception
        var user = await _userRepository.GetByEmail(new EmailAddress(request.Email), cancellationToken) ??
            throw new ArgumentException("Email or password are incorrect.");

        //var hashPassword = _passwordService.EncryptPassword(request.Password);
        //var userHasValidPassword = _passwordService.VerifyPassword(hashPassword, user.Password.Value);

        if (request.Password != user.Password.Value)
        {
            // ToDo: Add custom exception
            throw new ArgumentException("Email or password are invalid.");
        }

        var token = _jwtService.GenerateToken(user);

        return new(token);
    }
}