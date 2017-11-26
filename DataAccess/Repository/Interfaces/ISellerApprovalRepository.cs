using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository.Interfaces
{
    interface ISellerpprovalRepository
    {
        List<SellerApproval> GetAll();
        SellerApproval Get(int id);
        int Insert(SellerApproval approval);
        int UpdateApproval(int id, bool status);
        int Delete(int id);

    }
}
