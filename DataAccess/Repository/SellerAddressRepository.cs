using DataAccess.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class SellerAddressRepository : ISellerAddressRepository
    {
        DBContext context = Context.GetContext();

        public int Delete(int id)
        {
            SellerAddress addressToDelete = context.SellerAddresses.SingleOrDefault(a => a.Id == id);
            context.SellerAddresses.Remove(addressToDelete);

            return context.SaveChanges();

        }

        public SellerAddress Get(int id)
        {
            return context.SellerAddresses.SingleOrDefault(a => a.Id == id);
        }

        public List<SellerAddress> GetAll()
        {
            return context.SellerAddresses.ToList();
        }

        public int Insert(SellerAddress address)
        {
            context.SellerAddresses.Add(address);

            return context.SaveChanges();
        }

        public int Update(SellerAddress address)
        {
            SellerAddress addressToUpdate = context.SellerAddresses.SingleOrDefault(a => a.Id == address.Id);
            addressToUpdate.ShopName = address.ShopName;
            addressToUpdate.Area = context.Areas.SingleOrDefault(a=>a.Id==address.AreaId);
            addressToUpdate.City = context.Cities.SingleOrDefault(a => a.Id == address.CityId);

            return context.SaveChanges();
        }
    }
}
