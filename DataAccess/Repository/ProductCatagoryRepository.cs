using DataAccess.Repository.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Repository
{
    public class ProductCatagoryRepository : ICatagoryRepository
    {
        DBContext context = Context.GetContext();

        public int Delete(int id)
        {
            ProductCatagory catagoryToDelete = context.Catagories.SingleOrDefault(c => c.Id == id);
            context.Catagories.Remove(catagoryToDelete);

            return context.SaveChanges();
        }

        public ProductCatagory Get(int id)
        {
            return context.Catagories.SingleOrDefault(c => c.Id == id);
        }

        public List<ProductCatagory> GetAll()
        {
            return context.Catagories.ToList();
        }

        public int Insert(ProductCatagory catagory)
        {
            context.Catagories.Add(catagory);

            return context.SaveChanges();
        }

        public int Update(ProductCatagory catagory)
        {
            ProductCatagory catagoryToUpdate = context.Catagories.SingleOrDefault(c => c.Id == catagory.Id);
            catagoryToUpdate.Name = catagory.Name;

            return context.SaveChanges();

        }
    }
}
