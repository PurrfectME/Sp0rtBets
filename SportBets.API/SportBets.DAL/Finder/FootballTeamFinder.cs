using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using SportBets.BLL.Entities;
using SportBets.BLL.InterfaceForFinders;

namespace SportBets.DAL.Finder
{
    public class FootballTeamFinder : BaseFinder<FootballTeam> , IFootballTeamFinder
    {
        protected FootballTeamFinder(DbSet<FootballTeam> entities) : base(entities)
        {
        }


        public List<FootballTeam> FindFootballTeamById(FootballTeam footballTeam)
        {
            var result = Find().Where(x => x.Id.Equals(footballTeam.Id)).ToList();

            return result;
        }

        public List<FootballTeam> FindFootballTeamsByTeamname(FootballTeam footballTeam)
        {
            var result = Find().Where(x => x.TeamName.Equals(footballTeam.TeamName)).ToList();

            return result;
        }

        public List<FootballTeam> FindFootballTeamsByWins(FootballTeam footballTeam)
        {
            var result = Find().Where(x => x.WinsCount.Equals(footballTeam.WinsCount))
                .OrderByDescending(x => x.TeamName).ToList();

            return result;
        }

        public List<FootballTeam> FindFootballTeamsByLosses(FootballTeam footballTeam)
        {
            var result = Find().Where(x => x.LossesCount.Equals(footballTeam.LossesCount))
                .OrderByDescending(x => x.TeamName).ToList();

            return result;
        }
    }
}
