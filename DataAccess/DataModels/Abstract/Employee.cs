using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess
{
    public abstract class Employee : User
    {
        [Required]
        public Department Department { get; set; }
        [Required]
        public string DateOfBirth { get; set; }
        [Required]
        public string JoiningDate { get; set; }
        [Required]
        public string JobType { get; set; }
        [Required]
        public double Salary { get; set; }
        [Required]
        public string HouseNo { get; set; }
        [Required]
        public string RoadNo { get; set; }
        public Area Area { get; set; }
        public City City { get; set; }
        public EmployeeLogin LoginData { get; set; }
        public int ApprovalId { get; set; }

        [ForeignKey("ApprovalId")]
        public EmployeeApproval Approval { get; set; }


    }
}
