using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SportBets.BLL.Entities;

namespace SportBets.BLL.InterfaceForFinders
{
    public interface IBasketballTeamFinder
    {
        List<BasketballTeam> FindBasketballTeamById(BasketballTeam basketballTeam);
        List<BasketballTeam> FindBasketballTeamsByTeamname(BasketballTeam basketballTeam);
        List<BasketballTeam> FindBasketballTeamsByWins(BasketballTeam basketballTeam);
        List<BasketballTeam> FindBasketballTeamsByLosses(BasketballTeam basketballTeam);
    }
}
