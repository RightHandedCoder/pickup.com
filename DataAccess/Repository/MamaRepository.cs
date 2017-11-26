using DataAccess.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class MamaRepository : IMamaRepository
    {
        DBContext context = Context.GetContext();

        public int Delete(int id)
        {
            Mama mamaToDelete = context.Mamas.SingleOrDefault(a => a.Id == id);
            context.Mamas.Remove(mamaToDelete);

            return context.SaveChanges();
        }

        public Mama Get(int id)
        {
            return context.Mamas.SingleOrDefault(a => a.Id == id);
        }

        public Mama GetByLogin(int id)
        {
            Mama mama = context.Mamas.SingleOrDefault(a => a.LoginData.Id == id);

            return mama;
        }

        public List<Mama> GetAll()
        {
            return context.Mamas.ToList();
        }

        public int Insert(Mama mama)
        {
            context.Mamas.Add(mama);

            return context.SaveChanges();
        }

        public int Update(Mama mama)
        {
            Mama mamaToUpdate = context.Mamas.SingleOrDefault(a => a.Id == mama.Id);

            return context.SaveChanges();
        }
    }
}
