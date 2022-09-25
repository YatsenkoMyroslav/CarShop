using WebApplication1.Data.Models;

namespace WebApplication1.ViewModels
{
    public class CarListViewModel
    {
        public IEnumerable<Car> allCars { get; set; }

        public string currCategory { get; set;}

    }
}
 