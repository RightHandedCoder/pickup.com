using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess
{
    public class ProductCart
    {
        [Key]
        public int CartId { get; set; }
        public string OrderTime { get; set; }
        public List<int> ProductId { get; set; }
        [ForeignKey("ProductId")]
        public List<Product> ProductList { get; set; }
        public int BuyerId { get; set; }

        [ForeignKey("BuyerId")]
        public Buyer Buyer { get; set; }

        public ProductCart()
        {
            this.ProductId = new List<int>();
            this.ProductList = new List<Product>();
        }
    }
}
