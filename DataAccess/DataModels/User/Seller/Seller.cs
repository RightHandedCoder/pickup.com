using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess
{
    public class Seller : User
    {
        [Key]
        public int SellerId { get; set; }
        public int AddressId { get; set; }
        public int LoginId { get; set; }
        public int ApprovalId { get; set; }
        [ForeignKey("LoginId")]
        public SellerLogin LoginData { get; set; }
        [ForeignKey("AddressId")]
        public SellerAddress Address { get; set; }
        [ForeignKey("ApprovalId")]
        public SellerApproval Approval { get; set; }
    }
}
