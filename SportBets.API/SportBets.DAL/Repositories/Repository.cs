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
        private readonly SportBetsContext _context;
        private readonly DbSet<T> _entity;
        //private bool _disposed;

        public Repository(SportBetsContext context)
        {
            this._context = context;
            _entity = this._context.Set<T>();
        }
         
        public T Create(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentException("entity");
            }

            return this._entity.Add(entity);
        }

        public T Delete(T entity)
        {
            var isBet = _entity.Find(entity);

            return _entity.Remove(isBet ?? throw new InvalidOperationException());
        }

        public IQueryable<T> GetAll()
        {
            return _entity;
        }

        public async Task CommitAsync()
        {
            await this._context.SaveChangesAsync();
        }
    }
}
