using DataAccess;
using DataAccess.Repository;
using DataAccess.Repository.Interfaces;
using Pickup.com.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Pickup.com.Controllers
{
    public class SellerController : Controller
    {
        // GET: Seller

        SellerRepository sellerRepo = new SellerRepository();
        AreaRepository areaRepo = new AreaRepository();
        CityRepository cityRepo = new CityRepository();
        ProductRepository productRepo = new ProductRepository();
        SellerApprovalRepository approvalRepo = new SellerApprovalRepository();
        ProductCatagoryRepository catagoryRepo = new ProductCatagoryRepository();
        SellerAddressRepository addressRepo = new SellerAddressRepository();
        SellerLoginRepository loginRepo = new SellerLoginRepository();

        public ActionResult Index(int id)
        {
            Seller seller = sellerRepo.GetByLogin(id);
            SellerApproval approval = approvalRepo.Get(seller.ApprovalId);

            if (approval.Status)
            {
                Session["SID"] = seller.SellerId;

                return RedirectToAction("ViewProfile", "Seller", new { @id = seller.SellerId });
            }

            else return View("Error");

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
        public ActionResult Create(ViewSeller vseller)
        {
            if (ModelState.IsValid)
            {
                SellerAddress address = new SellerAddress();
                address.Area = areaRepo.Get(vseller.Area);
                address.City = cityRepo.Get(vseller.City);
                address.ShopName = vseller.ShopName;

                SellerLogin login = new SellerLogin();
                login.Username = vseller.Username;
                login.Password = vseller.Password;

                SellerApproval approval = new SellerApproval();
                approval.Status = false;

                Seller seller = new Seller();
                seller.FirstName = vseller.FirstName;
                seller.LastName = vseller.LastName;
                seller.Email = vseller.Email;
                seller.Phone = vseller.Phone;
                seller.Gender = vseller.Gender;
                seller.Address = address;
                seller.LoginData = login;
                seller.Approval = approval;

                sellerRepo.Insert(seller);

                return RedirectToAction("Index","Home");
            }

            return View(vseller);
        }

        [HttpGet]
        public ActionResult Add()
        {
           List<SelectListItem> catagoryList = new List<SelectListItem>();

            foreach (ProductCatagory catagory in catagoryRepo.GetAll())
            {
                SelectListItem option = new SelectListItem();
                option.Text = catagory.Name;
                option.Value = catagory.Id.ToString();
                catagoryList.Add(option);
            }

            ViewBag.Catagory = catagoryList;

            return View();
        }

        [HttpPost]
        public ActionResult Add(ViewProduct vProduct)
        {
            if (ModelState.IsValid)
            {
                int id = (int)Session["SID"];
                Product product = new Product();
                product.Name = vProduct.Name;
                product.Price = vProduct.Price;
                product.SellerId = sellerRepo.Get(id).SellerId;
                product.Catagory = catagoryRepo.Get(vProduct.CatagoryId);
                product.Approval = new ProductApproval();
                productRepo.Insert(product);

                return RedirectToAction("Index","Seller", new { @id = id});
            } 

            else return View(vProduct);
        }

        public ActionResult Logout()
        {
            Session["SID"] = null;
            return RedirectToAction("Index", "Home");
        }

        public ActionResult ViewProfile()
        {
            return View(sellerRepo.Get((int)Session["SID"]));
        }

        public ActionResult BasicInfo()
        {
            return View(sellerRepo.Get((int)Session["SID"]));
        }

        public ActionResult AddressInfo()
        {
            Seller seller = sellerRepo.Get((int)Session["SID"]);
            SellerAddress address = addressRepo.Get(seller.AddressId);
            Area area = areaRepo.Get(address.AreaId);
            City city = cityRepo.Get(address.CityId);

            ViewBag.Area = area.Name;
            ViewBag.City = city.Name;

            return View(address);
        }

        public ActionResult LoginInfo()
        {
            Seller seller = sellerRepo.Get((int)Session["SID"]);

            return View(loginRepo.Get(seller.LoginId));
        }

        [HttpGet]
        public ActionResult EditAddress(int id)
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

            return View(addressRepo.Get(id));
        }

        [HttpPost]
        public ActionResult EditAddress(SellerAddress address)
        {
            if (addressRepo.Update(address) == 1)
            {
                return RedirectToAction("ViewProfile","Seller");
            }

            else return View("Error");
        }

        [HttpGet]
        public ActionResult EditBasic(int id)
        {
            return View(sellerRepo.Get(id));
        }

        [HttpPost]
        public ActionResult EditBasic(Seller seller)
        {
            if (sellerRepo.Update(seller)==1)
            {
                return RedirectToAction("ViewProfile", "Seller");
            }        
           
            return View("Error");
        }

        public ActionResult ViewProducts()
        {
            return RedirectToAction("Index", "Product");
        }
    }
}