using DapperWithJWT.DTOs;
using DapperWithJWT.Models;

namespace DapperWithJWT.Repository
{
    public interface IUserRepository
    {
        Task<List<User>> Get();

        Task<User> Register(UserDto userDto);

        Task<UserDto> GetByUserName(LoginDto loginDto);
    }
}
