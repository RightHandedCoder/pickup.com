using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Repository
{
    public class EmployeeLoginRepository
    {
        DBContext context = Context.GetContext();

        public int Delete(int id)
        {
            EmployeeLogin EmployeeLoginToDelete = context.EmployeeLogins.SingleOrDefault(a => a.Id == id);
            context.EmployeeLogins.Remove(EmployeeLoginToDelete);

            return context.SaveChanges();
        }

        public EmployeeLogin Get(int id)
        {
            return context.EmployeeLogins.SingleOrDefault(a => a.Id == id);
        }

        public EmployeeLogin Match(EmployeeLogin credential)
        {
            EmployeeLogin credentialFromDB = context.EmployeeLogins.SingleOrDefault(e => e.Username == credential.Username && e.Password == credential.Password);

            return credentialFromDB;
        }

        public List<EmployeeLogin> GetAll()
        {
            return context.EmployeeLogins.ToList();
        }

        public int Insert(EmployeeLogin employeeLogin)
        {
            context.EmployeeLogins.Add(employeeLogin);

            return context.SaveChanges();
        }

        public int Update(EmployeeLogin employeeLogin)
        {
            EmployeeLogin employeeLoginToUpdate = context.EmployeeLogins.SingleOrDefault(a => a.Id == employeeLogin.Id);
            employeeLoginToUpdate.Password = employeeLogin.Password;
            employeeLoginToUpdate.Username = employeeLogin.Username;

            return context.SaveChanges();
        }
    }
}

