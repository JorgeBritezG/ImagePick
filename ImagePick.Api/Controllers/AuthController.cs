using ImagePick.Api.Models.Auth;
using ImagePick.Application.Contracts.Models;
using ImagePick.Application.Contracts.Services;
using ImagePick.DataAccess.Contracts.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ImagePick.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Authorize]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;

        public AuthController(IUserService userService)
        {
            _userService = userService;
        }

        [AllowAnonymous]
        [HttpPost("googleauthenticate")]
        public async Task<IActionResult> GoogleAuthenticate( [FromBody] GoogleUserRequest request )
        {
            try
            {
                if ( !ModelState.IsValid )
                    return BadRequest(ModelState.Values.SelectMany(it => it.Errors).Select(it => it.ErrorMessage));

                return Ok(GenerateUserToken(await _userService.AuthenticateGoogleUserAsync(request)));
            }
            catch ( Exception ex )
            {
                return Conflict(ex.Message);
                throw;
            }
        }

        #region Private Methods
        private UserToken GenerateUserToken( UserApplication user )
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            var key = Encoding.ASCII.GetBytes(Startup.StaticConfig[ "Authentication:Jwt:Secret" ]);

            var expires = DateTime.UtcNow.AddDays(7);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, user.Id) ,
                    new Claim(JwtRegisteredClaimNames.Sub, Startup.StaticConfig["Authentication:Jwt:Subject"]),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                    new Claim(ClaimTypes.Name, user.Id),
                    new Claim(ClaimTypes.Surname, user.FirstName),
                    new Claim(ClaimTypes.GivenName, user.LastName),
                    new Claim(ClaimTypes.NameIdentifier, user.UserName),
                    new Claim(ClaimTypes.Email, user.Email)
                }),

                Expires = expires,

                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
                Issuer = Startup.StaticConfig[ "Authentication:Jwt:Issuer" ],
                Audience = Startup.StaticConfig[ "Authentication:Jwt:Audience" ]
            };

            var securityToken = tokenHandler.CreateToken(tokenDescriptor);

            var token = tokenHandler.WriteToken(securityToken);

            return new UserToken
            {
                UserId = user.Id,
                Email = user.Email,
                Token = token,
                Expires = expires
            };
        }
        #endregion
    }
}
