using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ModelLibary.Models;
using REST_Service.DBUtil;

namespace REST_Service.Tests.DBUtil
{
    [TestClass]
    public class ProcessOrdreManagerTest
    {
        #region InstanceFields
        private ProcessOrdreManager _processOrdreManager;
        private ProcessOrdre _processOrdre;
        private bool _result;
        #endregion

        [TestInitialize]
        public void TestInitialize()
        {
            _processOrdreManager = new ProcessOrdreManager();
            _processOrdre = new ProcessOrdre(9000000, 1, DateTime.Now);
            _processOrdreManager.Delete(_processOrdre.ProcessOrdreNr);

        }


        [TestMethod]
        public void PostProcessOrdre()
        {
            _result = _processOrdreManager.Post(_processOrdre);
            Assert.IsTrue(_result);
        }
    }
}