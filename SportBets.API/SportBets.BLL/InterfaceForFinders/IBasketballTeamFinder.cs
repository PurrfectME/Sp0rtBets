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
        List<BasketballTeam> FindBasketballTeamById(int id);
        List<BasketballTeam> FindBasketballTeamsByTeamname(string name);
        List<BasketballTeam> FindBasketballTeamsByWins(int wins);
        List<BasketballTeam> FindBasketballTeamsByLosses(int losses);
    }
}
