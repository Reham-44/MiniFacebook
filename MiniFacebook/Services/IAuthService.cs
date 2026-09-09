using Microsoft.Identity.Client.NativeInterop;
using MiniFacebook.DTOs;
using MiniFacebook.Models;

namespace MiniFacebook.Services
{
    public interface IAuthService
    {
        Task<AuthResultDTO> RegisterAsync(UserRegisterDTO dto);

        Task<AuthResultDTO> LoginAsync(UserLoginDTO dto);
    }
}
