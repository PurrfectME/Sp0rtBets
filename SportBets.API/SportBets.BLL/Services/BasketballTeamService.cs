using System;
using System.Collections.Generic;
using SportBets.BLL.Entities;
using SportBets.BLL.InterfaceForFinders;
using SportBets.BLL.InterfaceForService;
using SportBets.BLL.Interfaces;

namespace SportBets.BLL.Services
{
    public class BasketballTeamService : IBasketballTeamService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IBasketballTeamFinder _basketballTeamFinder;
        private readonly IRepository<BasketballTeam> _BTRepository;
        

        public BasketballTeamService(IUnitOfWork unitOfWork, IBasketballTeamFinder basketballTeamFinder, IRepository<BasketballTeam> BTRepository)
        {
            _unitOfWork = unitOfWork;
            _basketballTeamFinder = basketballTeamFinder;
            _BTRepository = BTRepository;
       
        }
        

        public BasketballTeam CreateTeam(BasketballTeam basketballTeam)
        {
            var teamToCreate = _BTRepository.Create(basketballTeam);
            _unitOfWork.Commit();

            return teamToCreate;
        }

        public BasketballTeam DeleteTeam(BasketballTeam basketballTeam)
        {
            var teamToDelete = _BTRepository.Delete(basketballTeam);
            _unitOfWork.Commit();

            return teamToDelete;
        }

        public List<BasketballTeam> GetTeamById(int id) =>
            _basketballTeamFinder.FindBasketballTeamById(id);

        public List<BasketballTeam> GetTeambyName(string name) =>
            _basketballTeamFinder.FindBasketballTeamsByTeamname(name);

        public List<BasketballTeam> GetTeamsByWins(int wins) =>
            _basketballTeamFinder.FindBasketballTeamsByWins(wins);

        public List<BasketballTeam> GetTeamsByLosses(int losses) =>
            _basketballTeamFinder.FindBasketballTeamsByLosses(losses);
    }
}
