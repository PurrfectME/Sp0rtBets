using System.Data.Entity;
using SportBets.BLL.Entities;

namespace SportBets.DAL.EntitiesContext
{
    public class SportBetsContext : DbContext
    {
        public SportBetsContext() :
            base("BetContext") { }
        
        public DbSet<User> Users { get; set; }
        public DbSet<Horse> Horses { get; set; }
        public DbSet<FootballTeam> FootballTeams { get; set; }
        public DbSet<BasketballTeam> BasketballTeams { get; set; }
        public DbSet<Bet> Bets { get; set; }
        public DbSet<Betcard> Betcards { get; set; }

    }
}
