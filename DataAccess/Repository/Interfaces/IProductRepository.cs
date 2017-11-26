using System.Collections.Generic;

namespace DataAccess.Repository.Interfaces
{
    interface IProductRepository
    {
        List<Product> GetAll();
        Product Get(int id);
        int Insert(Product product);
        int Update(Product product);
        bool GetApproval(int id);
        int UpdateApproval(int id, bool status);
        int Delete(int id);
    }
}
