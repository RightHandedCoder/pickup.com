using DataAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Pickup.com.Models
{
    public class ViewProduct
    {
        public int Id { get; set; }
  
        public string Name { get; set; }
    
        public double Price { get; set; }
   
        public int CatagoryId { get; set; }
 
        public ProductCatagory Catagory { get; set; }
        
    }
}