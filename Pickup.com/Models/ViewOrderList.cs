using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pickup.com.Models
{
    public class ViewOrderList
    {
        public int Id { get; set; }
        public string BuyerName { get; set; }
        public string OrderDate { get; set; }
        public string DeliveryStatus { get; set; }

    }
}