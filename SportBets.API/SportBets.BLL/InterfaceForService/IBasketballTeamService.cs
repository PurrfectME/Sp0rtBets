using System.Collections.Generic;
using SportBets.BLL.Entities;

namespace SportBets.BLL.InterfaceForService
{
    interface IBasketballTeamService
    {
        BasketballTeam CreateTeam(BasketballTeam basketballTeam);
        BasketballTeam DeleteTeam(BasketballTeam basketballTeam);
        List<BasketballTeam> GetTeamById(BasketballTeam basketballTeam);
        List<BasketballTeam> GetTeambyName(BasketballTeam basketballTeam);
        List<BasketballTeam> GetTeamsByWins(BasketballTeam basketballTeam);
        List<BasketballTeam> GetTeamsByLosses(BasketballTeam basketballTeam);
    }
}
