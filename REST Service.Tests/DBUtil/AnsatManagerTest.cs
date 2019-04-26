using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ModelLibary.Models;
using REST_Service.DBUtil;

namespace REST_Service.Tests.DBUtil
{
    [TestClass]
    public class AnsatManagerTest
    {
        //[UnitOfWork_StateUnderTest_ExpectedBehavior]

        private AnsatManager manager;

        [TestInitialize]
        public void TestInitialize()
        {
            manager = new AnsatManager();
        }


        [TestMethod]
        public void Get_AnExistingUser_True()
        {


            //Arrange

            

            //Act


            //Assert


        }

        [TestMethod]
        public void Post_AUser_True()
        {
            //Arrange

            Ansat trialAnsat = new Ansat("AB", "Anders Bunde", 25);

            //Act

            bool status = manager.Post(trialAnsat);

            //Assert

            Assert.IsTrue(status);

            manager.Delete(trialAnsat.Initial);
        }

        [TestMethod]
        public void Delete_AnExistingUser_true()
        {

            //Arrange



            //Act


            //Assert

        }

    }
}
