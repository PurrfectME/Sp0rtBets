using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq.EntityFramework;
using SportBets.BLL.Entities;
using SportBets.DAL.EntitiesContext;
using SportBets.DAL.Finder;
using Xunit;

namespace SportBets.DAL.Tests
{
    public class FootballTeamFinderTest
    {
        private readonly FootballTeam _team =
            new FootballTeam {Id = 432, WinsCount = 12, LossesCount = 2, TeamName = "Oakwood"};

        private FootballTeamFinder _teamFinder;
        private readonly List<FootballTeam> _list = new List<FootballTeam>();


        [Fact]
        public void FindById()
        {
            //initiallizing
            var context = DbContextMockFactory.Create<SportBetsContext>();
            _list.Add(_team);
            var mockedSet = context.MockSetFor<FootballTeam>(_list);
            _teamFinder = new FootballTeamFinder(mockedSet.Object.FootballTeams);

            //act
            var result = _teamFinder.FindFootballTeamById(_team.Id);

            //aasert
            Assert.Equal(_team.Id, result.First().Id);
        }

        [Fact]
        public void FindByName()
        {
            //initiallizing
            var context = DbContextMockFactory.Create<SportBetsContext>();
            _list.Add(_team);
            var mockedSet = context.MockSetFor<FootballTeam>(_list);
            _teamFinder = new FootballTeamFinder(mockedSet.Object.FootballTeams);

            //act
            var result = _teamFinder.FindFootballTeamsByTeamname(_team.TeamName);

            //assert
            Assert.Equal(_team.TeamName, result.First().TeamName);
        }

        [Fact]
        public void FindByWins()
        {
            //initiallizing
            var context = DbContextMockFactory.Create<SportBetsContext>();
            _list.Add(_team);
            var mockedSet = context.MockSetFor<FootballTeam>(_list);
            _teamFinder = new FootballTeamFinder(mockedSet.Object.FootballTeams);

            //act
            var result = _teamFinder.FindFootballTeamsByWins(_team.WinsCount);

            //assert
            Assert.Equal(_team.WinsCount, result.First().WinsCount);
        }

        [Fact]
        public void FindByLosses()
        {
            //initiallizing
            var context = DbContextMockFactory.Create<SportBetsContext>();
            _list.Add(_team);
            var mockedSet = context.MockSetFor<FootballTeam>(_list);
            _teamFinder = new FootballTeamFinder(mockedSet.Object.FootballTeams);

            //act
            var result = _teamFinder.FindFootballTeamsByLosses(_team.LossesCount);

            //assert
            Assert.Equal(_team.LossesCount, result.First().LossesCount);
        }
    }
}

