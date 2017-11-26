using DataAccess.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class SellerLoginRepository : ISellerLoginRepository
    {
        DBContext context = Context.GetContext();

        public int Delete(int id)
        {
            SellerLogin loginToDelete = context.SellerLogins.SingleOrDefault(l => l.Id == id);
            context.SellerLogins.Remove(loginToDelete);

            return context.SaveChanges();
        }

        public SellerLogin Get(int id)
        {
            return context.SellerLogins.SingleOrDefault(l => l.Id == id);
        }

        public List<SellerLogin> GetAll()
        {
            return context.SellerLogins.ToList();
        }

        public int Insert(SellerLogin credential)
        {
            context.SellerLogins.Add(credential);

            return context.SaveChanges();
        }

        public SellerLogin Match(SellerLogin credential)
        {
            SellerLogin credentialFromDB = context.SellerLogins.SingleOrDefault(c => c.Username == credential.Username && c.Password == credential.Password);

            return credentialFromDB;
        }

        public int Update(SellerLogin credential)
        {
            SellerLogin credentialToUpdate = context.SellerLogins.SingleOrDefault(c => c.Id == credential.Id);
            credentialToUpdate.Username = credential.Username;
            credentialToUpdate.Password = credential.Password;

            return context.SaveChanges();

        }
    }
}
