using AuthorBookWebAPI.Data;
using Microsoft.EntityFrameworkCore;
using System;

namespace AuthorBookWebAPI.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly MyContext _context;
        private readonly DbSet<T> _table;

        public GenericRepository(MyContext context)
        {
            _context = context;
            _table = _context.Set<T>();
        }

        public T Get(int id)
        {
            //return _table.AsNoTracking().FirstOrDefault(x=>x.Id=id);
            return _table.Find(id);
        }

        public IQueryable<T> GetAll()
        {
            return _table;
        }

        public int Add(T entity)
        {
            _table.Add(entity);
            return _context.SaveChanges();
        }

        public T Update(T entity)
        {
            _table.Update(entity);
            _context.SaveChanges();
            return entity;
        }

        public void Delete(T entity)
        {   
            _table.Remove(entity);
            _context.SaveChanges();   
        }
    }

}
