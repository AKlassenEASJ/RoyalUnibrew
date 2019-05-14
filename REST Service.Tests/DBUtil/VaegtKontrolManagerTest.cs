using System;
using System.Linq;
using REST_Service.DBUtil;
using ModelLibrary.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ModelLibary.Models;

namespace REST_Service.Tests.DBUtil
{
    [TestClass]
    public class VaegtKontrolManagerTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            //Arrange


            VaegtKontrolManager vaegtKontrolManager = new VaegtKontrolManager();
            VaegtKontrol vK = new VaegtKontrol(1598290, 99, DateTime.Now);


            //Act


            int kontrollerFoer = vaegtKontrolManager.Get().Count();
            bool result = vaegtKontrolManager.Post(vK);
            int kontrollerEfter = vaegtKontrolManager.Get().Count();
            vaegtKontrolManager.Delete(vK.KontrolNr);
            

            //Assert


            Assert.IsTrue(result);
            Assert.AreEqual(kontrollerFoer + 1, kontrollerEfter);
            
        }
    }
}
