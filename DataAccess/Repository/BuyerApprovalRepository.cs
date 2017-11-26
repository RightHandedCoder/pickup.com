using DataAccess.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class BuyerApprovalRepository : IBuyerApprovalRepository
    {
        DBContext context = Context.GetContext();

        public int Delete(int id)
        {
            BuyerApproval buyerApprovalToDelete = context.BuyerApprovals.SingleOrDefault(a => a.Id == id);
            context.BuyerApprovals.Remove(buyerApprovalToDelete);

            return context.SaveChanges();
        }

        public BuyerApproval Get(int id)
        {
            return context.BuyerApprovals.SingleOrDefault(a => a.Id == id);
        }

        public List<BuyerApproval> GetAll()
        {
            return context.BuyerApprovals.ToList();
        }

        public int Insert(BuyerApproval BuyerApproval)
        {
            context.BuyerApprovals.Add(BuyerApproval);

            return context.SaveChanges();
        }

        public int UpdateApproval(int id, bool status)
        {
            BuyerApproval buyerApprovalToUpdate = context.BuyerApprovals.SingleOrDefault(a => a.Id == id);
            buyerApprovalToUpdate.Status = status;

            return context.SaveChanges();
        }
    }
}
