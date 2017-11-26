using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository.Interfaces
{
    interface IOrderRepository
    {
        List<Order> GetAll();
        Order Get(int id);
        int Insert(Order order);
        int Delete(int id);
    }
}
