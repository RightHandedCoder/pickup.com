using DataAccess.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class BuyerRepository : IBuyerRepository
    {
        DBContext context = Context.GetContext();

        public int Delete(int id)
        {
            Buyer buyerToDelete = context.Buyers.SingleOrDefault(b => b.BuyerId == id);
            context.Buyers.Remove(buyerToDelete);

            return context.SaveChanges();
        }

        public Buyer Get(int id)
        {
            return context.Buyers.SingleOrDefault(b => b.BuyerId == id);
        }

        public List<Buyer> GetAll()
        {
            return context.Buyers.ToList();
        }

        public Buyer GetByLogin(int id)
        {
            Buyer buyer = context.Buyers.SingleOrDefault(b => b.LoginData.Id == id);

            return buyer;
        }

        public int Insert(Buyer buyer)
        {
            context.Buyers.Add(buyer);

            return context.SaveChanges();
        }

        public int Update(Buyer buyer)
        {
            Buyer buyerToUpdate = context.Buyers.SingleOrDefault(b => b.BuyerId == buyer.BuyerId);
            buyerToUpdate.FirstName = buyer.FirstName;
            buyerToUpdate.LastName = buyer.LastName;
            buyerToUpdate.Phone = buyer.Phone;
            buyerToUpdate.Email = buyer.Email;
            buyerToUpdate.Address = buyer.Address;
            buyerToUpdate.Gender = buyer.Gender;
            buyerToUpdate.LoginData = buyer.LoginData;

            return context.SaveChanges();
        }
    }
}
