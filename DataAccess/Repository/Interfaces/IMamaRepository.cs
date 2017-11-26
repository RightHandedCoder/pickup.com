using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository.Interfaces
{
    interface IMamaRepository
    {
        List<Mama> GetAll();
        Mama Get(int id);
        Mama GetByLogin(int id);
        int Insert(Mama mama);
        int Update(Mama mama);
        int Delete(int id);
    }
}
