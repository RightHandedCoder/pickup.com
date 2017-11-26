using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository.Interfaces
{
    interface ISellerRepository
    {
        List<Seller> GetAll();
        Seller Get(int id);
        Seller GetByLogin(int id);
        int Insert(Seller seller);
        int Update(Seller seller);
        int Delete(int id);
    }
}
