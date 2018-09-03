using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.InteropServices;
using SportBets.BLL.Entities;
using SportBets.BLL.InterfaceForFinders;

namespace SportBets.DAL.Finder
{
    public class HorseFinder : BaseFinder<Horse> , IHorseFinder
    {
        public HorseFinder(DbSet<Horse> entities) : base(entities)
        {
        }

        public List<Horse> FindHorseById(Horse horse)
        {
            var result = Find().Where(x => x.Id.Equals(horse.Id)).ToList();

            return result;
        }

        public List<Horse> FindHorsesByAge(Horse horse)
        {
            var result = Find().Where(x => x.Age.Equals(horse.Age)).OrderByDescending(x => x.HorseName).ToList();

            return result;
        }

        public List<Horse> FindHorseByWins(Horse horse)
        {
            var result = Find().Where(x => x.WinsCount.Equals(horse.WinsCount)).OrderBy(x => x.HorseName).ToList();

            return result;
        }

        public List<Horse> FindHorsesByLosses(Horse horse)
        {
            var result = Find().Where(x => x.LossesCount.Equals(horse.LossesCount)).OrderBy(x => x.HorseName).ToList();

            return result;
        }

        public List<Horse> FindHorseByName(Horse horse)
        {
            var result = Find().Where(x => x.HorseName.Equals(horse.HorseName)).ToList();

            return result;
        }

        public List<Horse> FindHorsesByWeight(Horse horse)
        {
            var result = Find().Where(x => x.Weight.Equals(horse.Weight)).ToList();

            return result;
        }
    }
}
