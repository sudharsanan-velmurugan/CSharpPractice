using Dapper;
using DapperWithJWT.DTOs;
using DapperWithJWT.Models;
using DapperWithJWT.Repository;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.IdentityModel.Tokens;
using Npgsql;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace DapperWithJWT.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _repo;
        private readonly JwtSettings _jwtSettings;


        public AuthService(IUserRepository repo, JwtSettings jwtSettings)
        {

            _repo = repo;
            _jwtSettings = jwtSettings;
        }

        public async Task<LoginResponceDto> Login(LoginDto loginDto)
        {
            if (loginDto.UserName == null || loginDto.Password == null)
                return null;

            var userExists = await _repo.GetByUserName(loginDto);


            if (userExists == null)
                return null;

            if (userExists.Password == loginDto.Password)
            {
                var responce = new LoginResponceDto
                {
                    AccessToken = GenerateToken(userExists)
                };

                return responce;
            }
            return null;


        }


        private string GenerateToken(UserDto user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name,user.UserName),
                new Claim(ClaimTypes.Role,user.Role)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.SecurityKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(

                issuer: _jwtSettings.Issuer,
                audience: _jwtSettings.Audience,
                claims,
                notBefore: DateTime.UtcNow,
                expires: DateTime.UtcNow.AddMinutes(_jwtSettings.ExpiryTime),
                signingCredentials: creds
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
