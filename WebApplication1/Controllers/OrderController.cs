using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data.Interaces;
using WebApplication1.Data.Models;

namespace WebApplication1.Controllers
{
    public class OrderController : Controller
    {

        private readonly IAllOrders allOrders;
        private readonly ShopCart shopCart;

        public OrderController(IAllOrders allOrders, ShopCart shopCart)
        {
            this.allOrders = allOrders;
            this.shopCart = shopCart;
        }


        [HttpPost]
        public IActionResult CheckOut(Order order) {
            int i = 0;

            shopCart.ListShopItems = shopCart.GetShopItems();

            if (shopCart.ListShopItems.Count == 0)
            {
                ModelState.AddModelError("", "You may have items in the cart");
            }


            if (ModelState.ErrorCount-1 == 0)
            {
                allOrders.CreateOrder(order);
                return RedirectToAction("Index");
            }

            return View(order);
        }
        
        public IActionResult Checkout()
        {
            return View();
        }

        public IActionResult Index()
        {
            ViewBag.Message = "We got your order, we'll call you later";
            return View();
        }


    }
}
