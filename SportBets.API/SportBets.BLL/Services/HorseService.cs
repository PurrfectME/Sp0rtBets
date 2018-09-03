using System.Collections.Generic;
using SportBets.BLL.Entities;
using SportBets.BLL.InterfaceForFinders;
using SportBets.BLL.InterfaceForService;
using SportBets.BLL.Interfaces;

namespace SportBets.BLL.Services
{
    public class HorseService : IHorseService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IHorseFinder _horseFinder;
        private readonly IRepository<Horse> _horseRepository;


        public HorseService(IUnitOfWork unitOfWork, IHorseFinder horseFinder, IRepository<Horse> horseRepository)
        {
            _unitOfWork = unitOfWork;
            _horseFinder = horseFinder;
            _horseRepository = horseRepository;
        }


        public Horse CreateHorse(Horse horse)
        {
            var horseToCreate = _horseRepository.Create(horse);
            _unitOfWork.Commit();

            return horseToCreate;
        }
        
        public Horse DeleteHorse(Horse horse)
        {
            var horseToDelete = _horseRepository.Delete(horse);
            _unitOfWork.Commit();

            return horseToDelete;
        }
        
        public List<Horse> GetHorseById(Horse horse) => _horseFinder.FindHorseById(horse);

        public List<Horse> GetHorsesByAge(Horse horse) => _horseFinder.FindHorsesByAge(horse);
        
        public List<Horse> GetHorsesByWeight(Horse horse) => _horseFinder.FindHorsesByWeight(horse);
        
        public List<Horse> GetHorsesByWins(Horse horse) => _horseFinder.FindHorseByWins(horse);

        public List<Horse> GetHorsesByLosses(Horse horse) => _horseFinder.FindHorsesByLosses(horse);

        public List<Horse> GetHorsesByName(Horse horse) => _horseFinder.FindHorseByName(horse);
    }
}
