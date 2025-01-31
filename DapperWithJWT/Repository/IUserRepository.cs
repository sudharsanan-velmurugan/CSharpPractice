using DapperWithJWT.DTOs;
using DapperWithJWT.Models;

namespace DapperWithJWT.Repository
{
    public interface IUserRepository
    {
        Task<List<UserDto>> Get();

        Task<User> Register(UserDto userDto);

        Task<UserDto> GetByUserName(LoginDto loginDto);
    }
}
