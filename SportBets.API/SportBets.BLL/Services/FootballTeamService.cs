using System.Collections.Generic;
using SportBets.BLL.Entities;
using SportBets.BLL.InterfaceForFinders;
using SportBets.BLL.InterfaceForService;
using SportBets.BLL.Interfaces;

namespace SportBets.BLL.Services
{
    public class FootballTeamService : IFootballTeamService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IFootballTeamFinder _footballTeamFinder;
        private readonly IRepository<FootballTeam> _FTRepository;

        public FootballTeamService(IUnitOfWork unitOfWork, IFootballTeamFinder footballTeamFinder, IRepository<FootballTeam> FTRepository)
        {
            _unitOfWork = unitOfWork;
            _footballTeamFinder = footballTeamFinder;
            _FTRepository = FTRepository;
        }
        public FootballTeam CreateTeam(FootballTeam footballTeam)
        {
            var teamToCreate = _FTRepository.Create(footballTeam);
            _unitOfWork.Commit();

            return teamToCreate;
        }

        public FootballTeam DeleteTeam(FootballTeam footballTeam)
        {
            var teamToDelete = _FTRepository.Delete(footballTeam);
            _unitOfWork.Commit();

            return teamToDelete;
        }

        public List<FootballTeam> GetTeamsById(int id) =>
            _footballTeamFinder.FindFootballTeamById(id);
        
        public List<FootballTeam> GetTeamsByName(string name) =>
            _footballTeamFinder.FindFootballTeamsByTeamname(name);

        public List<FootballTeam> GetTeamsByWins(int wins) =>
            _footballTeamFinder.FindFootballTeamsByWins(wins);

        public List<FootballTeam> GetTeamsByLosses(int losses) =>
            _footballTeamFinder.FindFootballTeamsByLosses(losses);
    }
}
