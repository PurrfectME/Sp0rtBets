using System.Collections.Generic;
using System.Linq;
using Moq.EntityFramework;
using SportBets.BLL.Entities;
using SportBets.DAL.EntitiesContext;
using SportBets.DAL.Finder;
using Xunit;

namespace SportBets.DAL.Tests
{
    public class BasketballTeamFinderTest
    {
        private readonly BasketballTeam _basketballTeam = new BasketballTeam{Id = 54, WinsCount = 12, LossesCount = 3, TeamName = "Spark"};
        private readonly List<BasketballTeam> _list = new List<BasketballTeam>();
        private BasketballTeamFinder _teamFinder;

        [Fact]
        public void FindById()
        {
            //initiallizing
            var context = DbContextMockFactory.Create<SportBetsContext>();
            _list.Add(_basketballTeam);
            var mockedSet = context.MockSetFor<BasketballTeam>(_list);
            _teamFinder = new BasketballTeamFinder(mockedSet.Object.BasketballTeams);

            //act
            var result = _teamFinder.FindBasketballTeamById(_basketballTeam.Id);

            //assert
            Assert.Equal(_basketballTeam.Id, result.First().Id);
        }

        [Fact]
        public void FindByName()
        {
            //initiallizing
            var context = DbContextMockFactory.Create<SportBetsContext>();
            _list.Add(_basketballTeam);
            var mockedSet = context.MockSetFor<BasketballTeam>(_list);
            _teamFinder = new BasketballTeamFinder(mockedSet.Object.BasketballTeams);

            //act
            var result = _teamFinder.FindBasketballTeamsByTeamname(_basketballTeam.TeamName);

            //assert
            Assert.Equal(_basketballTeam.TeamName, result.First().TeamName);
        }

        [Fact]
        public void FindByWins()
        {
            //initiallizing
            var context = DbContextMockFactory.Create<SportBetsContext>();
            _list.Add(_basketballTeam);
            var mockedSet = context.MockSetFor<BasketballTeam>(_list);
            _teamFinder = new BasketballTeamFinder(mockedSet.Object.BasketballTeams);

            //act
            var result = _teamFinder.FindBasketballTeamsByWins(_basketballTeam.WinsCount);

            //assert
            Assert.Equal(_basketballTeam.WinsCount, result.First().WinsCount);
        }

        [Fact]
        public void FindByLosses()
        {
            //initiallizing
            var context = DbContextMockFactory.Create<SportBetsContext>();
            _list.Add(_basketballTeam);
            var mockedSet = context.MockSetFor<BasketballTeam>(_list);
            _teamFinder = new BasketballTeamFinder(mockedSet.Object.BasketballTeams);

            //act
            var result = _teamFinder.FindBasketballTeamsByLosses(_basketballTeam.LossesCount);

            //assert
            Assert.Equal(_basketballTeam.LossesCount, result.First().LossesCount);
        }
    }
}
