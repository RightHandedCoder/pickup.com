using DataAccess.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class AdminRepository : IAdminRepository
    {
        DBContext context = Context.GetContext();

        public int Delete(int id)
        {
            Admin adminToDelete = context.Admins.SingleOrDefault(a => a.Id == id);
            context.Admins.Remove(adminToDelete);

            return context.SaveChanges();
        }

        public Admin Get(int id)
        {
            return context.Admins.SingleOrDefault(a => a.Id == id);
        }

        public Admin GetByLogin(int id)
        {
            Admin admin = context.Admins.SingleOrDefault(a => a.LoginData.Id == id);

            return admin;
        }

        public List<Admin> GetAll()
        {
            return context.Admins.ToList();
        }

        public int Insert(Admin admin)
        {
            context.Admins.Add(admin);

            return context.SaveChanges();
        }

        public int Update(Admin admin)
        {
            Admin adminToUpdate = context.Admins.SingleOrDefault(a => a.Id == admin.Id);
            adminToUpdate.Email = admin.Email;
            adminToUpdate.HouseNo = admin.HouseNo;
            adminToUpdate.Phone = admin.Phone;
            adminToUpdate.RoadNo = admin.RoadNo;

            return context.SaveChanges();
        }
    }
}
