using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    class WorkingAreaRepository
    {
        DBContext context = Context.GetContext();

        public int Delete(int id)
        {
            WorkingArea workingAreaToDelete = context.WorkingAreas.SingleOrDefault(a => a.Id == id);
            context.WorkingAreas.Remove(workingAreaToDelete);

            return context.SaveChanges();
        }

        public WorkingArea Get(int id)
        {
            return context.WorkingAreas.SingleOrDefault(a => a.Id == id);
        }

        public List<WorkingArea> GetAll()
        {
            return context.WorkingAreas.ToList();
        }

        public int Insert(WorkingArea workingArea)
        {
            context.WorkingAreas.Add(workingArea);

            return context.SaveChanges();
        }

        public int Update(WorkingArea workingArea)
        {
            WorkingArea workingAreaToUpdate = context.WorkingAreas.SingleOrDefault(a => a.Id == workingArea.Id);
            workingAreaToUpdate.Area = workingArea.Area;
            workingAreaToUpdate.City = workingArea.City;

            return context.SaveChanges();
        }
    }
}
