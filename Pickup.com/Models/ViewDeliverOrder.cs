using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pickup.com.Models
{
    public class ViewDeliverOrder
    {
        public int Id { get; set; }
        public string BuyerName { get; set; }
        public string Address { get; set; }
        public int MamaId { get; set; }
    }
}