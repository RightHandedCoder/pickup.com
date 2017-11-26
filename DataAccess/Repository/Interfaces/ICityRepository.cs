using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository.Interfaces
{
    interface ICityRepository
    {
        List<City> GetAll();
        City Get(int id);
        int Insert(City city);
        int Update(City city);
        int Delete(int id);
    }
}
