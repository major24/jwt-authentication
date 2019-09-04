using System;
using Microsoft.AspNetCore.Mvc;
using jwt_authentication.Services;
using jwt_authentication.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Configuration;

namespace jwt_authentication.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
      private IUserServiceV2 _userServiceV2;
      private IConfiguration _config;

      public AuthController(IUserServiceV2 userServiceV2,
        IConfiguration config)
      {
          _userServiceV2 = userServiceV2;
          _config = config;
      }

      [HttpPost]
      [Route("token")]
      public IActionResult CreateToken([FromBody]User userParam)
      {
          var user = _userServiceV2.FindByUserName(userParam.Username);

          if (user == null || user.Password != userParam.Password)
          {
            return BadRequest(new { message = "Username or password is incorrect" });
          }

          // claim
          var claims = new[]
          {
            new Claim(JwtRegisteredClaimNames.Sub, user.Username),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
          };

          var key = Encoding.ASCII.GetBytes(_config["Tokens:Secret"]);
          var creds = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature);

          // create jwt token
          var token = new JwtSecurityToken(
            issuer: _config["Tokens:Issuer"],
            audience: _config["Token:audience"],
            expires: DateTime.UtcNow.AddMinutes(1),
            claims: claims,
            signingCredentials: creds
          );

          // return annoy obj with token
          return Ok(new
            {
                token = new JwtSecurityTokenHandler().WriteToken(token),
                expiration = token.ValidTo
            });
      }

    }
}