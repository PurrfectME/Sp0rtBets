using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SportBets.BLL.Interfaces;
using SportBets.DAL.EntitiesContext;
using SportBets.DAL.Repositories;
using Xunit;

namespace SportBets.DAL.Tests
{
   public class RepositoryTest
   {
        [Fact]
        public void CreateEntity()
        {
            //initiallizing
            var entity = new SportBetsContext();
            var repository = new Mock<IRepository<SportBetsContext>>();

            repository.Setup(x => x.Create(entity))
                .Returns(entity);

            //act
            repository.Object.Create(entity);

            //assert
            repository.Verify(x => x.Create(entity), Times.Once);
        }

        [Fact]
        public void DeleteEntity()
        {
            //initiallizing
            var entity = new SportBetsContext();
            var repository = new Mock<IRepository<SportBetsContext>>();

            repository.Setup(x => x.Delete(entity));
                

            //act
            repository.Object.Delete(entity);

            //assert
            repository.Verify(x => x.Delete(entity), Times.Once);
        }

       [Fact]
       public void GetAllEntities()
       {
           //initiallizing
           var repository = new Mock<IRepository<SportBetsContext>>();

            repository.Setup(x => x.GetAll())
                .Returns();
        }

      

   }
}
