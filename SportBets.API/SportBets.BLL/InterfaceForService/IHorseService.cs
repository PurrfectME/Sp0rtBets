using System.Collections.Generic;
using SportBets.BLL.Entities;

namespace SportBets.BLL.InterfaceForService
{
    interface IHorseService
    {
        Horse CreateHorse(Horse horse);
        Horse DeleteHorse(Horse horse);
        List<Horse> GetHorseById(Horse horse);
        List<Horse> GetHorsesByAge(Horse horse);
        List<Horse> GetHorsesByWeight(Horse horse);
        List<Horse> GetHorsesByWins(Horse horse);
        List<Horse> GetHorsesByLosses(Horse horse);
        List<Horse> GetHorsesByName(Horse horse);
    }
}
