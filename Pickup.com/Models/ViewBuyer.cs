using DataAccess;
using System.ComponentModel.DataAnnotations;

namespace Pickup.com.Models
{
    public class ViewBuyer
    {
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Email { get; set; }

        public string Phone { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        public string House { get; set; }
        public string Block { get; set; }
        public string Road { get; set; }
        [Required]
        public int Area { get; set; }
        [Required]
        public int City { get; set; }
    }
}