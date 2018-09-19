using System.Collections.Generic;
using SportBets.BLL.Entities;

namespace SportBets.BLL.InterfaceForService
{
    public interface IFootballTeamService
    {
        FootballTeam CreateTeam(FootballTeam footballTeam);
        void DeleteTeam(FootballTeam footballTeam);
        List<FootballTeam> GetTeamsById(int id);
        List<FootballTeam> GetTeamsByName(string name);
        List<FootballTeam> GetTeamsByWins(int wins);
        List<FootballTeam> GetTeamsByLosses(int losses);
    }
}
