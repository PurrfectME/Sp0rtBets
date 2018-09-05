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
        List<Horse> FindHorseById(int id);
        List<Horse> FindHorsesByAge(int age);
        List<Horse> FindHorseByWins(int wins);
        List<Horse> FindHorsesByLosses(int losses);
        List<Horse> FindHorseByName(string name);
        List<Horse> FindHorsesByWeight(float weight);
    }
}
