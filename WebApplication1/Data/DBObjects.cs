using WebApplication1.Data.Models;

namespace WebApplication1.Data
{
    public class DBObjects
    {

        public static void Initial(AppDbContent content) {

            if (!content.Category.Any())
            {
                content.Category.AddRange(Categories.Select(c => c.Value));
            }

            if (!content.Car.Any()) {
                content.Car.AddRange(
                    new Car
                    {
                        Name = "Mercedes GLA",
                        ShortDescription = "Small car for city",
                        LongDescription = "Good condition, small mileage. Low fuel usage.",
                        Price = 14999,
                        Img = "/img/mercedes.webp",
                        IsFavourite = true,
                        Available = true,
                        Category = Categories["Легкові авто"]
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
                        Category = Categories["Легкові авто"]
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
                        Category = Categories["Електромобілі"]
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
                        Category = Categories["Вантажні авто"]
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
                        Category = Categories["Нерозмитнені авто"]
                    }
                    );
            }

            content.SaveChanges();

        }

        private static Dictionary<string, Category> category;

        public static Dictionary<string, Category> Categories
        {
            get {
                if (category == null) {
                    var list = new Category[] {
                        new Category { CategoryName="Легкові авто", Description="Для повсякденного використання"},
                        new Category { CategoryName="Вантажні авто", Description="Для бізнесу"},
                        new Category { CategoryName="Нерозмитнені авто", Description="Більш дешевші варіанти авто"},
                        new Category { CategoryName="Електромобілі", Description="Дешево та екологічно"}
                    };

                    category = new Dictionary<string, Category>();

                    foreach (var el in list) { 
                        category.Add(el.CategoryName, el);
                    }
                    
                }

                return category;
            }
        }

    }
}
