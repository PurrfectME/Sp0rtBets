using System;
using System.Data.Entity;
using System.Threading.Tasks;
using SportBets.DAL.EntitiesContext;
using SportBets.DAL.Interfaces;

namespace SportBets.DAL.Repositories
{
    class Repository<T> : IRepository<T> where T : class 
    {
        private readonly SportBetsContext _context;
        private DbSet<T> _entity;
        //private bool _disposed;

        public Repository(SportBetsContext context)
        {
            this._context = context;
            _entity = this._context.Set<T>();
        }
         
        public void Create(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentException("entity");
            }

            this._entity.Add(entity);
        }

        public void Delete(T entity)
        {
            var isBet = _entity.Find(entity);

            _entity.Remove(isBet);
        }

        public async Task CommitAsync()
        {
            await this._context.SaveChangesAsync();
        }

        public void Dispose()
        {
            Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
