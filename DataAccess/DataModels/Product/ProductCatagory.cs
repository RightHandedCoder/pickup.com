using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess
{
    public class ProductCatagory
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public ProductCatagory()
        {

        }

        public ProductCatagory(string name)
        {
            this.Name = name;
        }
    }
}
