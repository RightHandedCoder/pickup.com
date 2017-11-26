using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository.Interfaces
{
    interface IBuyerApprovalRepository
    {
        List<BuyerApproval> GetAll();
        BuyerApproval Get(int id);
        int Insert(BuyerApproval approval);
        int UpdateApproval(int id, bool status);
        int Delete(int id);

    }
}
