using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SportBets.BLL.Interfaces;
using Xunit;

namespace SportBets.DAL.Tests
{
    [TestClass]
    public class UnitOfWorkTest
    {
        [TestMethod]
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
    }
}
