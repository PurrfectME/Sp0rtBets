using System.Threading.Tasks;

namespace SportBets.BLL.Interfaces
{
    public interface IRepository<in T> where T : class
    {
         
        //IEnumerable<T> GetList();
        //T Get(int id);
        //void Create(T bet);
        //void Delete(T id);

        Task CommitAsync();
        void Create(T entity);
        void Delete(T entityId);
        
    }
}
