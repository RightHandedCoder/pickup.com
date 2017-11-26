using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pickup.com.Models
{
    public class ViewProductList
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Catagory { get; set; }
        public string SellerName { get; set; }
        public string ShopName { get; set; }
    }
}