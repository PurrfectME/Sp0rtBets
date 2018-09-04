using Moq;
using Moq.EntityFramework;
using SportBets.BLL.Entities;
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
            var context = DbContextMockFactory.Create<SportBetsContext>();
            var setMock = context.MockedSet<Bet>();
            var repository = new Repository<Bet>(context.Object.Bets);

            //act
            repository.Create(new Bet());

            //assert
            setMock.Verify(x => x.Add(It.IsAny<Bet>()), Times.Once);
        }

        [Fact]
        public void DeleteEntity()
        {
            //initiallizing
            var context = DbContextMockFactory.Create<SportBetsContext>();
            var setMock = context.MockedSet<Bet>();
            var respository = new Repository<Bet>(context.Object.Bets);

            //act
            respository.Delete(new Bet());

            //assert
            setMock.Verify(x => x.Remove(It.IsAny<Bet>()), Times.Once);

        }

       [Fact]
       public void GetAllEntities()
       {
           //initiallizing
           var context = DbContextMockFactory.Create<SportBetsContext>();
           var setMock = context.MockedSet<Bet>();
           var repository = new Repository<Bet>(context.Object.Bets);

           //act
           repository.GetAll();

           //assert
           setMock.Verify();
       }
   }
}
