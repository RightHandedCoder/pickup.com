using DataAccess.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class SellerApprovalRepository : ISellerpprovalRepository
    {
        DBContext context = Context.GetContext();

        public int Delete(int id)
        {
            SellerApproval sellerApprovalToDelete = context.SellerApprovals.SingleOrDefault(a => a.Id == id);
            context.SellerApprovals.Remove(sellerApprovalToDelete);

            return context.SaveChanges();
        }

        public SellerApproval Get(int id)
        {
            return context.SellerApprovals.SingleOrDefault(a => a.Id == id);
        }

        public List<SellerApproval> GetAll()
        {
            return context.SellerApprovals.ToList();
        }

        public int Insert(SellerApproval SellerApproval)
        {
            context.SellerApprovals.Add(SellerApproval);

            return context.SaveChanges();
        }

        public int UpdateApproval(int id, bool status)
        {
            SellerApproval sellerApprovalToUpdate = context.SellerApprovals.SingleOrDefault(a => a.Id == id);
            sellerApprovalToUpdate.Status = status;

            return context.SaveChanges();
        }
    }
}
