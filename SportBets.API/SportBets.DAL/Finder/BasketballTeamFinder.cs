using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using SportBets.BLL.Entities;
using SportBets.BLL.InterfaceForFinders;

namespace SportBets.DAL.Finder
{
    public class BasketballTeamFinder : BaseFinder<BasketballTeam> , IBasketballTeamFinder
    {
        protected BasketballTeamFinder(DbSet<BasketballTeam> entities) : base(entities)
        {
        }

        public List<BasketballTeam> FindBasketballTeamById(BasketballTeam basketballTeam)
        {
            var result = Find().Where(x => x.Id.Equals(basketballTeam.Id)).ToList();

            return result;
        }

        public List<BasketballTeam> FindBasketballTeamsByTeamname(BasketballTeam basketballTeam)
        {
            var result = Find().Where(x => x.TeamName.Equals(basketballTeam.TeamName)).ToList();

            return result;
        }

        public List<BasketballTeam> FindBasketballTeamsByWins(BasketballTeam basketballTeam)
        {
            var result = Find().Where(x => x.WinsCount.Equals(basketballTeam.WinsCount))
                .OrderByDescending(x => x.TeamName).ToList();

            return result;
        }

        public List<BasketballTeam> FindBasketballTeamsByLosses(BasketballTeam basketballTeam)
        {
            var result = Find().Where(x => x.LossesCount.Equals(basketballTeam.LossesCount))
                .OrderByDescending(x => x.TeamName).ToList();

            return result;
        }


    }
}
