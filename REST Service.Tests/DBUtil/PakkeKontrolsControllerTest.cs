using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ModelLibary.Models;
using REST_Service.Controllers;

namespace REST_Service.Tests.DBUtil
{
    [TestClass]
    public class PakkeKontrolsControllerTest
    {
        [TestMethod]
        public void TestGet()
        {
            //Arrange
            PakkeKontrolsController con = new PakkeKontrolsController();

            List<PakkeKontrol> list = new List<PakkeKontrol>();

            int Før = list.Count;
            list = con.GetPakkeKontrol();
            int efter = list.Count;

            Assert.AreNotEqual(Før, efter);
        }

        [TestMethod]
        public void PostWithNull()
        {
            //Arange
            PakkeKontrolsController con = new PakkeKontrolsController();
            //PakkeKontrol Pk = new PakkeKontrol(1, DateTime.Now, null, 12, 12, DateTime.Now, DateTime.Now, "ngf", "gn", null, null, null, null, "nf", "ngf", -1, -1, -1, "ok", 45, null, "o");
            

            int før = con.GetPakkeKontrol().Count + 1;
            con.PostPakkeKontrol(new PakkeKontrol(1, DateTime.Now, null, 12, 12, DateTime.Now, DateTime.Now, "ngf", "gn", null, null, null, null, "nf", "ngf", -1, -1, -1, "ok", 45, null, "o"));
            int efter = con.GetPakkeKontrol().Count;

            Assert.AreEqual(før, efter);

        }
    }
}
