using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartEssentials.Entities.Contracts;
using SmartEssentials.Entities.Core;
using SmartEssentials.Entities.DTO;
using SmartEssentials.Repositories;
using SmartEssentials.WebApi.Auth;

namespace SmartEssentials.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private ITokenProvider _tokenProvider { get; set; }
        public AuthController(ITokenProvider tokenProvider)
        {
            _tokenProvider = tokenProvider;
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public IActionResult Login([FromBody]JWTLoginRequest loginRequest)
        {
            (string token, User user) = _tokenProvider.LoginUser(loginRequest.username, loginRequest.password);

            if (token == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            return Ok(user);
        }
    }
}
