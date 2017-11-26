using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository.Interfaces
{
    interface ICatagoryRepository
    {
        List<ProductCatagory> GetAll();
        ProductCatagory Get(int id);
        int Insert(ProductCatagory catagory);
        int Update(ProductCatagory catagory);
        int Delete(int id);
    }
}
