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
    public class BuyerController : Controller
    {
        // GET: Buyer
        BuyerRepository buyerRepo = new BuyerRepository();
        AreaRepository areaRepo = new AreaRepository();
        CityRepository cityRepo = new CityRepository();
        BuyerAddressRepository addressRepo = new BuyerAddressRepository();
        BuyerApprovalRepository approvalRepo = new BuyerApprovalRepository();
        ProductCartRepository cartRepo = new ProductCartRepository();
        ProductRepository productRepo = new ProductRepository();

        public ActionResult Index(int id)
        {
            Buyer buyer = buyerRepo.GetByLogin(id);
            BuyerApproval approval = approvalRepo.Get(buyer.ApprovalId);

            if (approval.Status)
            {
                Session["BID"] = buyer.BuyerId;

                if (InitCart()==1)
                {
                    return RedirectToAction("Index", "Home");
                }
                
                else return View("Error");
            }

            else return View("Error");
        }

        public ActionResult ViewProfile(int id)
        {
            Buyer buyer = buyerRepo.Get(id);
           
            return View(buyer);
        }

        [HttpGet]
        public ActionResult Create()
        {
            List<SelectListItem> areaList = new List<SelectListItem>();
            List<SelectListItem> cityList = new List<SelectListItem>();

            foreach (Area area in areaRepo.GetAll())
            {
                SelectListItem option = new SelectListItem();
                option.Text = area.Name;
                option.Value = area.Id.ToString();

                areaList.Add(option);
            }

            foreach (City city in cityRepo.GetAll())
            {
                SelectListItem option = new SelectListItem();
                option.Text = city.Name;
                option.Value = city.Id.ToString();

                cityList.Add(option);
            }

            ViewBag.Area = areaList;
            ViewBag.City = cityList;

            return View();
        }

        [HttpPost]
        public ActionResult Create(ViewBuyer vbuyer)
        {
            if (ModelState.IsValid)
            {
                BuyerAddress address = new BuyerAddress();
                address.Area = areaRepo.Get(vbuyer.Area);
                address.City = cityRepo.Get(vbuyer.City);
                address.Block = vbuyer.Block;
                address.House = vbuyer.House;
                address.Road = vbuyer.House;

                BuyerLogin login = new BuyerLogin();
                login.Username = vbuyer.Username;
                login.Password = vbuyer.Password;

                BuyerApproval approval = new BuyerApproval();
                approval.Status = false;

                Buyer buyer = new Buyer();
                buyer.FirstName = vbuyer.FirstName;
                buyer.LastName = vbuyer.LastName;
                buyer.Email = vbuyer.Email;
                buyer.Phone = vbuyer.Phone;
                buyer.Gender = vbuyer.Gender;
                buyer.Address = address;
                buyer.LoginData = login;
                buyer.Approval = approval;

                buyerRepo.Insert(buyer);

                return RedirectToAction("Index","Home");
            }
           
            return View(vbuyer);
        }

        public ActionResult Logout()
        {
            Session["BID"] = null;
            return RedirectToAction("Index", "Home");
        }

        [NonAction]
        private int InitCart()
        {
            if (Session["BID"] != null)
            {
                ProductCart cart =  new ProductCart();
                cart.BuyerId = (int)Session["BID"];
                Session["CART"] = cart;

                return 1;
            }

            else return 0;
        }
    }
}