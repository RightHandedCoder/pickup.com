using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess
{
    public class Product
    {
        public int ProductId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public double Price { get; set; }
        public int CatagoryId { get; set; }
        public int ApprovalId { get; set; }
        public int SellerId { get; set; }
        public List<int> CartId { get; set; }

        [ForeignKey("CartId")]
        public List<ProductCart> Cart { get; set; }
        [ForeignKey("CatagoryId")]
        public ProductCatagory Catagory { get; set; }
        [ForeignKey("ApprovalId")]
        public ProductApproval Approval { get; set; }
        [ForeignKey("SellerId")]
        public Seller Seller { get; set; }



    }
}
