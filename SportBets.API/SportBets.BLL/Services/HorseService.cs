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
        
        public List<Horse> GetHorseById(int id) => _horseFinder.FindHorseById(id);

        public List<Horse> GetHorsesByAge(int age) => _horseFinder.FindHorsesByAge(age);
        
        public List<Horse> GetHorsesByWeight(float weight) => _horseFinder.FindHorsesByWeight(weight);
        
        public List<Horse> GetHorsesByWins(int wins) => _horseFinder.FindHorseByWins(wins);

        public List<Horse> GetHorsesByLosses(int losses) => _horseFinder.FindHorsesByLosses(losses);

        public List<Horse> GetHorsesByName(string name) => _horseFinder.FindHorseByName(name);
    }
}
