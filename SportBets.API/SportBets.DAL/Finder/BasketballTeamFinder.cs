using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using SportBets.BLL.Entities;
using SportBets.BLL.InterfaceForFinders;

namespace SportBets.DAL.Finder
{
    public class BasketballTeamFinder : BaseFinder<BasketballTeam> , IBasketballTeamFinder
    {
        public BasketballTeamFinder(IDbSet<BasketballTeam> entities) : base(entities)
        {
        }

        public List<BasketballTeam> FindBasketballTeamById(int id)
        {
            var result = Find().Where(x => x.Id.Equals(id)).ToList();

            return result;
        }

        public List<BasketballTeam> FindBasketballTeamsByTeamname(string name)
        {
            var result = Find().Where(x => x.TeamName.Equals(name)).ToList();

            return result;
        }

        public List<BasketballTeam> FindBasketballTeamsByWins(int wins)
        {
            var result = Find().Where(x => x.WinsCount.Equals(wins))
                .OrderByDescending(x => x.TeamName).ToList();

            return result;
        }

        public List<BasketballTeam> FindBasketballTeamsByLosses(int losses)
        {
            var result = Find().Where(x => x.LossesCount.Equals(losses))
                .OrderByDescending(x => x.TeamName).ToList();

            return result;
        }


    }
}
