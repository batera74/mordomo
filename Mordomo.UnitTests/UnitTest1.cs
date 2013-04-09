using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Collections;

namespace Mordomo.UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void SaveEntity()
        {
            var factory = new Data.RepositoryFactory(); 
            Business.User userBiz = new Business.User(factory);

            var userNew = FakeEntities.Generator.CreateUser();
            var creditCardTypeNew = FakeEntities.Generator.CreateCreditCardType();
            var creditCardNew = FakeEntities.Generator.CreateCreditCard(creditCardTypeNew, userNew);

            var userSaved = userBiz.Save(userNew);

            Assert.IsNotNull(userSaved);
        }

        [TestMethod]
        public void DeleteEntity()
        {
            var factory = new Data.RepositoryFactory();
            Business.User userBiz = new Business.User(factory);
            
            var userFound = userBiz.Get(1);

            if (userFound == null)
                userFound = userBiz.Save(FakeEntities.Generator.CreateUser());

            int id = userFound.Id;

            userBiz.Delete(userFound);

            var userDeleted = userBiz.Get(id);

            Assert.IsNull(userDeleted);
        }

        [TestMethod]
        public void QueryEntity()
        {
            var factory = new Data.RepositoryFactory();
            Business.User userBiz = new Business.User(factory);

            int result = ((List<Entities.User>)userBiz.Query(u => u.Id > 0)).Count;

            int resultAll = ((List<Entities.User>)userBiz.GetAll()).Count;

            Assert.AreEqual(result, resultAll);
        }
    }
}
