﻿using System.Collections.Generic;
using SportBets.BLL.Entities;

namespace SportBets.BLL.InterfaceForService
{
    interface IHorseService
    {
        Horse CreateHorse(Horse horse);
        Horse DeleteHorse(Horse horse);
        List<Horse> GetHorseById(int id);
        List<Horse> GetHorsesByAge(int age);
        List<Horse> GetHorsesByWeight(float weight);
        List<Horse> GetHorsesByWins(int wins);
        List<Horse> GetHorsesByLosses(int losses);
        List<Horse> GetHorsesByName(string name);
    }
}
