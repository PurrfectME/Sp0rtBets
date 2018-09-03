using System;
using System.Collections.Generic;
using Moq;
using SportBets.BLL.Entities;
using SportBets.BLL.InterfaceForFinders;
using SportBets.BLL.Interfaces;
using SportBets.BLL.Services;
using Xunit;

namespace SportBets.BLL.Tests
{
    public class BetServiceTest
    {
        [Fact]
        public void CreateBet()
        {
            //initiallizing
            var bet = new Bet();
            var unitOfWork = new Mock<IUnitOfWork>();
            var finder = new Mock<IBetFinder>();
            var collection = new Mock<IRepository<Bet>>();

            var service = new BetService(unitOfWork.Object, finder.Object, collection.Object);

            //act
            collection.Setup(x => x.Create(bet))
                .Returns(new Bet());

            service.CreateBet(bet);

            //assert
            collection.Verify(x => x.Create(bet), Times.Once);
        }

        [Fact]
        public void DeleteBet()
        {
            //initiallizing
            var bet = new Bet();
            var unitOfWork = new Mock<IUnitOfWork>();
            var finder = new Mock<IBetFinder>();
            var collection = new Mock<IRepository<Bet>>();

            var service = new BetService(unitOfWork.Object, finder.Object, collection.Object);

            //act
            collection.Setup(x => x.Delete(bet))
                .Returns(new Bet());

            service.DeleteBet(bet);

            //assert
            collection.Verify(x => x.Delete(bet), Times.Once);
        }

        [Fact]
        public void GetBetById()
        {
            //initiallizing
            var bet = new Bet();
            var unitOfWork = new Mock<IUnitOfWork>();
            var finder = new Mock<IBetFinder>();
            var collection = new Mock<IRepository<Bet>>();

            var service = new BetService(unitOfWork.Object, finder.Object, collection.Object);

            //act
            finder.Setup(x => x.FindBetsById(bet))
                .Returns(new List<Bet>());

            service.GetBetById(bet);

            //assert
            finder.Verify(x => x.FindBetsById(It.IsAny<Bet>()));
        }

        [Fact]
        public void GetBetsByType()
        {
            //initiallizing
            var bet = new Bet();
            var unitOfWork = new Mock<IUnitOfWork>();
            var finder = new Mock<IBetFinder>();
            var collection = new Mock<IRepository<Bet>>();

            var service = new BetService(unitOfWork.Object, finder.Object, collection.Object);

            //act
            finder.Setup(x => x.FindBetsByType(bet.BetItemType))
                .Returns(new List<Bet>());

            service.GetBetsByType(bet);

            //assert
            finder.Verify(x => x.FindBetsByType(It.IsAny<ItemType>()));
        }

        [Fact]
        public void GetBetByDate()
        {
            //initiallizing
            var bet = new Bet();
            var unitOfWork = new Mock<IUnitOfWork>();
            var finder = new Mock<IBetFinder>();
            var collection = new Mock<IRepository<Bet>>();

            var service = new BetService(unitOfWork.Object, finder.Object, collection.Object);

            //act
            finder.Setup(x => x.FindBetsByDate(bet.BetDate))
                .Returns(new List<Bet>());

            service.GetBetsByDate(bet);

            //assert
            finder.Verify(x => x.FindBetsByDate(It.IsAny<DateTime>()));
        }

        [Fact]
        public void GetAllBets()
        {
            //initiallizing
            var unitOfWork = new Mock<IUnitOfWork>();
            var finder = new Mock<IBetFinder>();
            var collection = new Mock<IRepository<Bet>>();

            var service = new BetService(unitOfWork.Object, finder.Object, collection.Object);

            //act
            finder.Setup(x => x.FindAllBets())
                .Returns(new List<Bet>());

            service.GetAllBets();

            //assert
            finder.Verify(x => x.FindAllBets());
        }
    }
}
