using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data.Interaces;
using WebApplication1.Data.Models;
using WebApplication1.ViewModels;

namespace WebApplication1.Controllers
{
    public class CarsController : Controller
    {
        private readonly IAllCars _allCars;
        private readonly ICarsCategory _allCategories;

        public CarsController(IAllCars allCars, ICarsCategory allCategories)
        {
            _allCars = allCars;
            _allCategories = allCategories;
        }

        [Route("Cars/List")]
        [Route("Cars/List/{category}")]
        [Route("Cars/List/{category}/{id}")]
        public ViewResult List(string category) {

            var _categories = category;

            IEnumerable<Car> Cars = null;

            string currCategory;

            if (string.IsNullOrEmpty(category))
                Cars = _allCars.Cars.OrderBy(c => c.Id);
            else {
                if (string.Equals("electro", category, StringComparison.OrdinalIgnoreCase))
                    Cars = _allCars.Cars.Where(c => c.Category.CategoryName.Equals("Електромобілі")).OrderBy(c => c.Id);
                else if (string.Equals("auto", category, StringComparison.OrdinalIgnoreCase))
                    Cars = _allCars.Cars.Where(c => c.Category.CategoryName.Equals("Легкові авто")).OrderBy(c => c.Id);
                else if (string.Equals("trucks", category, StringComparison.OrdinalIgnoreCase))
                    Cars = _allCars.Cars.Where(c => c.Category.CategoryName.Equals("Вантажні авто")).OrderBy(c => c.Id);
                else if (string.Equals("europlates", category, StringComparison.OrdinalIgnoreCase))
                    Cars = _allCars.Cars.Where(c => c.Category.CategoryName.Equals("Нерозмитнені авто")).OrderBy(c => c.Id);

                currCategory = _categories; 
            }

            var carObj = new CarListViewModel
            {
                allCars = Cars,
                currCategory = category
            };

            return View(carObj);
        }
    }
}
