using DataAccess;
using DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Pickup.com.Controllers
{
    public class MamaController : Controller
    {
        MamaRepository mamaRepo = new MamaRepository();
        EmployeeApprovalRepository approvalRepo = new EmployeeApprovalRepository();
        
        // GET: Mama
        public ActionResult Index(int id)
        {
            Mama mama = mamaRepo.GetByLogin(id);
            EmployeeApproval approval = approvalRepo.Get(mama.ApprovalId);

            if (approval.Status)
            {
                Session["MID"] = mama.Id;
                return View(mama);
            }

            else return View("Error");    
        }

        public ActionResult ViewOrders()
        {
            return View();
        }

        public ActionResult Logout()
        {
            Session["MID"] = null;
            return RedirectToAction("Index", "Home");
        }
    }
}