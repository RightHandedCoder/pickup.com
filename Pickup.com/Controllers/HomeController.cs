using DataAccess;
using DataAccess.Repository;
using Pickup.com.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Pickup.com.Controllers
{
    public class HomeController : Controller
    {
        ProductRepository productRepo = new ProductRepository();

        public ActionResult Index()
        {
            List<Product> productList = new List<Product>();

            foreach (Product item in productRepo.GetAll())
            {
                if(productRepo.GetApproval(item.ProductId))
                {
                    productList.Add(item);
                }

            }
            
            return View(productList);
        }

        public ActionResult ViewCatagory(int id)
        {
            List<Product> productList = new List<Product>();

            foreach (Product item in productRepo.GetAll())
            {
                if (productRepo.GetApproval(item.ProductId))
                {
                    if(item.CatagoryId == id)
                    {
                        productList.Add(item);
                    }                  
                }

            }

            return View(productList);
        }

        [HttpGet]
        public ActionResult AddToCart(int id)
        {
            if (Session["BID"] != null)
            {
                return RedirectToAction("AddProductToCart", "Cart", new { @id = id });
            }

            else return RedirectToAction("BuyerLogin","Login");
           
        }

        [HttpGet]
        public ActionResult Login()
        {
            return RedirectToAction("Index","Login");
        }

        [HttpGet]
        public ActionResult EmployeeLogin()
        {
            return RedirectToAction("Login", "Login");
        }

        [HttpGet]
        public ActionResult CreateBuyer()
        {
            return RedirectToAction("Create","Buyer");
        }

        [HttpGet]
        public ActionResult CreateSeller()
        {
            return RedirectToAction("Create", "Seller");
        }

        public ActionResult ViewBuyerProfile(int id)
        {
            return RedirectToAction("ViewProfile","Buyer", new { @id = id} );
        }

        public ActionResult ViewSellerProfile(int id)
        {
            return RedirectToAction("ViewProfile", "Seller", new { @id = id });
        }



    }
}