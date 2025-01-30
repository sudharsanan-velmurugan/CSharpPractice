using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DapperWithJWT.DTOs
{
    [Table("users")]
    public class UserDto
    {
        [Required]
        [Column("user_name")]
        public string UserName { get; set; }

        [Required]
        [Column("password")]
        public string Password { get; set; }

        [Required]
        [Column("role")]
        public string Role { get; set; }
    }
}
