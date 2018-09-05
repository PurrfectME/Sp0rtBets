using System;
using System.Collections.Generic;
using SportBets.BLL.Entities;

namespace SportBets.BLL.InterfaceForService
{
    public interface IBetService
    {
        Bet CreateBet(Bet bet);
        void DeleteBet(Bet bet);
        List<Bet> GetBetById(int id);
        List<Bet> GetBetsByType(ItemType betType);
        List<Bet> GetAllBets();
        List<Bet> GetBetsByDate(DateTime date);

        //TODO: Read(), Update()


    }
}
