using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using SportBets.BLL.Interfaces;
using SportBets.DAL.EntitiesContext;

namespace SportBets.DAL.Repositories
{
    public class Repository<T> : IRepository<T> where T : class 
    {
        private readonly DbSet<T> _entity;
        //private bool _disposed;

        public Repository(DbSet<T> entities)
        {
            _entity = entities;
        }
         
        public T Create(T entity)
        {
            return _entity.Add(entity);
        }

        public T Delete(T entity)
        {
            return _entity.Remove(entity);
        }

        public IQueryable<T> GetAll()
        {
            return _entity;
        }

    }
}
