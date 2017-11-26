﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class BuyerLogin : Login
    {
        public int Id { get; set; }
        public string UserType { get; }

        public BuyerLogin()
        {
            this.UserType = "Buyer";
        }
    }
}
