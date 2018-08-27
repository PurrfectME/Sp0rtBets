using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using SportBets.BLL.Entities;

namespace SportBets.DAL.Repositories
{
    interface IRepository<T> : IDisposable where T : class
    {
         
        //IEnumerable<T> GetList();
        //T Get(int id);
        //void Create(T bet);
        //void Delete(T id);

        Task CommitAsync();

        Task<IEnumerable<T>> GetListAsync();
        Task<IEnumerable<T>> GetByIdAsync(Expression<Func<T, bool>> expression);
        void Create(T entity);
        void Delete(T entityId);
        
    }
}
