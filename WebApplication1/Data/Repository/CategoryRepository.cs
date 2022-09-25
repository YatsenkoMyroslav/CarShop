using WebApplication1.Data;
using WebApplication1.Data.Interaces;
using WebApplication1.Data.Models;

namespace WebApplication1.Repository
{
    public class CategoryRepository : ICarsCategory
    {

        private readonly AppDbContent appDbContent;

        public CategoryRepository(AppDbContent appDbContent)
        {
            this.appDbContent = appDbContent;
        }

        public IEnumerable<Category> AllCategories => appDbContent.Category;
    }
}
