using System;
using System.Collections.Generic;
using System.Linq;
using SportBets.BLL.Entities;
using SportBets.BLL.InterfaceForFinders;
using SportBets.BLL.InterfaceForService;
using SportBets.BLL.Interfaces;

namespace SportBets.BLL.Services
{
    public class BetService : IBetService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IBetFinder _betFinder;
        private readonly IRepository<Bet> _betRepository;
        

        public BetService(IUnitOfWork unitOfWork, IBetFinder betFinder, IRepository<Bet> betRepository)
        {
            _unitOfWork = unitOfWork;
            _betFinder = betFinder;
            _betRepository = betRepository;
        }
        

        public Bet CreateBet(Bet bet)
        {
            var betToCreate = _betRepository.Create(bet);
            _unitOfWork.Commit();

            return betToCreate;
        }

        public void DeleteBet(Bet bet)
        {
            _betRepository.Delete(bet);
            
            _unitOfWork.Commit();
        }

        public List<Bet> GetBetById(Bet bet)
        {
            var betById = _betFinder.FindBetsById(bet);
            _unitOfWork.Commit();

            return betById;
        }

        public List<Bet> GetBetsByType(Bet bet)
        {
            var betsByType = _betFinder.FindBetsByType(bet.BetItemType);
            _unitOfWork.Commit();

            return betsByType;
        }

        public List<Bet> GetAllBets()
        {
            var allBets = _betFinder.FindAllBets();
            _unitOfWork.Commit();

            return allBets;
        }

        public List<Bet> GetBetsByDate(Bet bet)
        {
            var betsByDate = _betFinder.FindBetsByDate(bet.BetDate);
            _unitOfWork.Commit();

            return betsByDate;
        }
    }
}
