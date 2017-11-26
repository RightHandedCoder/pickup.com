using System.Collections.Generic;

namespace DataAccess.Repository.Interfaces
{
    interface IEmployeeLoginRepository
    {
        List<EmployeeLogin> GetAll();
        EmployeeLogin Get(int id);
        EmployeeLogin Match(EmployeeLogin credential);
        int Insert(EmployeeLogin employeeLogin);
        int Update(EmployeeLogin employeeLogin);
        int Delete(int id);
    }
}
