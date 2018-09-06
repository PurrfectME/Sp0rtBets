using System;
using System.Collections.Generic;
using System.Linq;
using Moq;
using Moq.EntityFramework;
using SportBets.BLL.Entities;
using SportBets.BLL.InterfaceForFinders;
using SportBets.BLL.Interfaces;
using SportBets.DAL.EntitiesContext;
using SportBets.DAL.Finder;
using Xunit;

namespace SportBets.DAL.Tests
{
    public class BetFinderTest
    {
        private static readonly User _user = new User { Id = 32, Email = "12", PasswordHash = "34", RegistrationDate = DateTime.Today };
        private readonly Bet _bet = new Bet
        {
            BetDate = DateTime.Today,
            BetItemType = ItemType.Horse,
            Coefficient = 1.065,
            Id = 1,
            UserId = _user
        };
        private readonly List<Bet> _list = new List<Bet>();
        private IBetFinder _betFinder;

        [Fact]
        public void FindByType()
        {
            //initiallizing
            var context = DbContextMockFactory.Create<SportBetsContext>();
            _list.Add(_bet);
            var mockedSet = context.MockSetFor<Bet>(_list);
            _betFinder = new BetFinder(mockedSet.Object.Bets);

            //act
            var result = _betFinder.FindBetsByType(_bet.BetItemType);

            //assert
            Assert.Equal(_bet.BetItemType, result.First().BetItemType);
        }

        [Fact]
        public void FindByDate()
        {
            //intiallizing
            var context = DbContextMockFactory.Create<SportBetsContext>();
            _list.Add(_bet);
            var mockedSet = context.MockSetFor<Bet>(_list);
            _betFinder = new BetFinder(mockedSet.Object.Bets);

            //act
            var result = _betFinder.FindBetsByDate(_bet.BetDate);

            //assert
            Assert.Equal(_bet.BetDate, result.First().BetDate);
        }

        [Fact]
        public void FindById()
        {
            //intiallizing
            var context = DbContextMockFactory.Create<SportBetsContext>();
            _list.Add(_bet);
            var mockedSet = context.MockSetFor<Bet>(_list);
            _betFinder = new BetFinder(mockedSet.Object.Bets);

            //act
            var result = _betFinder.FindBetsById(_bet.Id);

            //assert
            Assert.Equal(_bet.Id, result.First().Id);
        }

        [Fact]
        public void FindAllBets()
        {
              
            //initiallizing
            var context = DbContextMockFactory.Create<SportBetsContext>();
            _list.Add(_bet);
            var set = context.MockSetFor<Bet>(_list);

            _betFinder = new BetFinder(set.Object.Bets);
                
                  

            //act
            _betFinder.FindAllBets();
        }
    }
}
