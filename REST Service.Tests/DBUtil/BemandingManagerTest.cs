using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ModelLibary.Models;
using REST_Service.DBUtil;

namespace REST_Service.Tests.DBUtil
{
    [TestClass]
    public class BemandingManagerTest
    {

        //[UnitOfWork_StateUnderTest_ExpectedBehavior]

        #region InstanceFields
        private BemandingManager _manager;
        private Bemanding _trialBemanding;
        #endregion

        [TestInitialize]
        public void TestInitialize()
        {
            _manager = new BemandingManager();
            _trialBemanding = new Bemanding(1, new DateTime(2019, 09, 05, 20, 50, 00, DateTimeKind.Local), new DateTime(2019, 09, 06, 20, 50, 00, DateTimeKind.Local), 10, "AB", 0);
        }


        [TestMethod]
        public void Post_ANewBemanding_True()
        {
            //Arrange


            //Act
            bool status = _manager.Post(_trialBemanding);

            //Assert

            Assert.IsTrue(status);

        }


    }
}
