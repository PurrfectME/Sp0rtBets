using System.Data.Entity;
using SportBets.BLL.Entities;

namespace SportBets.DAL.EntitiesContext
{
    public class SportBetsContext : DbContext
    {
        public SportBetsContext() :
            base("BetContext") { }
        
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Horse> Horses { get; set; }
        public virtual DbSet<FootballTeam> FootballTeams { get; set; }
        public virtual DbSet<BasketballTeam> BasketballTeams { get; set; }
        public virtual DbSet<Bet> Bets { get; set; }
    }
}
