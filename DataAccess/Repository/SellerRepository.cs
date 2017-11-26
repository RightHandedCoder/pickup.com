using DataAccess.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class SellerRepository : ISellerRepository
    {
        DBContext context = Context.GetContext();

        public int Delete(int id)
        {
            Seller sellerToDelete = context.Sellers.SingleOrDefault(s => s.SellerId == id);
            context.Sellers.Remove(sellerToDelete);

            return context.SaveChanges();
        }

        public Seller Get(int id)
        {
            return context.Sellers.SingleOrDefault(s => s.SellerId == id);
        }

        public List<Seller> GetAll()
        {
            return context.Sellers.ToList();
        }

        public Seller GetByLogin(int id)
        {
            Seller seller = context.Sellers.SingleOrDefault(c => c.LoginData.Id == id);

            return seller;
        }

        public int Insert(Seller seller)
        {
            context.Sellers.Add(seller);

            return context.SaveChanges();
        }

        public int Update(Seller seller)
        {
            Seller sellerToUpdate = context.Sellers.SingleOrDefault(b => b.SellerId == seller.SellerId);
            sellerToUpdate.Phone = seller.Phone;
            sellerToUpdate.Email = seller.Email;

            return context.SaveChanges();
        }
    }
}
