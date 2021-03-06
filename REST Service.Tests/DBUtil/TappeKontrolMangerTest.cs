﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ModelLibrary.Models;
using REST_Service.DBUtil;

namespace REST_Service.Tests.DBUtil
{
    [TestClass]
    public class TappeKontrolMangerTest
    {
        [TestMethod]
        public void TestGet()
        {
            // Arrange
            TappeKontrolManger manger = new TappeKontrolManger();
            List<TappeKontrol> liste = new List<TappeKontrol>();
            

            //// Act
            
            int resFør = liste.Count;
            int resEfter = manger.Get().Count();

            // Assert
            
            Assert.AreNotEqual(resFør, resEfter);
            
        }

        [TestMethod]
        public void TestPostMedNogleNull()
        {
            // Arrange
            TappeKontrolManger manger = new TappeKontrolManger();
            
            
            //// Act
            bool res = manger.Post(new TappeKontrol(1, DateTime.Now, 2, 2, "o", null, null, 2, 2, null, 0, 0, null,
                null, null, 0, "o"));
            

            // Assert
            Assert.IsTrue(res);
            
        }

        [TestMethod]
        public void TestPostHvorKanErNull()
        {
            //Arrange
            TappeKontrolManger manger = new TappeKontrolManger();

            //Act
            bool res = manger.Post(new TappeKontrol(1, DateTime.Now, 2,2, null, null, null, 2,2, null, -1, -1, null, null, null, -1, "o"));

            //Assert
            Assert.IsTrue(res);
        }
    }
}
