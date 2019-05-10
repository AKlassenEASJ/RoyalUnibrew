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
        public void TestMethod1()
        {
            FaerdigVareManager Manager = new FaerdigVareManager();

            
            FaerdigVare ny = new FaerdigVare(2, "name", 1,3,2);
            bool res = Manager.Post(ny);
            //Assert.AreEqual(res, Manager.Post(ny));
            Assert.IsTrue(res);
        }
    }
}
