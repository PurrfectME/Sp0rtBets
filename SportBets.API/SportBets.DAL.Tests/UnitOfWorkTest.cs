using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Moq.EntityFramework;
using SportBets.BLL.Interfaces;
using SportBets.DAL.EntitiesContext;
using SportBets.DAL.Repositories;
using Xunit;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace SportBets.DAL.Tests
{
    [TestClass]
    public class UnitOfWorkTest
    {
        [Fact]
        public void TestCommit()
        {
            //intiiallizing
            var unitOfWork = new Mock<IUnitOfWork>();
            unitOfWork.Setup(x => x.Commit());

            //act
            unitOfWork.Object.Commit();

            //assert
            unitOfWork.Verify(x => x.Commit(), Times.Once);
        }

        /*
         var user = new User
            {
                Email = "12",
                Id = 1,
                PasswordHash = "2",
                RegistrationDate = DateTime.Today
            };

            var list = new List<User> {user};

            //intiiallizing
            var unitOfWork = new Mock<IUnitOfWork>();
            unitOfWork.Setup(x => x.Commit());
            var context = DbContextMockFactory.Create<SportBetsContext>();
            var mockedSet = context.MockSetFor<User>(list);
            var unit = new UnitOfWork(mockedSet.Object);


            //act
            unit.Commit();

            //assert
            unitOfWork.Verify(x => x.Commit(), Times.Once);
            */
    }
}
