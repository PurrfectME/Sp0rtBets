using System.Linq;

namespace SportBets.BLL.Interfaces
{
    public interface IFinder<out T> where T : class
    {
        IQueryable<T> Find();
    }
}
