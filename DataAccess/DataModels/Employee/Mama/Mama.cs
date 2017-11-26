using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class Mama : Employee
    {
        public int Id { get; set; }
        public WorkingArea DeliveryArea { get; set; }
    }
}
