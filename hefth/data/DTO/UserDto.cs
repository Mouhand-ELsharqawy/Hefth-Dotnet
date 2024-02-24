using System.ComponentModel.DataAnnotations;

namespace hefth.data.DTO
{
    public class UserDto
    {
        [Required, MaxLength(50)]
        public string Name { get; set; }
        [Required,EmailAddress]
        public string Email { get; set; }
        [Required, MaxLength(50)]
        public string Password { get; set; }
        [Required, MaxLength(50)]
        public string ConfirmedPassword { get; set; }
    }
}
