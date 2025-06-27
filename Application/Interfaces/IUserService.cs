using Balance_API.Application.Models;
using Balance_API.Domain.Entities;

namespace Balance_API.Application.Interfaces
{
    public interface IUserService
    {
        public Task Register(RegisterDto Dto);
        public Task<string> Login(LoginDto Dto);
    }
}
