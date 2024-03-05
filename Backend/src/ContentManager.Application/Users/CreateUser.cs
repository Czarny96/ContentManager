using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using ContentManager.Domain;
using ContentManager.Domain.Users;
using ContentManager.Rest.Api.Options;
using MediatR;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
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
    private readonly JwtOptions _jwtOptions; 
    
    private readonly IUserRepository _userRepository;
    public CreateUserHandler(IOptions<JwtOptions> jwtOptions, IUserRepository userRepository)
    {
        _jwtOptions = jwtOptions.Value;
        _userRepository = userRepository;
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

        var newUser =
            new User(
                new UserId(),
                new EmailAddress(request.Email),
                new Password(request.Password, Guid.NewGuid())
            );

        // ToDo: Move generate token to infrastructure
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(_jwtOptions.Secret);
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new[]
            {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Sub, newUser.Email.Email),
                new Claim("id", newUser.Id.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Email, newUser.Email.Email)
            }),
            Expires = DateTime.UtcNow.AddHours(1), // ToDo: Add abstraction for date
            SigningCredentials =
                new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha512Signature)
        };

        var token = tokenHandler.CreateToken(tokenDescriptor);

        return new(tokenHandler.WriteToken(token));
    }
}