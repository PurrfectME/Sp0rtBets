using System.Collections.Generic;
using Moq;
using SportBets.BLL.Entities;
using SportBets.BLL.InterfaceForFinders;
using SportBets.BLL.Interfaces;
using SportBets.BLL.Services;
using Xunit;

namespace SportBets.BLL.Tests
{
    public class BasketballTeamServiceTest
    {
        [Fact]
        public void CreateTeam()
        {   
            //arrange
            var basketballTeam = new BasketballTeam();
            var teamCollection = new Mock<IRepository<BasketballTeam>>();
            var unitOfWork = new Mock<IUnitOfWork>();
            var teamFinder = new Mock<IBasketballTeamFinder>();

            var basketballTeamService = new BasketballTeamService(unitOfWork.Object, teamFinder.Object, teamCollection.Object);
            
            //act
            teamCollection.Setup(x => x.Create(basketballTeam))
                .Returns(basketballTeam);

            basketballTeamService.CreateTeam(basketballTeam);
            
            //test
            teamCollection.Verify(x => x.Create(It.IsAny<BasketballTeam>()), Times.Once);
        }

        [Fact]
        public void DeleteTeam()
        {
            //initiallizing
            var basketballTeam = new BasketballTeam();
            var unitOfWork = new Mock<IUnitOfWork>();
            var teamFinder = new Mock<IBasketballTeamFinder>();
            var teamCollection = new Mock<IRepository<BasketballTeam>>();

            var basketballTeamService = new BasketballTeamService(unitOfWork.Object, teamFinder.Object, teamCollection.Object);

            //act
            teamCollection.Setup(x => x.Delete(basketballTeam));
            basketballTeamService.DeleteTeam(basketballTeam);

            //assert
            teamCollection.Verify(x => x.Delete(It.IsAny<BasketballTeam>()), Times.Once);
        }

        [Fact]
        public void GetTeamById()
        {
            var unitOfWork = new Mock<IUnitOfWork>();
            var teamFinder = new Mock<IBasketballTeamFinder>();
            var teamCollection = new Mock<IRepository<BasketballTeam>>();
            var team = new BasketballTeam();

            var basketballTeamService = new BasketballTeamService(unitOfWork.Object, teamFinder.Object, teamCollection.Object);

            teamFinder.Setup(x => x.FindBasketballTeamById(team))
                .Returns(new List<BasketballTeam>());

            basketballTeamService.GetTeamById(team);

            teamFinder.Verify(x => x.FindBasketballTeamById(It.IsAny<BasketballTeam>()));
        }

        [Fact]
        public void GetTeamByName()
        {
            //initiallizing
            var team = new BasketballTeam();
            var finder = new Mock<IBasketballTeamFinder>();
            var unitOfWork = new Mock<IUnitOfWork>();
            var teamCollection = new Mock<IRepository<BasketballTeam>>();

            var service = new BasketballTeamService(unitOfWork.Object, finder.Object, teamCollection.Object);

            //act
            finder.Setup(x => x.FindBasketballTeamsByTeamname(team))
                .Returns(new List<BasketballTeam>());

            service.GetTeambyName(team);

            //assert
            finder.Verify(x => x.FindBasketballTeamsByTeamname(It.IsAny<BasketballTeam>()));
        }

        [Fact]
        public void GetTeamsByWins()
        {
            //initiallizing
            var team = new BasketballTeam();
            var unitOfWork = new Mock<IUnitOfWork>();
            var finder = new Mock<IBasketballTeamFinder>();
            var teamCollection = new Mock<IRepository<BasketballTeam>>();

            var service = new BasketballTeamService(unitOfWork.Object, finder.Object, teamCollection.Object);

            //act
            finder.Setup(x => x.FindBasketballTeamsByWins(team))
                .Returns(new List<BasketballTeam>());

            service.GetTeamsByWins(team);

            //assert
            finder.Verify(x => x.FindBasketballTeamsByWins(It.IsAny<BasketballTeam>()));
        }

        [Fact]
        public void GetTeamsByLosses()
        {
            //initiallizing
            var team = new BasketballTeam();
            var unitOfWork = new Mock<IUnitOfWork>();
            var finder = new Mock<IBasketballTeamFinder>();
            var teamCollection = new Mock<IRepository<BasketballTeam>>();

            var service = new BasketballTeamService(unitOfWork.Object, finder.Object, teamCollection.Object);

            //act
            finder.Setup(x => x.FindBasketballTeamsByLosses(team))
                .Returns(new List<BasketballTeam>());

            service.GetTeamsByLosses(team);

            //assert
            finder.Verify(x => x.FindBasketballTeamsByLosses(It.IsAny<BasketballTeam>()));
        }

    }
}
