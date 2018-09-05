using System.Collections.Generic;
using Moq;
using SportBets.BLL.Entities;
using SportBets.BLL.InterfaceForFinders;
using SportBets.BLL.Interfaces;
using SportBets.BLL.Services;
using Xunit;

namespace SportBets.BLL.Tests
{
    public class FootballTeamServiceTest
    {
        [Fact]
        public void CreateTeam()
        {
            //arrange
            var basketballTeam = new FootballTeam();
            var teamCollection = new Mock<IRepository<FootballTeam>>();
            var unitOfWork = new Mock<IUnitOfWork>();
            var teamFinder = new Mock<IFootballTeamFinder>();

            var basketballTeamService = new FootballTeamService(unitOfWork.Object, teamFinder.Object, teamCollection.Object);

            //act
            teamCollection.Setup(x => x.Create(basketballTeam))
                .Returns(basketballTeam);

            basketballTeamService.CreateTeam(basketballTeam);

            //test
            teamCollection.Verify(x => x.Create(It.IsAny<FootballTeam>()), Times.Once);
        }

        [Fact]
        public void DeleteTeam()
        {
            //initiallizing
            var basketballTeam = new FootballTeam();
            var unitOfWork = new Mock<IUnitOfWork>();
            var teamFinder = new Mock<IFootballTeamFinder>();
            var teamCollection = new Mock<IRepository<FootballTeam>>();

            var basketballTeamService = new FootballTeamService(unitOfWork.Object, teamFinder.Object, teamCollection.Object);

            //act
            teamCollection.Setup(x => x.Delete(basketballTeam));
            basketballTeamService.DeleteTeam(basketballTeam);

            //assert
            teamCollection.Verify(x => x.Delete(It.IsAny<FootballTeam>()), Times.Once);
        }

        [Fact]
        public void GetTeamById()
        {
            var unitOfWork = new Mock<IUnitOfWork>();
            var teamFinder = new Mock<IFootballTeamFinder>();
            var teamCollection = new Mock<IRepository<FootballTeam>>();
            var team = new FootballTeam();

            var basketballTeamService = new FootballTeamService(unitOfWork.Object, teamFinder.Object, teamCollection.Object);

            teamFinder.Setup(x => x.FindFootballTeamById(team.Id))
                .Returns(new List<FootballTeam>());

            basketballTeamService.GetTeamsById(team.Id);

            teamFinder.Verify(x => x.FindFootballTeamById(It.IsAny<int>()));
        }

        [Fact]
        public void GetTeamByName()
        {
            //initiallizing
            var team = new FootballTeam();
            var finder = new Mock<IFootballTeamFinder>();
            var unitOfWork = new Mock<IUnitOfWork>();
            var teamCollection = new Mock<IRepository<FootballTeam>>();

            var service = new FootballTeamService(unitOfWork.Object, finder.Object, teamCollection.Object);

            //act
            finder.Setup(x => x.FindFootballTeamsByTeamname(team.TeamName))
                .Returns(new List<FootballTeam>());

            service.GetTeamsByName(team.TeamName);

            //assert
            finder.Verify(x => x.FindFootballTeamsByTeamname(It.IsAny<string>()));
        }

        [Fact]
        public void GetTeamsByWins()
        {
            //initiallizing
            var team = new FootballTeam();
            var unitOfWork = new Mock<IUnitOfWork>();
            var finder = new Mock<IFootballTeamFinder>();
            var teamCollection = new Mock<IRepository<FootballTeam>>();

            var service = new FootballTeamService(unitOfWork.Object, finder.Object, teamCollection.Object);

            //act
            finder.Setup(x => x.FindFootballTeamsByWins(team.WinsCount))
                .Returns(new List<FootballTeam>());

            service.GetTeamsByWins(team.WinsCount);

            //assert
            finder.Verify(x => x.FindFootballTeamsByWins(It.IsAny<int>()));
        }

        [Fact]
        public void GetTeamsByLosses()
        {
            //initiallizing
            var team = new FootballTeam();
            var unitOfWork = new Mock<IUnitOfWork>();
            var finder = new Mock<IFootballTeamFinder>();
            var teamCollection = new Mock<IRepository<FootballTeam>>();

            var service = new FootballTeamService(unitOfWork.Object, finder.Object, teamCollection.Object);

            //act
            finder.Setup(x => x.FindFootballTeamsByLosses(team.LossesCount))
                .Returns(new List<FootballTeam>());

            service.GetTeamsByLosses(team.LossesCount);

            //assert
            finder.Verify(x => x.FindFootballTeamsByLosses(It.IsAny<int>()));
        }
    }
}
