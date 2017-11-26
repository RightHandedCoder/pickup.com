using DataAccess;
using DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Pickup.com.Controllers
{
    public class CartController : Controller
    {
        // GET: Cart
        ProductRepository productRepo = new ProductRepository();
        ProductCartRepository cartRepo = new ProductCartRepository();
        OrderRepository orderRepo = new OrderRepository();
        BuyerRepository buyerRepo = new BuyerRepository();

        public ActionResult Index()
        {
            List<Product> productList = new List<Product>();
            ProductCart cart = (ProductCart)Session["CART"];

            foreach (Product item in cart.ProductList)
            {
                productList.Add(item);
            }


            return View(productList);
        }

        public ActionResult RemoveFromCart(int id)
        {
            ProductCart cart = (ProductCart)Session["CART"];
            cart.ProductList.Remove(productRepo.Get(id));
            Session["CART"] = cart;

            return RedirectToAction("Index", "Cart");

        }

        public ActionResult Checkout()
        {
            ProductCart cart = (ProductCart)Session["CART"];
            cart.OrderTime = DateTime.Now.ToShortDateString();
            cartRepo.Insert(cart);

            Order order = new Order();
            order.BuyerId = (int)Session["BID"];
            order.CartId = cart.CartId;
            orderRepo.Insert(order);

            return RedirectToAction("Index", "Home");
        }

        public ActionResult AddProductToCart(int id)
        {
            ProductCart cart = (ProductCart)Session["CART"];
            cart.ProductList.Add(productRepo.Get(id));
            Session["CART"] = cart;

            return RedirectToAction("Index","Home");
        }
    }
}