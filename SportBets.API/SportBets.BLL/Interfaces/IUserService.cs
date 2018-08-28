using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SportBets.BLL.Entities;

namespace SportBets.BLL.Interfaces
{
    interface IUserService
    {
        Task<Bet> FindBetByType(ItemType betType);
        Task<Bet> FindBetByDate(DateTime date);
        Task<Bet> MakeBet(Bet betId);
        Task<Bet> EditBet(Bet betId, DateTime betDate);
        Task<Bet> CancelBet(Bet betId, DateTime betStartTime);
        IEnumerable<Bet> GetAllBets();
    }
}
