using WebApplication1.Data.Interaces;
using WebApplication1.Data.Models;

namespace WebApplication1.Data.mocks
{
    public class MockCars : IAllCars
    {
        private readonly ICarsCategory _category= new MockCategory();
        public IEnumerable<Car> Cars {
            get {
                return new List<Car> {
                    new Car
                    {
                        Name = "Mercedes GLA",
                        ShortDescription = "Small car for city",
                        LongDescription = "Good condition, small mileage. Low fuel usage.",
                        Price = 14999,
                        Img = "/img/mercedes.webp",
                        IsFavourite = true,
                        Available = true,
                        Category = _category.AllCategories.First()
                    },
                    new Car
                    {
                        Name = "BMW 328",
                        ShortDescription = "Good car for a young boy.",
                        LongDescription = "Good condition, small mileage. Low fuel usage.",
                        Price = 17999,
                        Img = "/img/bmw.jpg",
                        IsFavourite = false,
                        Available = true,
                        Category = _category.AllCategories.First()
                    },
                    new Car
                    {
                        Name = "Nissan Leaf",
                        ShortDescription = "Good electric car.",
                        LongDescription = "Good condition, small mileage. Zero fuel usage.",
                        Price = 8999,
                        Img = "/img/leaf.jpg",
                        IsFavourite = true,
                        Available = true,
                        Category = _category.AllCategories.Last()
                    },
                    new Car
                    {
                        Name = "Mercedes Sprinter",
                        ShortDescription = "Cheap car for commerce.",
                        LongDescription = "Good condition, high mileage. High fuel usage.",
                        Price = 5499,
                        Img = "/img/sprinter.jpg",
                        IsFavourite = false,
                        Available = true,
                        Category = _category.AllCategories.ToArray()[1]
                    },
                    new Car
                    {
                        Name = "Volkswagen Golf",
                        ShortDescription = "Das auto.",
                        LongDescription = "Good condition, small mileage. Fast car. Poland registration",
                        Price = 1999,
                        Img = "/img/golf.jpg",
                        IsFavourite = true,
                        Available = true,
                        Category = _category.AllCategories.ToArray()[2]
                    }
                    };
            }
        }
        public IEnumerable<Car> GetFavCars { get; set; }

        public Car GetObjCar(int carId)
        {
            throw new NotImplementedException();
        }
    }
}
