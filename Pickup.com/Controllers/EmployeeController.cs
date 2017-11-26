using AutoMapper;
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
    public class EmployeeController : Controller
    {
        // GET: Admin

        AdminRepository adminRepo = new AdminRepository();
        AreaRepository areaRepo = new AreaRepository();
        CityRepository cityRepo = new CityRepository();
        DepartmentRepository deptRepo = new DepartmentRepository();
        EmployeeApprovalRepository approvalRepo = new EmployeeApprovalRepository();
        BuyerApprovalRepository buyerApprovalRepo = new BuyerApprovalRepository();
        SellerApprovalRepository sellerApprovalRepo = new SellerApprovalRepository();
        BuyerAddressRepository buyerAddressRepo = new BuyerAddressRepository();
        BuyerRepository buyerRepo = new BuyerRepository();
        SellerRepository sellerRepo = new SellerRepository();
        SellerAddressRepository sellerAddressRepo = new SellerAddressRepository();
        ProductRepository productRepo = new ProductRepository();
        ProductCatagoryRepository catagoryRepo = new ProductCatagoryRepository();
        MamaRepository mamaRepo = new MamaRepository();
        OrderRepository orderRepo = new OrderRepository();
        ProductCartRepository cartRepo = new ProductCartRepository();

       
        public ActionResult LoadAdmin(int id)
        {
            Admin admin = adminRepo.GetByLogin(id);
            EmployeeApproval approval = approvalRepo.Get(admin.ApprovalId);

            if (approval.Status)
            {
                Session["AID"] = admin.Id;

                return View(admin);
            }

            else return View("Error");
            
        }

        public ActionResult LoadMama(int id)
        {
            return RedirectToAction("Index","Mama", new { @id = id });
        }



        [HttpGet]
        public ActionResult CreateAdmin()
        {
            List<SelectListItem> areaList = new List<SelectListItem>();
            List<SelectListItem> cityList = new List<SelectListItem>();
            List<SelectListItem> deptList = new List<SelectListItem>();
            

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

            foreach (Department dept in deptRepo.GetAll())
            {
                SelectListItem option = new SelectListItem();
                option.Text = dept.Name;
                option.Value = dept.Id.ToString();

                deptList.Add(option);
            }

            ViewBag.Area = areaList;
            ViewBag.City = cityList;
            ViewBag.Dept = deptList;

            return View();
        }

        [HttpPost]
        public ActionResult CreateAdmin(ViewEmployee vEmployee)
        {
            if (ModelState.IsValid)
            {
                EmployeeLogin login = new EmployeeLogin();
                login.Username = vEmployee.Username;
                login.Password = vEmployee.Password;
                login.EmployeeType = "Admin";

                Area area = new Area();
                area = areaRepo.Get(vEmployee.AreaName);

                City city = new City();
                city = cityRepo.Get(vEmployee.CityName);

                Department dept = new Department();
                dept = deptRepo.Get(vEmployee.DepartmentName);

                var config = new MapperConfiguration(conf => conf.CreateMap<ViewEmployee, Admin>());
                var mapper = config.CreateMapper();

                Admin adminToInsert = mapper.Map<Admin>(vEmployee);
                adminToInsert.DateOfBirth = vEmployee.DateOfBirth.ToShortDateString();
                adminToInsert.JoiningDate = vEmployee.JoiningDate.ToShortDateString();
                adminToInsert.LoginData = login;
                adminToInsert.Area = area;
                adminToInsert.City = city;
                adminToInsert.Department = dept;

                adminRepo.Insert(adminToInsert);

                return RedirectToAction("Index");
            }

            else return View(vEmployee);
        }

        [HttpGet]
        public ActionResult CreateMama()
        {
            List<SelectListItem> areaList = new List<SelectListItem>();
            List<SelectListItem> cityList = new List<SelectListItem>();
            List<SelectListItem> deptList = new List<SelectListItem>();


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

            foreach (Department dept in deptRepo.GetAll())
            {
                SelectListItem option = new SelectListItem();
                option.Text = dept.Name;
                option.Value = dept.Id.ToString();

                deptList.Add(option);
            }

            ViewBag.Area = areaList;
            ViewBag.City = cityList;
            ViewBag.Dept = deptList;

            return View();
        }

        [HttpPost]
        public ActionResult CreateMama(ViewMama vMama)
        {
            if(ModelState.IsValid)
            {
                EmployeeLogin login = new EmployeeLogin();
                login.Username = vMama.Username;
                login.Password = vMama.Password;
                login.EmployeeType = "Mama";

                WorkingArea area = new WorkingArea();
                area.AreaId = vMama.WorkingArea;
                area.CityId = vMama.WorkingCity;

                Department dept = new Department();
                dept.Id = vMama.DepartmentName;

                EmployeeApproval approval = new EmployeeApproval();

                Mama mama = new Mama();
                mama.FirstName = vMama.FirstName;
                mama.LastName = vMama.LastName;
                mama.Email = vMama.Email;
                mama.Phone = vMama.Phone;
                mama.JobType = vMama.JobType;
                mama.JoiningDate = vMama.JoiningDate.ToShortDateString();
                mama.DateOfBirth = vMama.DateOfBirth.ToShortDateString();
                mama.Department = dept;
                mama.Gender = vMama.Gender;
                mama.HouseNo = vMama.HouseNo;
                mama.RoadNo = vMama.RoadNo;
                mama.Salary = vMama.Salary;
                mama.LoginData = login;
                mama.DeliveryArea = area;
                mama.Approval = approval;
                mama.Area = areaRepo.Get(vMama.AreaName);
                mama.City = cityRepo.Get(vMama.CityName);

                mamaRepo.Insert(mama);
                return RedirectToAction("LoadAdmin", "Employee", new { id = (int)Session["AID"] });
            }
            

            else return View(vMama);
        }

        public ActionResult BuyerList()
        {
            return View(buyerRepo.GetAll());
        }

        public ActionResult SellerList()
        {
            return View(sellerRepo.GetAll());
        }

        public ActionResult ProductList()
        {
            List<ViewProductList> productList = new List<ViewProductList>();

            foreach (Product item in productRepo.GetAll())
            {
                Seller seller = sellerRepo.Get(item.SellerId);
                ViewProductList listItem = new ViewProductList();
                listItem.Id = item.ProductId;
                listItem.Name = item.Name;
                listItem.Price = item.Price;
                listItem.Catagory = catagoryRepo.Get(item.CatagoryId).Name;
                listItem.SellerName = seller.FirstName;
                listItem.ShopName = sellerAddressRepo.Get(seller.AddressId).ShopName;

                productList.Add(listItem);
            }

            return View(productList);
        }

        public ActionResult ApproveBuyer(int id)
        {
            int approvalId = buyerRepo.Get(id).ApprovalId;
            buyerApprovalRepo.UpdateApproval(approvalId, true);

            return RedirectToAction("BuyerList");
        }

        public ActionResult UnapproveBuyer(int id)
        {
            int approvalId = buyerRepo.Get(id).ApprovalId;
            buyerApprovalRepo.UpdateApproval(approvalId, false);

            return RedirectToAction("BuyerList");
        }

        public ActionResult ApproveSeller(int id)
        {
            int approvalId = sellerRepo.Get(id).ApprovalId;
            sellerApprovalRepo.UpdateApproval(approvalId, true);

            return RedirectToAction("SellerList");
        }

        public ActionResult UnapproveSeller(int id)
        {
            int approvalId = sellerRepo.Get(id).ApprovalId;
            sellerApprovalRepo.UpdateApproval(approvalId, false);

            return RedirectToAction("SellerList");
        }

        public ActionResult ApproveProduct(int id)
        {
            productRepo.UpdateApproval(id, true);

            return RedirectToAction("ProductList");
        }

        public ActionResult UnapproveProduct(int id)
        {
            productRepo.UpdateApproval(id, false);

            return RedirectToAction("ProductList");
        }

        public ActionResult Logout()
        {
            Session["AID"] = null;
            return RedirectToAction("Index", "Home");
        }

        public ActionResult ViewProfile()
        {
            return View(adminRepo.Get((int)Session["AID"]));
        }

        public ActionResult ChangePassword()
        {
            return View();
        }

        public ActionResult ViewOrders()
        {
            List<ViewOrderList> orderList = new List<ViewOrderList>();

            foreach (Order item in orderRepo.GetAll())
            {
                Buyer buyer = buyerRepo.Get(item.BuyerId);
                ProductCart cart = cartRepo.Get(item.CartId);

                if(!item.Delivered)
                {
                    orderList.Add(new ViewOrderList() { Id = item.OrderId, BuyerName = buyer.FirstName + " " + buyer.LastName, OrderDate = cart.OrderTime, DeliveryStatus = "Not Delivered" });
                }
                
            }

            return View(orderList);
        }

        public ActionResult DeliverOrder(int id)
        {
            orderRepo.Get(id).Delivered = true;
            return RedirectToAction("ViewOrders");
        }

        //public ActionResult DeliverOrder(int id)
        //{
        //    List<SelectListItem> mamaList = new List<SelectListItem>();
        //    Order order = orderRepo.Get(id);
        //    Buyer buyer = buyerRepo.Get(order.BuyerId);
        //    BuyerAddress address = buyerAddressRepo.Get(buyer.Address.Id);
        //    Area area = areaRepo.Get(address.AreaId);
        //    City city = cityRepo.Get(address.CityId);

        //    foreach (Mama item in mamaRepo.GetAll())
        //    {
        //        if(item.DeliveryArea.AreaId == buyer.Address.AreaId && item.DeliveryArea.CityId == buyer.Address.CityId)
        //        {
        //            SelectListItem option = new SelectListItem();
        //            option.Text = item.FirstName + " " + item.LastName;
        //            option.Value = item.Id.ToString();

        //            mamaList.Add(option);
        //        } 
        //    }

        //    ViewBag.Mama = mamaList;

        //    ViewDeliverOrder vOrder = new ViewDeliverOrder();
        //    vOrder.BuyerName = buyer.FirstName + " " + buyer.LastName;
        //    vOrder.Address = "House: " + buyer.Address.House + " Road: " + buyer.Address.Road + " Area: " + area.Name + " City: " + city.Name;
        //    vOrder.Id = id;

        //    return View(vOrder);
        //}

        //[HttpPost]
        //public ActionResult DeliverOrder(ViewOrderList vOrder)
        //{
        //    orderRepo.Get(vOrder.Id).Delivered = true;

        //    return RedirectToAction("ViewOrders","Employee");
        //}




    }
}