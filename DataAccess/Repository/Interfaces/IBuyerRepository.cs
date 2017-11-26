using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository.Interfaces
{
    interface IBuyerRepository
    {
        List<Buyer> GetAll();
        Buyer Get(int id);
        Buyer GetByLogin(int id);
        int Insert(Buyer buyer);
        int Update(Buyer buyer);
        int Delete(int id);
    }
}
