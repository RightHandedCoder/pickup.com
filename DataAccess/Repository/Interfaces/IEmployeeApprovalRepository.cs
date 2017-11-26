using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository.Interfaces
{
    interface IEmployeeApprovalRepository
    {
        List<EmployeeApproval> GetAll();
        EmployeeApproval Get(int id);
        int Insert(EmployeeApproval approval);
        int Update(EmployeeApproval approval);
        int Delete(int id);
    }
}
