using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Moq.EntityFramework;
using SportBets.BLL.Entities;
using SportBets.BLL.InterfaceForFinders;
using SportBets.DAL.EntitiesContext;
using SportBets.DAL.Finder;
using Xunit;
using Assert = Xunit.Assert;


namespace SportBets.DAL.Tests
{
    
    public class UserFinderTest
    {
        private readonly User _user = new User
        {
            Id = 1,
            Email = "1",
            PasswordHash = "3",
            RegistrationDate = DateTime.Now
        };
        private readonly List<User> _list = new List<User>();
        private UserFinder _userFinder;


        [Fact]
        public void FindById()
        {
            //initiallizing
            var context = DbContextMockFactory.Create<SportBetsContext>();
            _list.Add(_user);
            var mockedSet = context.MockSetFor<User>(_list);
            _userFinder = new UserFinder(mockedSet.Object.Users);

            //act
            var result = _userFinder.FindUserById(_user.Id);

            //assert
            Assert.Equal(_user.Id, result.First().Id);
        }

        [Fact]
        public void FindByRegDate()
        {
            //initiallizing
            var context = DbContextMockFactory.Create<SportBetsContext>();
            _list.Add(_user);
            var mockedSet = context.MockSetFor<User>(_list);
            _userFinder = new UserFinder(mockedSet.Object.Users);

            //act
            var result = _userFinder.FindUsersByRegDate(_user.RegistrationDate);

            //assert
            Assert.Equal(_user.RegistrationDate, result.First().RegistrationDate);
        }

        //[Fact]
        //public void FindAllUsers()
        //{
        //    //initiallizing
        //    var context = DbContextMockFactory.Create<SportBetsContext>();
        //    _list.Add(_user);
        //    var mockedSet = context.MockSetFor<User>(_list);
        //    _userFinder = new UserFinder(mockedSet.Object.Users);

        //    //act
        //    var result = _userFinder.FindAllUsers();

        //    //assert
        //    //Assert.Equal();


        //}
        
    }
}
