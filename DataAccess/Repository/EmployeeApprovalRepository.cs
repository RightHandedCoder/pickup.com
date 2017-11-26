using DataAccess.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
   public class EmployeeApprovalRepository : IEmployeeApprovalRepository
    {
        DBContext context = Context.GetContext();

        public int Delete(int id)
        {
            EmployeeApproval employeeApprovalToDelete = context.EmployeeApprovals.SingleOrDefault(a => a.Id == id);
            context.EmployeeApprovals.Remove(employeeApprovalToDelete);

            return context.SaveChanges();
        }

        public EmployeeApproval Get(int id)
        {
            return context.EmployeeApprovals.SingleOrDefault(a => a.Id == id);
        }

        public List<EmployeeApproval> GetAll()
        {
            return context.EmployeeApprovals.ToList();
        }

        public int Insert(EmployeeApproval EmployeeApproval)
        {
            context.EmployeeApprovals.Add(EmployeeApproval);

            return context.SaveChanges();
        }

        public int Update(EmployeeApproval employeeApproval)
        {
            EmployeeApproval employeeApprovalToUpdate = context.EmployeeApprovals.SingleOrDefault(a => a.Id == employeeApproval.Id);
            employeeApprovalToUpdate.Status = employeeApproval.Status;

            return context.SaveChanges();
        }
    }
}
