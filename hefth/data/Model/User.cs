using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace hefth.data.Model
{
    //[Index(nameof(Email), IsUnique = true)]
    public class User : IdentityUser
    {
        //[Key]
        //public int Id { get; set; }
        //[Required]
        //public string Name { get; set; }
        //[Required]
        //public string Email { get; set; }
        //[Required]
        //public string Password { get; set; }
        //[Required]
        //public string ConfirmedPassword { get; set; }
    }
}
