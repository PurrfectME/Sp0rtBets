using System.Collections.Generic;
using SportBets.BLL.Entities;

namespace SportBets.BLL.InterfaceForFinders
{
    public interface IFootballTeamFinder
    {
        List<FootballTeam> FindFootballTeamById(int id);
        List<FootballTeam> FindFootballTeamsByTeamname(string name);
        List<FootballTeam> FindFootballTeamsByWins(int wins);
        List<FootballTeam> FindFootballTeamsByLosses(int losses);
    }
}
