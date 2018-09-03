using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SportBets.BLL.Entities;

namespace SportBets.BLL.InterfaceForFinders
{
    public interface IHorseFinder
    {
        List<Horse> FindHorseById(Horse horse);
        List<Horse> FindHorsesByAge(Horse horse);
        List<Horse> FindHorseByWins(Horse horse);
        List<Horse> FindHorsesByLosses(Horse horse);
        List<Horse> FindHorseByName(Horse horse);
        List<Horse> FindHorsesByWeight(Horse horse);
    }
}
