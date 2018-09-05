using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using SportBets.BLL.Entities;
using SportBets.BLL.InterfaceForFinders;

namespace SportBets.DAL.Finder
{
    public class BetFinder : BaseFinder<Bet>, IBetFinder
    {
        public BetFinder(IDbSet<Bet> entities) : base(entities)
        {
        }
 
        public List<Bet> FindBetsByType(ItemType betType)
        {
            var result = Find().Where(x => x.BetItemType == betType).ToList();

            return result;
        }

        public List<Bet> FindBetsByDate(DateTime date)
        {
            var result = Find().Where(x => x.BetDate == date).OrderBy(x => x).ToList();

            return result;
        }

        public List<Bet> FindBetsById(int id)
        {
            var result = Find().Where(x => x.Id == id).ToList();

            return result;
        }

        public List<Bet> FindAllBets()
        {
            var allBets = Find().ToList();

            return allBets;
        }
    }
}
