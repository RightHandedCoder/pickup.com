using DataAccess;
using DataAccess.Repository;
using Pickup.com.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Pickup.com.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult BuyerLogin()
        {
            return View();
        }

        [HttpGet]
        public ActionResult SellerLogin()
        {
            return View();
        }

        [HttpGet,ActionName("Login")]
        public ActionResult ELogin()
        {
            return View("EmployeeLogin");
        }

        [HttpPost]
        public ActionResult BuyerLogin(ViewUserLogin vUserLogin)
        {
            if (ModelState.IsValid)
            {
                BuyerLoginRepository loginRepo = new BuyerLoginRepository();
                BuyerLogin login = new BuyerLogin();
                login.Username = vUserLogin.Username;
                login.Password = vUserLogin.Password;

                int id = loginRepo.Match(login).Id;

                return RedirectToAction("Index", "Buyer", new { @id = id });
            }

            else return View(vUserLogin); 
        }

        [HttpPost]
        public ActionResult SellerLogin(ViewUserLogin vUserLogin)
        {
            if (ModelState.IsValid)
            {
                SellerLoginRepository loginRepo = new SellerLoginRepository();
                SellerLogin login = new SellerLogin();
                login.Username = vUserLogin.Username;
                login.Password = vUserLogin.Password;

                int id = loginRepo.Match(login).Id;

                return RedirectToAction("Index", "Seller", new { @id = id });
            }

            else return View(vUserLogin);
        }

        [HttpPost, ActionName("Login")]
        public ActionResult ELogin(ViewUserLogin vUserLogin)
        {
            if (ModelState.IsValid)
            {
                EmployeeLoginRepository loginRepo = new EmployeeLoginRepository();
                EmployeeLogin login = new EmployeeLogin();
                login.Username = vUserLogin.Username;
                login.Password = vUserLogin.Password;

                EmployeeLogin loginFromDb = loginRepo.Match(login);


                if (loginFromDb.EmployeeType == "Admin")
                {
                    return RedirectToAction("LoadAdmin", "Employee", new { @id = loginFromDb.Id });
                }

                else if (loginFromDb.EmployeeType == "Mama")
                {
                    return RedirectToAction("LoadMama", "Employee", new { @id = loginFromDb.Id });
                }

                else return View("Error");
            }

            else return View("EmployeeLogin", vUserLogin);
        }
    }
}