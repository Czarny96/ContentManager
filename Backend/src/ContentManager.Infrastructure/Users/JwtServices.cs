using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using ContentManager.Application.Users;
using ContentManager.Domain.Users;
using ContentManager.Rest.Api.Options;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace ContentManager.Infrastructure.Users;

internal class JwtServices : IJwtService
{
    private readonly JwtOptions _jwtOptions;

    public JwtServices(IOptions<JwtOptions> jwtOptions)
    {
        _jwtOptions = jwtOptions.Value;
    }
    
    public string GenerateToken(User user)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(_jwtOptions.Secret);
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new[]
            {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Sub, user.Email.Email),
                new Claim("id", user.Id.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email.Email)
            }),
            Expires = DateTime.UtcNow.AddHours(1), // ToDo: Add abstraction for date
            SigningCredentials =
                new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };

        var token = tokenHandler.CreateToken(tokenDescriptor);
        
        return tokenHandler.WriteToken(token);
    }
}