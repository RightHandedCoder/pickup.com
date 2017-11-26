using DataAccess;
using System;
using System.Data.Entity;

namespace Pickup.com
{
    public class Seeder : DropCreateDatabaseIfModelChanges<DBContext>
    {
        DBContext context = new DBContext();

        public Seeder() : base()
        {
            AddAmin();

            SaveChanges();
        }

        private void AddAmin()
        {
            Admin admin = new Admin();
            admin.FirstName = "admin";
            admin.LastName = "admin";
            admin.Area = new Area() { Name = "Niknuja" };
            admin.City = new City() { Name = "Dhaka" };
            admin.Department = new Department { Name = "Admin" };
            admin.DateOfBirth = DateTime.Today.ToShortDateString();
            admin.JoiningDate = DateTime.Today.ToShortDateString();
            admin.Email = "aniknishan@gmail.com";
            admin.Gender = "Male";
            admin.HouseNo = "06";
            admin.RoadNo = "05";
            admin.Salary = 0;
            admin.Phone = "01676567772";
            admin.JobType = "Full Time";
            admin.LoginData = new EmployeeLogin { Username = "admin", Password = "admin", EmployeeType = "Admin" };
            admin.Approval = new EmployeeApproval();

            context.Admins.Add(admin);

        }

        private void AddMama()
        {
            Mama mama = new Mama();
            mama.FirstName = "mama";
            mama.LastName = "mama";
            mama.Area = new Area() { Name = "Khilkhet" };
            mama.City = new City() { Name = "Chittagong" };
            mama.Department = new Department { Name = "Delivery" };
            mama.DateOfBirth = DateTime.Today.ToShortDateString();
            mama.JoiningDate = DateTime.Today.ToShortDateString();
            mama.Email = "aniknishan@gmail.com";
            mama.Gender = "Male";
            mama.HouseNo = "06";
            mama.RoadNo = "05";
            mama.Salary = 0;
            mama.Phone = "01676567772";
            mama.JobType = "Mama";
            mama.LoginData = new EmployeeLogin { Username = "mama", Password = "mama", EmployeeType = "Mama" };
            mama.DeliveryArea = new WorkingArea() { Area = new Area() { Name = "ABC" }, City = new City() { Name = "ABC" } };
            mama.Approval = new EmployeeApproval();

            context.Mamas.Add(mama);

        }

        private void AddBuyer()
        {
            Buyer Buyer = new Buyer();
            Buyer.FirstName = "Nahid";
            Buyer.LastName = "Nawaz";
            BuyerAddress address = new BuyerAddress() { House = "06", Road = "05", Block = null, Area = new Area() { Name = "Gulshan" }, City = new City() { Name = "Khulna" } };
            Buyer.Email = "nahid@gmail.com";
            Buyer.Phone = "01711829603";
            Buyer.Gender = "Male";
            Buyer.LoginData = new BuyerLogin { Username = "buyer", Password = "buyer"};
            Buyer.Approval = new BuyerApproval();
            Buyer.Approval.Status = true;

            context.Buyers.Add(Buyer);

        }

        private void AddSeller()
        {
            Seller Seller = new Seller();
            Seller.FirstName = "Seller";
            Seller.LastName = "Seller";
            Seller.Address = new SellerAddress() { ShopName="0", Area = new Area() { Name = "Banani" }, City = new City() { Name = "Chittagong" } };
            Seller.Email = "aniknishan@gmail.com";
            Seller.Gender = "Male";
            Seller.Phone = "01676567772";
            Seller.LoginData = new SellerLogin { Username = "seller", Password = "seller"};
            Seller.Approval = new SellerApproval();
            Seller.Approval.Status = true;

            context.Sellers.Add(Seller);
        }

        private void AddDepartment(string name)
        {
            Department dept = new Department();
            dept.Name = name;

            context.Departments.Add(dept);
        }

        private void AddProduct(string name,double price,string catagoryName)
        {
            Product product = new Product();
            product.Name = name;
            product.Price = price;
            product.Approval = new ProductApproval() { Status = true};
            product.Catagory = new ProductCatagory(catagoryName);

            context.Products.Add(product);
        }

        private void AddCatagory(string name)
        {
            ProductCatagory catagory = new ProductCatagory(name);

            context.Catagories.Add(catagory);
        }

        private void AddArea(string name)
        {
            Area area = new Area();
            area.Name = name;

            context.Areas.Add(area);
        }

        private void AddCity(string name)
        {
            City city = new City();
            city.Name = name;

            context.Cities.Add(city);
        }

        private void SaveChanges()
        {
            context.SaveChanges();
        }
    }   
}