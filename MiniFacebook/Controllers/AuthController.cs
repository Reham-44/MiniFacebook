using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MiniFacebook.DTOs;
using MiniFacebook.Models;
using MiniFacebook.Services;

namespace MiniFacebook.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        readonly IAuthService authService;
        public AuthController(IAuthService _authService)
        {
            authService = _authService;
        }


        [HttpPost]
        public async Task<IActionResult> Register(UserRegisterDTO dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var res = await authService.RegisterAsync(dto);
            if(!res.Success)
            {
                return BadRequest("Email already exists");
            }
            return Created("User Created Successfully",res.Success);
        }


        [HttpPost]
        public async Task<IActionResult> Login(UserLoginDTO dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var loginResult = await authService.LoginAsync(dto);
            if (!loginResult.Success)
            {
                return Unauthorized("Invalid Email or Password");
            }
            return Ok(loginResult);
        }

    }
}
