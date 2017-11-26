using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess
{
    public class Buyer : User
    {
        [Key]
        public int BuyerId { get; set; }
        public BuyerLogin LoginData { get; set; }
        public BuyerAddress Address { get; set; }
        public int ApprovalId { get; set; }

        [ForeignKey("ApprovalId")]
        public BuyerApproval Approval { get; set; }
    }
}

