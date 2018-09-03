using System.Data.Entity;
using System.Linq;
using SportBets.BLL.Interfaces;

namespace SportBets.DAL.Finder
{
    public class BaseFinder<T> : IFinder<T> where T : class 
    {
        private readonly DbSet<T> _entities;

        protected BaseFinder(DbSet<T> entities)
        {
            _entities = entities;
        }
        
        public IQueryable<T> Find()
        {
            return _entities.AsQueryable();
        }
    }
}
