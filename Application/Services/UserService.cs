using Balance_API.Application.Interfaces;
using Balance_API.Application.Models;
using Balance_API.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace Balance_API.Application.Services
{
    public class UserService : IUserService
    {
        private readonly UserRepository _userRepository;
        private readonly IPasswordHasher<User> _passwordHasher;
        private readonly ITokenService _tokenService;
        public UserService(UserRepository userRepository,IPasswordHasher<User> passwordHasher,ITokenService tokenService)
        {
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
            _tokenService = tokenService;
        }
       
        public async Task<User> Register(RegisterDto Dto)
        {
            if (await _userRepository.GetByEmailAsync(Dto.Email) != null)
            {
                throw new Exception($"this email is already used : {Dto.Email}");
            }
            var user =new User { 
            Email = Dto.Email,
            Name = Dto.Name,
            };
            user.Password = _passwordHasher.HashPassword(user, Dto.Password);

           await _userRepository.AddAsync(user);

            return user;
        }
        public async Task<string> Login(LoginDto Dto)
        {
            var user= await _userRepository.GetByEmailAsync(Dto.Email);
            if (user == null)
            {
                throw new Exception($"user not found : {Dto.Email}");
            }
            var resultat = _passwordHasher.VerifyHashedPassword(user, user.Password, Dto.Password);
            if (resultat== PasswordVerificationResult.Failed)
            {
                throw new Exception($"Failed to login : incorrect password");
            }
            return _tokenService.GenerateToken(user);
        }
    }
}
