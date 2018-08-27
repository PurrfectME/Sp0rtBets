using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Configuration;
using System.Text;
using System.Threading.Tasks;
using SportBets.BLL.Entities;
using SportBets.DAL.EntitiesContext;

namespace SportBets.DAL.Repositories
{
    class BetRepository : IRepository<Bet>
    {
        private SportBetsContext _context;
        private bool _disposed;

        public BetRepository(SportBetsContext _context)
        {
            this._context = _context;
        }


        protected virtual void Dispose(bool disposing)
        {
            if (!this._disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this._disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public async Task<IEnumerable<Bet>> GetListAsync() => await this._context.Set<Bet>().ToListAsync();



        public async Task<IEnumerable<Bet>> GetByIdAsync(Expression<Func<Bet, bool>> expression)
        {
            return await this._context.Set<Bet>().Where(expression).ToListAsync();
        }

        public void Create(Bet bet)
        {
            if (bet == null)
            {
                throw new ArgumentException("bet");
            }

            this._context.Set<Bet>().Add(bet);
        }

        public void Delete(Bet id)
        {
            var bet = _context.Bets.Find(id);
            if (bet == null)
            {
                throw new ArgumentException("id");
            }

            this._context.Set<Bet>().Remove(bet);

        }

        public async Task CommitAsync()
        {
            await this._context.SaveChangesAsync();
        }
    }
}
