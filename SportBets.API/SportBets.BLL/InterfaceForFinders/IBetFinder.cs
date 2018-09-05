using System;
using System.Collections.Generic;
using SportBets.BLL.Entities;

namespace SportBets.BLL.InterfaceForFinders
{
    public interface IBetFinder
    {
        List<Bet> FindBetsByType(ItemType betType);
        List<Bet> FindBetsByDate(DateTime date);
        List<Bet> FindBetsById(int id);
        List<Bet> FindAllBets();
    }
}
