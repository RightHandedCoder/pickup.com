using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository.Interfaces
{
    interface IWorkingAreaRepository
    {
        List<WorkingArea> GetAll();
        WorkingArea Get(int id);
        int Insert(WorkingArea workingArea);
        int Update(WorkingArea workingArea);
        int Delete(int id);
    }
}
