using DataAccess.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class DepartmentRepository : IDepartmentRepository
    {
        DBContext context = Context.GetContext();

        public int Delete(int id)
        {
            Department deptToDelete = context.Departments.SingleOrDefault(d => d.Id == id);
            context.Departments.Remove(deptToDelete);

            return context.SaveChanges();
        }

        public Department Get(int id)
        {
            return context.Departments.SingleOrDefault(d => d.Id == id);
        }

        public List<Department> GetAll()
        {
            return context.Departments.ToList();
        }

        public int Insert(Department dept)
        {
            context.Departments.Add(dept);

            return context.SaveChanges();
        }

        public int Update(Department dept)
        {
            Department deptToUpdate = context.Departments.SingleOrDefault(d => d.Id == dept.Id);
            deptToUpdate.Name = dept.Name;

            return context.SaveChanges();
        }
    }
}
