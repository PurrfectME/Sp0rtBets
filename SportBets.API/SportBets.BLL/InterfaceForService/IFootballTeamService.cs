using System.Collections.Generic;
using SportBets.BLL.Entities;

namespace SportBets.BLL.InterfaceForService
{
    interface IFootballTeamService
    {
        FootballTeam CreateTeam(FootballTeam footballTeam);
        FootballTeam DeleteTeam(FootballTeam footballTeam);
        List<FootballTeam> GetTeamsById(FootballTeam footballTeam);
        List<FootballTeam> GetTeamsByName(FootballTeam footballTeam);
        List<FootballTeam> GetTeamsByWins(FootballTeam footballTeam);
        List<FootballTeam> GetTeamsByLosses(FootballTeam footballTeam);
    }
}
