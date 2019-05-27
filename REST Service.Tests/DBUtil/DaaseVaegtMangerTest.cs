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
    public class DaaseVaegtMangerTest
    {
        [TestMethod]
        public void TestPost()
        {
            DaaseVaegtManger manger = new DaaseVaegtManger();

            Assert.IsTrue(manger.Post(new DaaseVaegt(1, 1, 1, 320)));
        }

    }
}
