using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NuGet.Common;
using Sela.Task.API.Models.DTO;
using Sela.Task.API.Repositories.Interface;

namespace Sela.Task.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ITokenRepository tokenRepository;

        public AuthController(ITokenRepository tokenRepository)
        {
            this.tokenRepository = tokenRepository;
        }

        // POST: /api/Auth/Login
        [HttpPost]
        [Route("Login")]
        public IActionResult Login([FromBody] LoginRequestDto loginRequestDto)
        {
            //In actual scenaio this details would be validated with Database.

            //Also this controller may contain other API's to register user first into system.

            //For demo pupose of authentication flow direct creating token against any username and password.

            if (!string.IsNullOrEmpty(loginRequestDto.Username)
                && !string.IsNullOrEmpty(loginRequestDto.Password))
            {
                var jwtToken = tokenRepository.CreateJWTToken(loginRequestDto.Username);

                var tokenDetail = new TokenDetail(Token: jwtToken);

                return Ok(tokenDetail);
            }

            return BadRequest("Username or password incorrect");
        }

    }
}
