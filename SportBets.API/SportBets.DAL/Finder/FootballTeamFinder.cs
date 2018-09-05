using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using SportBets.BLL.Entities;
using SportBets.BLL.InterfaceForFinders;

namespace SportBets.DAL.Finder
{
    public class FootballTeamFinder : BaseFinder<FootballTeam> , IFootballTeamFinder
    {
        public FootballTeamFinder(IDbSet<FootballTeam> entities) : base(entities)
        {
        }


        public List<FootballTeam> FindFootballTeamById(int id)
        {
            var result = Find().Where(x => x.Id.Equals(id)).ToList();

            return result;
        }

        public List<FootballTeam> FindFootballTeamsByTeamname(string name)
        {
            var result = Find().Where(x => x.TeamName.Equals(name)).ToList();

            return result;
        }

        public List<FootballTeam> FindFootballTeamsByWins(int wins)
        {
            var result = Find().Where(x => x.WinsCount.Equals(wins))
                .OrderByDescending(x => x.TeamName).ToList();

            return result;
        }

        public List<FootballTeam> FindFootballTeamsByLosses(int losses)
        {
            var result = Find().Where(x => x.LossesCount.Equals(losses))
                .OrderByDescending(x => x.TeamName).ToList();

            return result;
        }
    }
}
