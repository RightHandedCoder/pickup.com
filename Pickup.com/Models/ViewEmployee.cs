using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Pickup.com.Models
{
    public class ViewEmployee
    {
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required]
        public int DepartmentName { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        public string HouseNo { get; set; }
        public string RoadNo { get; set; }
        [Required]
        public int AreaName { get; set; }
        [Required]
        public int CityName { get; set; }
        [Required]
        public DateTime DateOfBirth { get; set; }
        [Required]
        public DateTime JoiningDate { get; set; }
        [Required]
        public string JobType { get; set; }
        [Required]
        public double Salary { get; set; }

    }
}