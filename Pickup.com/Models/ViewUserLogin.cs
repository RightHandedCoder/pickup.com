using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Pickup.com.Models
{
    public class ViewUserLogin
    {
        public int Id { get; set; }
        [Required,MinLength(1)]
        public string Username { get; set; }
        [Required,MinLength(1)]
        public string Password { get; set; }
        public bool Remember { get; set; }
    }
}