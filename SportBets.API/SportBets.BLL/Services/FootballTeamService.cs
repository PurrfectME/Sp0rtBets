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

        public List<FootballTeam> GetTeamsById(FootballTeam footballTeam) =>
            _footballTeamFinder.FindFootballTeamById(footballTeam);
        
        public List<FootballTeam> GetTeamsByName(FootballTeam footballTeam) =>
            _footballTeamFinder.FindFootballTeamsByTeamname(footballTeam);

        public List<FootballTeam> GetTeamsByWins(FootballTeam footballTeam) =>
            _footballTeamFinder.FindFootballTeamsByWins(footballTeam);

        public List<FootballTeam> GetTeamsByLosses(FootballTeam footballTeam) =>
            _footballTeamFinder.FindFootballTeamsByLosses(footballTeam);
    }
}
