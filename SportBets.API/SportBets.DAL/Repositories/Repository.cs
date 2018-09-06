using System.Data.Entity;
using System.Linq;
using SportBets.BLL.Interfaces;

namespace SportBets.DAL.Repositories
{
    public class Repository<T> : IRepository<T> where T : class 
    {
        private readonly IDbSet<T> _entity;
        //private bool _disposed;

        public Repository(IDbSet<T> entities)
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
            return _entity.Where(x => true);
        }

    }
}
