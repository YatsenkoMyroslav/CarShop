using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data.Interaces;
using WebApplication1.Data.Models;
using WebApplication1.ViewModels;

namespace WebApplication1.Controllers
{
    public class ShopCartController : Controller
    {

        private readonly IAllCars _carRep;

        private readonly ShopCart _shopCart;

        public ShopCartController(IAllCars carRepository, ShopCart shopCart) {
            
            _carRep = carRepository;
            _shopCart = shopCart;
        }

        public ViewResult Index() { 
            var items = _shopCart.GetShopItems();
            _shopCart.ListShopItems = items;

            var obj = new ShopCartViewModel {
                shopCart = _shopCart
            };

            return View(obj);
        }

        public RedirectToActionResult addToCart(int id)
        {
            var item = _carRep.Cars.FirstOrDefault(x => x.Id == id);

            if (item != null) {
                _shopCart.AddToCart(item);
            }

            return RedirectToAction("Index");
        }

    }
}
