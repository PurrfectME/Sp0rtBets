using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SportBets.BLL.Entities;
using SportBets.BLL.Interfaces;


namespace SportBets.BLL.Services
{
    class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;



        public Task<Bet> FindBetByType(ItemType betType)
        {
            throw new NotImplementedException();
        }

        public Task<Bet> FindBetByDate(DateTime date)
        {
            throw new NotImplementedException();
        }

        public Task<Bet> MakeBet(Bet betId)
        {
            throw new NotImplementedException();
        }

        public Task<Bet> EditBet(Bet betId, DateTime betDate)
        {
            throw new NotImplementedException();
        }

        public Task<Bet> CancelBet(Bet betId, DateTime betStartTime)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Bet> GetAllBets()
        {
            throw new NotImplementedException();
        }
    }
}
