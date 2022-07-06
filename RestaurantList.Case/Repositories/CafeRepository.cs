using RestaurantList.Case.Entities;
using RestaurantList.Case.Entities.Context;
using RestaurantList.Case.Interfaces;

namespace RestaurantList.Case.Repositories
{
    public class CafeRepository : GenericRepository<Cafe>, IGenericRepository<Cafe>
    {
        public CafeRepository(DataContext context) : base(context)
        {
        }
    }
}
