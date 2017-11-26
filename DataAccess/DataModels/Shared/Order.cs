using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class Order
    {
        public int OrderId { get; set; }
        public int CartId { get; set; }
        public int BuyerId { get; set; }
        public bool Delivered { get; set; }

        public Order()
        {
            this.Delivered = false;
        }
    }
}
