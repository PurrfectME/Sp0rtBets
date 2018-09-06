using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using SportBets.BLL.Entities;
using SportBets.BLL.InterfaceForFinders;

namespace SportBets.DAL.Finder
{
    public class HorseFinder : BaseFinder<Horse> , IHorseFinder
    {
        public HorseFinder(IDbSet<Horse> entities) : base(entities)
        {
        }

        public List<Horse> FindHorseById(int id)
        {
            var result = Find().Where(x => x.Id.Equals(id)).ToList();

            return result;
        }

        public List<Horse> FindHorsesByAge(int age)
        {
            var result = Find().Where(x => x.Age.Equals(age)).OrderByDescending(x => x.HorseName).ToList();

            return result;
        }

        public List<Horse> FindHorseByWins(int wins)
        {
            var result = Find().Where(x => x.WinsCount.Equals(wins)).OrderBy(x => x.HorseName).ToList();

            return result;
        }

        public List<Horse> FindHorsesByLosses(int losses)
        {
            var result = Find().Where(x => x.LossesCount.Equals(losses)).OrderBy(x => x.HorseName).ToList();

            return result;
        }

        public List<Horse> FindHorseByName(string name)
        {
            var result = Find().Where(x => x.HorseName.Equals(name)).ToList();

            return result;
        }

        public List<Horse> FindHorsesByWeight(float weight)
        {
            var result = Find().Where(x => x.Weight.Equals(weight)).ToList();

            return result;
        }
    }
}
