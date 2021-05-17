using Holidays.Services.DTO;
using Holidays.Services.Interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Holidays.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class LoginController : ControllerBase
    {
        private readonly IUserAppService _userAppService;
        private readonly IJwtAuthManager _jwtAuthManager;

        public LoginController(IUserAppService userAppService, IJwtAuthManager jwtAuthManager)
        {
            _userAppService = userAppService;
            _jwtAuthManager = jwtAuthManager;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] UserDTO userDTO)
        {
            var user = await _userAppService.GetAsync(userDTO.Login, userDTO.Password);

            if (user == null) return Unauthorized();

            var claims = new[]
            {
                new Claim(ClaimTypes.Name, user.Login),
                new Claim(ClaimTypes.Role, "Admin")
            };

            var jwtResult = _jwtAuthManager.GenerateTokens(user.Login, claims, DateTime.Now);

            return Ok(new
            {
                UserName = userDTO.Login,
                Role = "Admin",
                AccessToken = jwtResult.AccessToken,
                RefreshToken = jwtResult.RefreshToken.TokenString
            });
        }
    }
}
