using System.Collections.Generic;
using Moq;
using SportBets.BLL.Entities;
using SportBets.BLL.InterfaceForFinders;
using SportBets.BLL.Interfaces;
using SportBets.BLL.Services;
using Xunit;

namespace SportBets.BLL.Tests
{
    public class HorseServiceTest
    {
        [Fact]
        public void CreateHorse()
        {
            //initiallizing
            var horse = new Horse();
            var unitOfWork = new Mock<IUnitOfWork>();
            var finder = new Mock<IHorseFinder>();
            var horseCollection = new Mock<IRepository<Horse>>();

            var service = new HorseService(unitOfWork.Object, finder.Object, horseCollection.Object);

            //act
            horseCollection.Setup(x => x.Create(horse))
                .Returns(horse);

            service.CreateHorse(horse);

            //assert
            horseCollection.Verify(x => x.Create(It.IsAny<Horse>()), Times.Once);
        }

        [Fact]
        public void DeleteHorse()
        {
            //initiallizing
            var horse = new Horse();
            var unitOfWork = new Mock<IUnitOfWork>();
            var finder = new Mock<IHorseFinder>();
            var horseCollection = new Mock<IRepository<Horse>>();

            var service = new HorseService(unitOfWork.Object, finder.Object, horseCollection.Object);

            //act
            horseCollection.Setup(x => x.Delete(horse))
                .Returns(horse);

            service.DeleteHorse(horse);

            //assert
            horseCollection.Verify(x => x.Delete(It.IsAny<Horse>()), Times.Once);
        }

        [Fact]
        public void GetHorseById()
        {
            //initiallizing
            var horse = new Horse();
            var unitOfWork = new Mock<IUnitOfWork>();
            var finder = new Mock<IHorseFinder>();
            var horseCollection = new Mock<IRepository<Horse>>();

            var service = new HorseService(unitOfWork.Object, finder.Object, horseCollection.Object);

            //act
            finder.Setup(x => x.FindHorseById(horse))
                .Returns(new List<Horse>());

            service.GetHorseById(horse);

            //assert
            finder.Verify(x => x.FindHorseById(It.IsAny<Horse>()));
        }

        [Fact]
        public void GetHorseByName()
        {
            //initiallizing
            var horse = new Horse();
            var unitOfWork = new Mock<IUnitOfWork>();
            var finder = new Mock<IHorseFinder>();
            var horseCollection = new Mock<IRepository<Horse>>();

            var service = new HorseService(unitOfWork.Object, finder.Object, horseCollection.Object);

            //act
            finder.Setup(x => x.FindHorseByName(horse))
                .Returns(new List<Horse>());

            service.GetHorsesByName(horse);

            //assert
            finder.Verify(x => x.FindHorseByName(It.IsAny<Horse>()));
        }

        [Fact]
        public void GetHorsesByWeight()
        {
            //initiallizing
            var horse = new Horse();
            var unitOfWork = new Mock<IUnitOfWork>();
            var finder = new Mock<IHorseFinder>();
            var horseCollection = new Mock<IRepository<Horse>>();

            var service = new HorseService(unitOfWork.Object, finder.Object, horseCollection.Object);

            //act
            finder.Setup(x => x.FindHorsesByWeight(horse))
                .Returns(new List<Horse>());

            service.GetHorsesByWeight(horse);

            //assert
            finder.Verify(x => x.FindHorsesByWeight(It.IsAny<Horse>()));
        }

        [Fact]
        public void GetHorsesByWins()
        {
            //initiallizng
            var horse = new Horse();
            var unitOfWork = new Mock<IUnitOfWork>();
            var finder = new Mock<IHorseFinder>();
            var horseCollection = new Mock<IRepository<Horse>>();

            var service = new HorseService(unitOfWork.Object, finder.Object, horseCollection.Object);

            //act
            finder.Setup(x => x.FindHorseByWins(horse))
                .Returns(new List<Horse>());

            service.GetHorsesByWins(horse);

            //assert
            finder.Verify(x => x.FindHorseByWins(It.IsAny<Horse>()));
        }

        [Fact]
        public void GetHorsesByLosses()
        {
            //initiallizng
            var horse = new Horse();
            var unitOfWork = new Mock<IUnitOfWork>();
            var finder = new Mock<IHorseFinder>();
            var horseCollection = new Mock<IRepository<Horse>>();

            var service = new HorseService(unitOfWork.Object, finder.Object, horseCollection.Object);

            //act
            finder.Setup(x => x.FindHorsesByLosses(horse))
                .Returns(new List<Horse>());

            service.GetHorsesByLosses(horse);

            //assert
            finder.Verify(x => x.FindHorsesByLosses(It.IsAny<Horse>()));
        }

        [Fact]
        public void GetHorsesById()
        {
            //initiallizng
            var horse = new Horse();
            var unitOfWork = new Mock<IUnitOfWork>();
            var finder = new Mock<IHorseFinder>();
            var horseCollection = new Mock<IRepository<Horse>>();

            var service = new HorseService(unitOfWork.Object, finder.Object, horseCollection.Object);

            //act
            finder.Setup(x => x.FindHorseById(horse))
                .Returns(new List<Horse>());

            service.GetHorseById(horse);

            //assert
            finder.Verify(x => x.FindHorseById(It.IsAny<Horse>()));
        }

        [Fact]
        public void GetHorsesByAge()
        {
            //initiallizng
            var horse = new Horse();
            var unitOfWork = new Mock<IUnitOfWork>();
            var finder = new Mock<IHorseFinder>();
            var horseCollection = new Mock<IRepository<Horse>>();

            var service = new HorseService(unitOfWork.Object, finder.Object, horseCollection.Object);

            //act
            finder.Setup(x => x.FindHorsesByAge(horse))
                .Returns(new List<Horse>());

            service.GetHorsesByAge(horse);

            //assert
            finder.Verify(x => x.FindHorsesByAge(It.IsAny<Horse>()));
        }
    }
}
