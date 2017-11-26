using DataAccess.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class BuyerAddressRepository : IBuyerAddressRepository
    {
        DBContext context = Context.GetContext();

        public int Delete(int id)
        {
            BuyerAddress addressToDelete = context.BuyerAddresses.SingleOrDefault(a => a.Id == id);
            context.BuyerAddresses.Remove(addressToDelete);

            return context.SaveChanges();

        }

        public BuyerAddress Get(int id)
        {
            return context.BuyerAddresses.SingleOrDefault(a => a.Id == id);
        }

        public List<BuyerAddress> GetAll()
        {
            return context.BuyerAddresses.ToList();
        }

        public int Insert(BuyerAddress address)
        {
            context.BuyerAddresses.Add(address);

            return context.SaveChanges();
        }

        public int Update(BuyerAddress address)
        {
            BuyerAddress addressToUpdate = context.BuyerAddresses.SingleOrDefault(a => a.Id == address.Id);
            addressToUpdate.Area = address.Area;
            addressToUpdate.City = address.City;
            addressToUpdate.Block = address.Block;
            addressToUpdate.House = address.House;
            addressToUpdate.Road = address.Road;

            return context.SaveChanges();
        }
    }
}
