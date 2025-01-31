using Dapper;
using DapperWithJWT.DTOs;
using DapperWithJWT.Models;
using Npgsql;

namespace DapperWithJWT.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly IConfiguration _configuration;

        public UserRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<List<UserDto>> Get()
        {
           using var _connection = GetConnection();
            var users= await _connection.QueryAsync<UserDto>("SELECT user_name AS \"UserName\",password AS \"Password\", role AS \"Role\"   FROM users");
            return users.ToList();
        }

        public async Task<UserDto?> GetByUserName(LoginDto loginDto)
        {
            using var _connection = GetConnection();
            var user = await _connection.QueryFirstOrDefaultAsync<UserDto>("SELECT user_name AS \"UserName\",password AS \"Password\",role AS \"Role\" FROM users WHERE user_name =@UserName", loginDto);
            return user;
        }

        public async Task<User?> Register(UserDto userDto)
        {
            var user = new User { UserName = userDto.UserName, Password = userDto.Password, Role = userDto.Role };

            using var _connection = GetConnection();

            await _connection.ExecuteAsync("INSERT INTO users (user_name,password,role) VALUES(@UserName,@Password,@Role)", user);

            return user;
        }

        private NpgsqlConnection GetConnection()
        {
            return new NpgsqlConnection(_configuration.GetConnectionString("postgres"));
        }
    }
}
