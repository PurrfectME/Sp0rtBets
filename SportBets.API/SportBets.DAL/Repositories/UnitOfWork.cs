using System;
using System.Data.Entity;
using SportBets.BLL.Entities;
using SportBets.DAL.EntitiesContext;
using SportBets.DAL.Interfaces;

namespace SportBets.DAL.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SportBetsContext _context;
        private Repository<User> _userRepository;
        private Repository<Horse> _horseRepository;
        private Repository<Bet> _betRepository;
        private Repository<Betcard> _betcardRepository;
        private Repository<FootballTeam> _footballTeamRepository;
        private Repository<BasketballTeam> _basketballRepository;
        private bool _disposed;
        
        public UnitOfWork(SportBetsContext context)
        {
            this._context = context;
        }

        public UnitOfWork()
        {
            _context = new SportBetsContext();
        }

        public IRepository<Bet> Bets => 
            _betRepository ?? (_betRepository = new Repository<Bet>(_context));

        public IRepository<User> Users =>
            _userRepository ?? (_userRepository = new Repository<User>(_context));

        public IRepository<Horse> Horses =>
            _horseRepository ?? (_horseRepository = new Repository<Horse>(_context));

        public IRepository<Betcard> Betcards => 
            _betcardRepository ?? (_betcardRepository = new Repository<Betcard>(_context));
        
        public IRepository<FootballTeam> FootballTeams => 
            _footballTeamRepository ?? (_footballTeamRepository = new Repository<FootballTeam>(_context));
        
        public IRepository<BasketballTeam> BasketballTeams =>
            _basketballRepository ?? (_basketballRepository = new Repository<BasketballTeam>(_context));
        
        public void Commit()
        {
            _context.SaveChanges();
        }
        
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (this._disposed) return;
            if (disposing)
            {
                _context.Dispose();
            }
            this._disposed = true;
        }

    }
}

