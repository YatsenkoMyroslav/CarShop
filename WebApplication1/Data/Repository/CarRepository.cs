using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Data.Interaces;
using WebApplication1.Data.Models;

namespace WebApplication1.Repository
{
    public class CarRepository : IAllCars
    {
        private readonly AppDbContent appDbContent;

        public CarRepository(AppDbContent appDbContent) {
            this.appDbContent = appDbContent;
        }

        public IEnumerable<Car> Cars => appDbContent.Car.Include(c => c.Category);

        public IEnumerable<Car> GetFavCars => appDbContent.Car.Where(c => c.IsFavourite).Include(c => c.Category);

        public Car GetObjCar(int carId) => appDbContent.Car.FirstOrDefault(c => c.Id == carId);
    }
}
