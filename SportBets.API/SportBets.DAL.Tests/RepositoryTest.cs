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
        private readonly Bet _bet = new Bet();


        [Fact]
        public void CreateEntity()
        {
            
            //initiallizing
            var context = DbContextMockFactory.Create<SportBetsContext>();
            var setMock = context.MockedSet<Bet>();
            var repository = new Repository<Bet>(setMock.Object);
            setMock.Setup(x => x.Add(_bet))
                .Returns(_bet);
                
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
            var mockedSet = context.MockedSet<Bet>();
            var repository = new Repository<Bet>(mockedSet.Object);
            mockedSet.Setup(x => x.Remove(_bet));
                
            //act
            repository.Delete(_bet);

            //assert
            mockedSet.Verify(x => x.Remove(_bet), Times.Once);

        }

       [Fact]
       public void GetAllEntities()
       {
           //initiallizing
           var context = DbContextMockFactory.Create<SportBetsContext>();
           context.MockedSet<Bet>();
           var repository = new Repository<Bet>(context.Object.Bets);
               
          
           //act
           repository.GetAll();

           //assert
          
       }
   }
}
