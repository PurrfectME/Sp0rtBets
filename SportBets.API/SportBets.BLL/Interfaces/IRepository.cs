using System.Linq;
using System.Threading.Tasks;

namespace SportBets.BLL.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task CommitAsync();
        T Create(T entity);
        T Delete(T entity);
        IQueryable<T> GetAll();

    }
}
