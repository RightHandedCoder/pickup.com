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
    public class ProductController : Controller
    {
        // GET: Product
        ProductRepository productRepo = new ProductRepository();
        ProductCatagoryRepository catagoryRepo = new ProductCatagoryRepository();

        public ActionResult Index()
        {
            List<ViewProductList> myProducts = new List<ViewProductList>();

            foreach (Product item in productRepo.GetAll())
            {
                if (item.SellerId == (int)Session["SID"])
                {
                    ViewProductList product = new ViewProductList();
                    product.Id = item.ProductId;
                    product.Name = item.Name;
                    product.Catagory = catagoryRepo.Get(item.CatagoryId).Name;
                    product.Price = item.Price;

                    myProducts.Add(product);
                }
            }

            return View(myProducts);
        }

        public ActionResult Edit(int id)
        {
            List<SelectListItem> catagoryList = new List<SelectListItem>();

            Product product = productRepo.Get(id);
            ViewProduct vProduct = new ViewProduct();
            vProduct.Name = product.Name;
            vProduct.Price = product.Price;
            vProduct.Catagory = product.Catagory;


            foreach(ProductCatagory catagory in catagoryRepo.GetAll())
            {
                SelectListItem option = new SelectListItem();
                option.Text = catagory.Name;
                option.Value = catagory.Id.ToString();
                catagoryList.Add(option);
            }

            ViewBag.Catagory = catagoryList;

            return View(vProduct);
        }

        [HttpPost]
        public ActionResult Edit(ViewProduct vProduct)
        {
            Product product = new Product();
            product.ProductId = vProduct.Id;
            product.Price = vProduct.Price;
            product.CatagoryId = vProduct.CatagoryId;

            if (productRepo.Update(product) == 1)
            {
                return RedirectToAction("Index","Product");
            }

            else return View("Error");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            return View(productRepo.Get(id));
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirm(int id)
        {
            if (productRepo.Delete(id) == 1)
            {
                return RedirectToAction("Index", "Product");
            }

            else return View("Error");
        }
    }
}