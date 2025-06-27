using Balance_API.Domain.Entities;

namespace Balance_API.Application.Interfaces
{
    public interface ITokenService
    {
      public string GenerateToken(User user);
    }
}