using WebApplication1.Data.Models;

namespace WebApplication1.Data.Interaces
{
    public interface ICarsCategory
    {
        IEnumerable<Category> AllCategories { get; }
    }
}
