using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository.Interfaces
{
    interface IBuyerAddressRepository
    {
        List<BuyerAddress> GetAll();
        BuyerAddress Get(int id);
        int Insert(BuyerAddress address);
        int Update(BuyerAddress address);
        int Delete(int id);
    }
}
