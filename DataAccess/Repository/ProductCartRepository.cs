using DataAccess.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class ProductCartRepository : IProductCartRepository
    {
        DBContext context = Context.GetContext();

        public int Delete(int id)
        {
            ProductCart cartToDelete = context.ProductCarts.SingleOrDefault(c => c.CartId == id);
            context.ProductCarts.Remove(cartToDelete);

            return context.SaveChanges();
        }

        public ProductCart Get(int id)
        {
            return context.ProductCarts.SingleOrDefault(c => c.CartId == id);
        }

        public List<ProductCart> GetAll()
        {
            return context.ProductCarts.ToList();
        }

        public int AddProduct(int cartId, int productId)
        {
            ProductCart cart = context.ProductCarts.SingleOrDefault(c => c.CartId == cartId);
            Product product = context.Products.SingleOrDefault(p => p.ProductId == productId);
            cart.ProductId.Add(product.ProductId);

            return context.SaveChanges();
        }

        public int Insert(ProductCart cart)
        {
            context.ProductCarts.Add(cart);

            return context.SaveChanges();
        }

      
    }
}
