using System.ComponentModel.DataAnnotations;

namespace DataAccess
{
    public abstract class User
    {
        [Required, MaxLength(20)]
        public string FirstName { get; set; }

        [Required, MaxLength(50)]
        public string LastName { get; set; }

        [Required, MaxLength(30)]
        public string Email { get; set; }

        [Required, MaxLength(14)]
        public string Phone { get; set; }

        [Required]
        public string Gender { get; set; }
    }
}
