using System;
using System.Collections.Generic;
using DataAccess.Repository.Interfaces;
using System.Linq;
using System.Data.Entity;

namespace DataAccess.Repository
{
    public class ProductRepository : IProductRepository
    {
        DBContext context = Context.GetContext();

        public int Delete(int id)
        {
            Product productToDelete = context.Products.SingleOrDefault(p => p.ProductId == id);
            context.Products.Remove(productToDelete);

            return context.SaveChanges();
        }

        public Product Get(int id)
        {
            return context.Products.SingleOrDefault(p => p.ProductId == id);
        }

        public List<Product> GetAll()
        {
            return context.Products.ToList();
        }

        public bool GetApproval(int id)
        {
            int productApprovalId = context.Products.SingleOrDefault(p => p.ProductId == id).ApprovalId;

            return context.ProductApprovals.SingleOrDefault(a => a.Id == productApprovalId).Status;

        }

        public int Insert(Product product)
        {
            context.Products.Add(product);

            return context.SaveChanges();
        }

        public int Update(Product product)
        {
            Product productToUpdate = context.Products.SingleOrDefault(p => p.ProductId == product.ProductId);
            productToUpdate.Price = product.Price;
            productToUpdate.CatagoryId = product.CatagoryId;

            return context.SaveChanges();
        }

        public int UpdateApproval(int id, bool status)
        {
            int productApprovalId = context.Products.SingleOrDefault(p => p.ProductId == id).ApprovalId;

            context.ProductApprovals.SingleOrDefault(a => a.Id == productApprovalId).Status=status;

            return context.SaveChanges();
        }
    }
}
