using System.ComponentModel.DataAnnotations;

namespace hefth.data.DTO
{
    public class NewUserDto
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
        [Required, EmailAddress]
        public string Email { get; set; }

    }
}
