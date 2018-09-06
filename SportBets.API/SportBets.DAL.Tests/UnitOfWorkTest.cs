using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Moq.EntityFramework;
using SportBets.BLL.Entities;
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
            var context = DbContextMockFactory.Create<SportBetsContext>();
            var unitOfWork = new UnitOfWork(context.Object);
           
            //act
            unitOfWork.Commit();

            //assert
            context.Verify(x => x.SaveChanges(), Times.Once);
        }

        
         
            
    }
}
