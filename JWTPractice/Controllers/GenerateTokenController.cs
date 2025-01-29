using JWTPractice.JWT;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using JwtRegisteredClaimNames = System.IdentityModel.Tokens.Jwt.JwtRegisteredClaimNames;

namespace JWTPractice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenerateTokenController : ControllerBase
    {
        private readonly JwtSettings _jwtSettings;

        public GenerateTokenController(JwtSettings jwtSettings)
        {
            _jwtSettings = jwtSettings;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var claims = new Claim[]
            {
                new Claim(JwtRegisteredClaimNames.Aud,"test"),
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString())
            };

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.SecurityKey));
            var signCred = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                issuer: _jwtSettings.Issuer,
                audience: _jwtSettings.Audience,
                claims: claims,
                expires: DateTime.Now.AddMinutes(_jwtSettings.ExpiryTime),
                signingCredentials: signCred
                );

            return Ok(new JwtSecurityTokenHandler().WriteToken(token));
        }
    }
}
