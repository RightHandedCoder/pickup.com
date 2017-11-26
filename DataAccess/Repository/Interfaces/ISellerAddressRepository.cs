using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository.Interfaces
{
    interface ISellerAddressRepository
    {
        List<SellerAddress> GetAll();
        SellerAddress Get(int id);
        int Insert(SellerAddress address);
        int Update(SellerAddress address);
        int Delete(int id);
    }
}
