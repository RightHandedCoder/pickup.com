using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository.Interfaces
{
    interface IAdminRepository
    {
        List<Admin> GetAll();
        Admin Get(int id);
        Admin GetByLogin(int id);
        int Insert(Admin admin);
        int Update(Admin admin);
        int Delete(int id);
    }
}
