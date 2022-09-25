using WebApplication1.Data.Models;

namespace WebApplication1.Data.Interaces
{
    public interface IAllCars
    {
        IEnumerable<Car> Cars { get;  }
        IEnumerable<Car> GetFavCars { get; }

        Car GetObjCar(int carId);
    }
}
