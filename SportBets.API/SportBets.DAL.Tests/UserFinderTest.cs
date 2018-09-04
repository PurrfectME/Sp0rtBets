using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq.EntityFramework;
using SportBets.BLL.Entities;
using SportBets.DAL.EntitiesContext;
using SportBets.DAL.Finder;
using Xunit;
using Assert = Xunit.Assert;


namespace SportBets.DAL.Tests
{
    [TestClass]
    public class UserFinderTest
    {
        [Fact]
        public void FindById()
        {
            var user = new User {
                Id = 1,
                Email = "1",
                PasswordHash = "3",
                RegistrationDate = DateTime.Now
            };
            
            var context = DbContextMockFactory.Create<SportBetsContext>();
            var mockedSet = context.MockedSet<User>();

            var userFinder = new UserFinder(mockedSet.Object);

            var list = new List<User> {user};


            userFinder.FindUserById(user.Id);

            Assert.Equal(1, list[0].Id);

        }
        
    }
}
