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

        #region InstanceFields
        private AnsatManager _manager;
        private Ansat _trialAnsat;
        #endregion

        [TestInitialize]
        public void TestInitialize()
        {
            _manager = new AnsatManager();
            _trialAnsat = new Ansat("AB", "Anders Bunde", 25);
        }


        [TestMethod]
        public void Get_AnExistingUser_True()
        {


            //Arrange

            _manager.Post(_trialAnsat);


            //Act

            Ansat tempAnsat = _manager.Get(_trialAnsat.Initial);


            //Assert

            Assert.AreEqual(_trialAnsat.Initial, tempAnsat.Initial);
            Assert.AreEqual(_trialAnsat.Navn, tempAnsat.Navn);
            Assert.AreEqual(_trialAnsat.Id, tempAnsat.Id);

            _manager.Delete(_trialAnsat.Initial);

        }

        [TestMethod]
        public void Post_AUser_True()
        {
            //Arrange

            

            //Act

            bool status = _manager.Post(_trialAnsat);

            //Assert

            Assert.IsTrue(status);

            _manager.Delete(_trialAnsat.Initial);
        }

        [TestMethod]
        public void Delete_AnExistingUser_true()
        {

            //Arrange

            _manager.Post(_trialAnsat);


            //Act

            bool status = _manager.Delete(_trialAnsat.Initial);


            //Assert

            Assert.IsTrue(status);

        }

        [TestMethod]
        public void Delete_ANonExistingUser_False()
        {

            //Arrange

            //Act

            bool status =_manager.Delete(_trialAnsat.Initial);

            //Assert
            Assert.IsFalse(status);


        }

    }
}
