using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ModelLibary.Models;
using REST_Service.DBUtil;

namespace REST_Service.Tests.DBUtil
{
    [TestClass]
    public class FaerdigVareManagerTest
    {
        [TestMethod]
        public void Post_NewFaerdigVare_True()
        {
            FaerdigVareManager Manager = new FaerdigVareManager();

            //Arrange
            FaerdigVare ny = new FaerdigVare(1245, "Test", 1.0,3.0,2.0);

            //Act
            bool res = Manager.Post(ny);
            Manager.Delete(1245);

            //Assert
            Assert.IsTrue(res);
        }

        [TestMethod]
        public void Put_ExistingFaerdigVare_True()
        {
            FaerdigVareManager Manager = new FaerdigVareManager();

            //Arrange
            Manager.Post(new FaerdigVare(124, "Test", 1.0, 3.0, 2.0));
            FaerdigVare edit = new FaerdigVare(124, "Test", 2.0,3.0,4.0);
            
            //Act
            bool res = Manager.Put(124, edit);
            Manager.Delete(124);

            //Assert
            Assert.IsTrue(res);
        }
    }
}
