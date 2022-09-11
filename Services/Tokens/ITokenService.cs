using ManagementSchool.Data.Entities;

namespace ManagementSchool.Services.Tokens
{
  public interface ITokenService
  {
    string GeneratorToken(AppUser user);
  }
}