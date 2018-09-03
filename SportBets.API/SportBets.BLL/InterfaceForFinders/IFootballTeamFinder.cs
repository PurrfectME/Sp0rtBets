using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SportBets.BLL.Entities;

namespace SportBets.BLL.InterfaceForFinders
{
    public interface IFootballTeamFinder
    {
        List<FootballTeam> FindFootballTeamById(FootballTeam footballTeam);
        List<FootballTeam> FindFootballTeamsByTeamname(FootballTeam footballTeam);
        List<FootballTeam> FindFootballTeamsByWins(FootballTeam footballTeam);
        List<FootballTeam> FindFootballTeamsByLosses(FootballTeam footballTeam);
    }
}
