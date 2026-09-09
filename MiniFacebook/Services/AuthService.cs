using Microsoft.Identity.Client.NativeInterop;
using Microsoft.IdentityModel.Tokens;
using MiniFacebook.DTOs;
using MiniFacebook.Models;
using MiniFacebook.Repositories;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AuthResult = MiniFacebook.DTOs.AuthResultDTO;

namespace MiniFacebook.Services
{
    public class AuthService : IAuthService
{
        readonly IUserRepo userRepo;
        IConfiguration configuration;
        public AuthService(IUserRepo _userRepo, IConfiguration _configuration)
        {
            userRepo = _userRepo;
            configuration = _configuration;
        }
       public async Task<AuthResult> RegisterAsync(UserRegisterDTO dto)
        {
         var emailExists = await userRepo.IsUserExistsByEmail (dto.Email);
            if (emailExists)
            {
                return new AuthResultDTO
                {
                    Message = "Email already exists.",
                    Success = false
                };
            }
            User user = new User()
            {
                Email = dto.Email,
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(dto.Password)
            };
            userRepo.AddAsync(user);

            return new AuthResultDTO
            {
                Success = true,
                Message = "Registration successfully."
            };
        }  
        
        
        public async Task<AuthResult> LoginAsync(UserLoginDTO dto)
        {
            var user = await userRepo.GetByEmailAsync(dto.Email);
            if (user==null || !BCrypt.Net.BCrypt.Verify(dto.Password, user.PasswordHash))
            {
                return new AuthResultDTO
                {
                    Message = "Invalid Email or password",
                    Success = false
                };
            }
            var token = GenerateJwtToken(user);


            return new AuthResultDTO
            {
                Success = true,
                Message = "login successfully.",
                Token = token
            };
        }

       private string GenerateJwtToken(User user)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Email, user.Email),
            };
            var key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(configuration["JWT:Key"])
                );
            var cred= new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                issuer: configuration["JWT:Issuer"],
                audience: configuration["JWT:Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(60),
                signingCredentials: cred
                );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

    }
}
