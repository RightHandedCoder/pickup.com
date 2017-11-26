using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository.Interfaces
{
    interface ISellerLoginRepository
    {
        List<SellerLogin> GetAll();
        SellerLogin Get(int id);
        int Insert(SellerLogin credential);
        int Update(SellerLogin credential);
        SellerLogin Match(SellerLogin credential);
        int Delete(int id);
    }
}
