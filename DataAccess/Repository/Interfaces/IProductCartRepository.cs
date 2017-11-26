using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository.Interfaces
{
    interface IProductCartRepository
    {
        List<ProductCart> GetAll();
        ProductCart Get(int id);
        int Insert(ProductCart cart);
        int Delete(int id);
    }
}
