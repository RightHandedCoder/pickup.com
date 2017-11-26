using DataAccess.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class OrderRepository : IOrderRepository
    {
        DBContext context = Context.GetContext();

        public int Delete(int id)
        {
            Order order = context.Orders.SingleOrDefault(o => o.OrderId == id);
            context.Orders.Remove(order);

            return context.SaveChanges();
        }

        public Order Get(int id)
        {
            return context.Orders.SingleOrDefault(o => o.OrderId == id);
        }

        public List<Order> GetAll()
        {
            return context.Orders.ToList();
        }

        public int Insert(Order order)
        {
            context.Orders.Add(order);

            return context.SaveChanges();
        }
    }
}
