using RestaurantList.Case.Entities;
using RestaurantList.Case.Entities.Context;
using RestaurantList.Case.Interfaces;

namespace RestaurantList.Case.Repositories
{
    public class CategoryRepository : GenericRepository<Category>, IGenericRepository<Category>
    {
        public CategoryRepository(DataContext context) : base(context)
        {
        }
    }
}
