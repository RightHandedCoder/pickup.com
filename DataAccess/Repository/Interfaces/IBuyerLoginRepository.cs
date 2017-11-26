using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository.Interfaces
{
    interface IBuyerLoginRepository
    {
        List<BuyerLogin> GetAll();
        BuyerLogin Get(int id);
        int Insert(BuyerLogin credential);
        int Update(BuyerLogin credential);
        BuyerLogin Match(BuyerLogin credential);
        int Delete(int id);
    }
}
