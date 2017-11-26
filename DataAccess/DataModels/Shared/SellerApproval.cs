using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class SellerApproval
    {
        public int Id { get; set; }
        public bool Status { get; set; }

        public SellerApproval()
        {
            this.Status = false;
        }
    }
}
