using System.ComponentModel.DataAnnotations;

namespace DataAccess
{
    public class SellerAddress : Address
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string ShopName { get; set; }
    }
}
