using System.ComponentModel.DataAnnotations;

namespace DataAccess
{
    public class BuyerAddress : Address
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string House { get; set; }
        public string Block { get; set; }
        public string Road { get; set; }

    }
}
