using System.Collections.Generic;
using SportBets.BLL.Entities;

namespace SportBets.BLL.InterfaceForService
{
    interface IBasketballTeamService
    {
        BasketballTeam CreateTeam(BasketballTeam basketballTeam);
        BasketballTeam DeleteTeam(BasketballTeam basketballTeam);
        List<BasketballTeam> GetTeamById(int id);
        List<BasketballTeam> GetTeambyName(string name);
        List<BasketballTeam> GetTeamsByWins(int wins);
        List<BasketballTeam> GetTeamsByLosses(int losses);
    }
}
