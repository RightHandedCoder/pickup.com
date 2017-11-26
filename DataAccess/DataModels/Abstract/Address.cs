using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess
{
    public abstract class Address
    {
        [Required]
        public int AreaId { get; set; }
        [Required]
        public int CityId { get; set; }
        
        [ForeignKey("AreaId")]
        public Area Area { get; set; }
        [ForeignKey("CityId")]
        public City City { get; set; }
    }
}
