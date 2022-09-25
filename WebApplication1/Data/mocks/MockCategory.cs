using WebApplication1.Data.Interaces;
using WebApplication1.Data.Models;

namespace WebApplication1.Data.mocks
{
    public class MockCategory : ICarsCategory
    {
        public IEnumerable<Category> AllCategories
        {
            get {
                return new List<Category> {
                    new Category { CategoryName="Легкові авто", Description="Для повсякденного використання"},
                    new Category { CategoryName="Вантажні авто", Description="Для бізнесу"},
                    new Category { CategoryName="Нерозмитнені авто", Description="Більш дешевші варіанти авто"},
                    new Category { CategoryName="Електромобілі", Description="Дешево та екологічно"}
                };
            }
        }
    }
}
