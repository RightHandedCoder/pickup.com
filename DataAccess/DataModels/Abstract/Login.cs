using System.ComponentModel.DataAnnotations;

namespace DataAccess
{ 
    public abstract class Login
    {
        [Required, MaxLength(20)]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
