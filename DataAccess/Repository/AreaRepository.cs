using DataAccess.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class AreaRepository : IAreaRepository
    {
        DBContext context = Context.GetContext();

        public int Delete(int id)
        {
            Area areaToDelete = context.Areas.SingleOrDefault(a => a.Id == id);
            context.Areas.Remove(areaToDelete);

            return context.SaveChanges();
        }

        public Area Get(int id)
        {
            return context.Areas.SingleOrDefault(a => a.Id == id);
        }

        public List<Area> GetAll()
        {
            return context.Areas.ToList();
        }

        public int Insert(Area area)
        {
            context.Areas.Add(area);

            return context.SaveChanges();
        }

        public int Update(Area area)
        {
            Area areaToUpdate = context.Areas.SingleOrDefault(a => a.Id == area.Id);
            areaToUpdate.Name = area.Name;

            return context.SaveChanges();
        }
    }
}
