using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using ManagementSchool.Data.Entities;
using Microsoft.IdentityModel.Tokens;

namespace ManagementSchool.Services.Tokens
{
  public class TokenService : ITokenService
  {
    private IConfiguration _config;
    public TokenService(IConfiguration config) {
      _config = config;
    }
    public string GeneratorToken(AppUser user)
    {
      var claims = new[]
            {
                new Claim(ClaimTypes.Email,user.Email),
                new Claim(ClaimTypes.GivenName, user.Name),
                new Claim(ClaimTypes.Name, user.UserName)
            };
      Console.WriteLine(_config["Jwt:Key"]);
      var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
      var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

      var token = new JwtSecurityToken(_config["Jwt:Issuer"], _config["Jwt:Issuer"], claims, expires: DateTime.Now.AddMinutes(120), signingCredentials: credentials);
      return new JwtSecurityTokenHandler().WriteToken(token);
    }
  }
}