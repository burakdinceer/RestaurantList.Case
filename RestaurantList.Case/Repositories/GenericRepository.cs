using Microsoft.EntityFrameworkCore;
using RestaurantList.Case.Entities.Context;
using RestaurantList.Case.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace RestaurantList.Case.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class ,new()
    {
        private readonly DataContext _context;

        public GenericRepository(DataContext context)
        {
            _context = context;
        }

        public T Create(T entity)
        {
            _context.Set<T>().Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public void Delete(int id)
        {
            var result = _context.Set<T>().Find(id);
            _context.Set<T>().Remove(result);
        }

        public List<T> GetAll()
        {
            return _context.Set<T>().ToList();


        }

        public T GetId(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public void Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
