using System.Collections.Generic;
using SportBets.BLL.Entities;

namespace SportBets.BLL.InterfaceForService
{
    public interface IBetService
    {
        Bet CreateBet(Bet bet);
        void DeleteBet(Bet bet);
        List<Bet> GetBetById(Bet bet);
        List<Bet> GetBetsByType(Bet bet);
        List<Bet> GetAllBets();
        List<Bet> GetBetsByDate(Bet bet);

        //TODO: Read(), Update()


    }
}
