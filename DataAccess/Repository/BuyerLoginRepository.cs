using DataAccess.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class BuyerLoginRepository : IBuyerLoginRepository
    {
        DBContext context = Context.GetContext();

        public int Delete(int id)
        {
            BuyerLogin loginToDelete = context.BuyerLogins.SingleOrDefault(l => l.Id == id);
            context.BuyerLogins.Remove(loginToDelete);

            return context.SaveChanges();
        }

        public BuyerLogin Get(int id)
        {
            return context.BuyerLogins.SingleOrDefault(l => l.Id == id);
        }

        public List<BuyerLogin> GetAll()
        {
            return context.BuyerLogins.ToList();
        }

        public int Insert(BuyerLogin credential)
        {
            context.BuyerLogins.Add(credential);

            return context.SaveChanges();
        }

        public BuyerLogin Match(BuyerLogin credential)
        {
            BuyerLogin credentialFromDB = context.BuyerLogins.SingleOrDefault(c => c.Username == credential.Username && c.Password == credential.Password);

            return credentialFromDB;
        }

        public int Update(BuyerLogin credential)
        {
            BuyerLogin credentialToUpdate = context.BuyerLogins.SingleOrDefault(c => c.Id == credential.Id);
            credentialToUpdate.Username = credential.Username;
            credentialToUpdate.Password = credential.Password;

            return context.SaveChanges();

        }
    }
}
