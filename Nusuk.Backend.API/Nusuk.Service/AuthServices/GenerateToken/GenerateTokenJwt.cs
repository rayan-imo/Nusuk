using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Nusuk.Services.AuthServices.Helper;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Nusuk.Services.AuthServices.GenerateToken;

public class GenerateTokenJwt(IOptions<JWT> _jwt) :IGenerateTokenJwt
{
    public string GenerateAccessToken(Guid userId, Guid role,string Name, string? email = null)
    {
        //  var secret = configuration.GetSection("JWT").Get<JWT>();

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwt.Value.Secret));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var claims = new List<Claim>
        {
            new(JwtRegisteredClaimNames.Sub, userId.ToString()),
            new(JwtRegisteredClaimNames.Sub, Name),
            new("RoleId" , role.ToString()),

        };

        if (!string.IsNullOrWhiteSpace(email))
        {
            claims.Add(new Claim(JwtRegisteredClaimNames.Email, email));
        }

        var token = new JwtSecurityToken(
            claims: claims,
            expires: DateTime.UtcNow.AddDays(_jwt.Value.DurationInDays),
            signingCredentials: creds);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
