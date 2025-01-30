using DapperWithJWT.DTOs;
using DapperWithJWT.Models;
using DapperWithJWT.Repository;
using DapperWithJWT.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DapperWithJWT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly IUserRepository _repo;

        public UserController(IAuthService authService, IUserRepository repo)
        {
            _authService = authService;
            _repo = repo;
        }
        [Authorize]
        [HttpGet]
        public async Task<ActionResult<List<User>>> Get()
        {
            var result = await _repo.Get();
            return Ok(result);
        }

        [HttpPost("register")]

        public async Task<IActionResult> Post(UserDto userDto)
        {
            await _repo.Register(userDto);

            return Ok(userDto);

        }

        [HttpGet("login")]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            var token= await _authService.Login(loginDto);

            if (token == null)
                return BadRequest("Username or Password is invalid");

            return Ok(token);
        }
    }
}
