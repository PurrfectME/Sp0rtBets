using System;
using SportBets.BLL.Entities;

namespace SportBets.DAL.Interfaces
{
    interface IUnitOfWork : IDisposable
    {
        IRepository<Bet> Bets { get; }
        IRepository<User> Users { get; }
        IRepository<Horse> Horses { get; }
        IRepository<Betcard> Betcards { get; }
        IRepository<FootballTeam> FootballTeams { get; }
        IRepository<BasketballTeam> BasketballTeams { get; }

        void Commit();
    }
}
