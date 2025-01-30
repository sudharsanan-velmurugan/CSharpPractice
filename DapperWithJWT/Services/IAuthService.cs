using DapperWithJWT.DTOs;
using DapperWithJWT.Models;
using Microsoft.AspNetCore.Mvc;

namespace DapperWithJWT.Services
{
    public interface IAuthService
    {
        Task<LoginResponceDto> Login(LoginDto user);
    }
}
