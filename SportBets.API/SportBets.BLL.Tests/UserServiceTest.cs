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
    public class UserServiceTest
    {
        [Fact]
        public void CreateUser()
        {
            //initiallizing
            var user = new User();
            var unitOfWork = new Mock<IUnitOfWork>();
            var finder = new Mock<IUserFinder>();
            var userCollection = new Mock<IRepository<User>>();

            var service = new UserService(unitOfWork.Object, finder.Object, userCollection.Object);

            //act
            userCollection.Setup(x => x.Create(user))
                .Returns(user);

            service.CreateUser(user);

            //assert
            userCollection.Verify(x => x.Create(It.IsAny<User>()), Times.Once);
        }

        [Fact]
        public void DeleteUser()
        {
            //initiallizing
            var user = new User();
            var unitOfWork = new Mock<IUnitOfWork>();
            var finder = new Mock<IUserFinder>();
            var userCollection = new Mock<IRepository<User>>();

            var service = new UserService(unitOfWork.Object, finder.Object, userCollection.Object);

            //act
            userCollection.Setup(x => x.Delete(user))
                .Returns(user);

            service.DeleteUser(user);

            //assert
            userCollection.Verify(x => x.Delete(It.IsAny<User>()), Times.Once);
        }

        [Fact]
        public void GetUserById()
        {
            //initiallizing
            var user = new User();
            var unitOfWork = new Mock<IUnitOfWork>();
            var finder = new Mock<IUserFinder>();
            var userCollection = new Mock<IRepository<User>>();

            var service = new UserService(unitOfWork.Object, finder.Object, userCollection.Object);

            //act
            finder.Setup(x => x.FindUserById(user.Id))
                .Returns(new List<User>());

            service.GetUserById(user.Id);

            //assert
            finder.Verify(x => x.FindUserById(It.IsAny<int>()), Times.Once);
        }

        [Fact]
        public void GetUserByRegistrationDate()
        {
            //initiallizing
            var user = new User();
            var unitOfWork = new Mock<IUnitOfWork>();
            var finder = new Mock<IUserFinder>();
            var userCollection = new Mock<IRepository<User>>();

            var service = new UserService(unitOfWork.Object, finder.Object, userCollection.Object);

            //act
            finder.Setup(x => x.FindUsersByRegDate(user.RegistrationDate))
                .Returns(new List<User>());

            service.GetUsersByRegDate(user.RegistrationDate);

            //assert
            finder.Verify(x => x.FindUsersByRegDate(It.IsAny<DateTime>()));
        }

        [Fact]
        public void GetAllUsers()
        {
            //initiallizing
            var user = new User();
            var unitOfWork = new Mock<IUnitOfWork>();
            var finder = new Mock<IUserFinder>();
            var userCollection = new Mock<IRepository<User>>();

            var service = new UserService(unitOfWork.Object, finder.Object, userCollection.Object);

            //act
            finder.Setup(x => x.FindAllUsers())
                .Returns(new List<User>());

            service.GetAllUsers();
            //assert
            finder.Verify(x => x.FindAllUsers());
        }

    }
}
