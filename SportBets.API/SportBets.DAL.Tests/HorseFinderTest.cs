using System.Collections.Generic;
using System.Linq;
using Moq.EntityFramework;
using SportBets.BLL.Entities;
using SportBets.DAL.EntitiesContext;
using SportBets.DAL.Finder;
using Xunit;

namespace SportBets.DAL.Tests
{
    public class HorseFinderTest
    {
        private readonly Horse _horse = new Horse
        {
            Age = 10,
            Id = 1,
            HorseName = "Kylo",
            LossesCount = 12,
            Weight = 32.2F,
            WinsCount = 40
        };
        private HorseFinder _horseFinder;
        private readonly List<Horse> _list = new List<Horse>();


        [Fact]
        public void FindById()
        {
            //initiallizing
            var context = DbContextMockFactory.Create<SportBetsContext>();
            _list.Add(_horse);
            var mockedSet = context.MockSetFor<Horse>(_list);
            _horseFinder = new HorseFinder(mockedSet.Object.Horses);
            
            //act
            var result = _horseFinder.FindHorseById(_horse.Id);

            //assert
            Assert.Equal(_horse.Id, result.First().Id);
        }

        [Fact]
        public void FindByWins()
        {
            //initiallizing
            var context = DbContextMockFactory.Create<SportBetsContext>();
            _list.Add(_horse);
            var mockedSet = context.MockSetFor<Horse>(_list);
            _horseFinder = new HorseFinder(mockedSet.Object.Horses);

            //act
            var result = _horseFinder.FindHorseByWins(_horse.WinsCount);

            //assert
            Assert.Equal(_horse.WinsCount, result.First().WinsCount);
        }

        [Fact]
        public void FindByAge()
        {
            //initiallizing
            var context = DbContextMockFactory.Create<SportBetsContext>();
            _list.Add(_horse);
            var mockedSet = context.MockSetFor<Horse>(_list);
            _horseFinder = new HorseFinder(mockedSet.Object.Horses);

            //act
            var result = _horseFinder.FindHorsesByAge(_horse.Age);

            //assert
            Assert.Equal(_horse.Age, result.First().Age);
        }

        [Fact]
        public void FindByLosses()
        {
            //initiallizing
            var context = DbContextMockFactory.Create<SportBetsContext>();
            _list.Add(_horse);
            var mockedSet = context.MockSetFor<Horse>(_list);
            _horseFinder = new HorseFinder(mockedSet.Object.Horses);

            //act
            var result = _horseFinder.FindHorsesByLosses(_horse.LossesCount);

            //assert
            Assert.Equal(_horse.LossesCount, result.First().LossesCount);
        }

        [Fact]
        public void FindByName()
        {
            //initiallizing
            var context = DbContextMockFactory.Create<SportBetsContext>();
            _list.Add(_horse);
            var mockedSet = context.MockSetFor<Horse>(_list);
            _horseFinder = new HorseFinder(mockedSet.Object.Horses);

            //act
            var result = _horseFinder.FindHorseByName(_horse.HorseName);

            //assert
            Assert.Equal(_horse.HorseName, result.First().HorseName);
        }

        [Fact]
        public void FindByWeight()
        {
            //initiallizzing
            var context = DbContextMockFactory.Create<SportBetsContext>();
            _list.Add(_horse);
            var mockedSet = context.MockSetFor<Horse>(_list);
            _horseFinder = new HorseFinder(mockedSet.Object.Horses);

            //act
            var result = _horseFinder.FindHorsesByWeight(_horse.Weight);

            //assert
            Assert.Equal(_horse.Weight, result.First().Weight);
        }
    }
}
