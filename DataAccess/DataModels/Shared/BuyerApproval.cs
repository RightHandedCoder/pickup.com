﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class BuyerApproval
    {
        [Key]
        public int Id { get; set; }
        public bool Status { get; set; }

        public BuyerApproval()
        {
            this.Status = false;
        }
    }
}
