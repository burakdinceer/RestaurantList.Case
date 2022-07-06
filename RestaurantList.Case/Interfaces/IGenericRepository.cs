using System.Collections.Generic;

namespace RestaurantList.Case.Interfaces
{
    public interface IGenericRepository<T> where T : class ,new()
    {
        List<T> GetAll();
        T GetId(int id);
        T Create(T entity);
        void Update(T entity, int id);
        void Delete(int id);
    }
}
