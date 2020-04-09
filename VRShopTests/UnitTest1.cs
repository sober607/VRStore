using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VRShop;

namespace VRShopTests
{
    [TestClass]
    public class RegistrationTests
    {
        [TestMethod]
        public void Password_Strength_4lowercases_1Points()
        {
            string password = "pass";
            int targetPoints = 1 ;
            Registration c = new Registration();
            int actualPoints = c.Password_Strength(password);
            Assert.AreEqual(targetPoints, actualPoints);
        }

        [TestMethod]
        public void Password_Strength_0cases_Points()
        {
            string password = "";
            int targetPoints = 0;
            Registration c = new Registration();
            int actualPoints = c.Password_Strength(password);
            Assert.AreEqual(targetPoints, actualPoints);
        }
        [TestMethod]
        public void Password_Strength_7lowercases_2Points()
        {
            string password = "password";
            int targetPoints = 2;
            Registration c = new Registration();
            int actualPoints = c.Password_Strength(password);
            Assert.AreEqual(targetPoints, actualPoints);
        }

        [TestMethod]
        public void Password_Strength_7lowercases1digit_1Points()
        {
            string password = "password1";
            int targetPoints = 3;
            Registration c = new Registration();
            int actualPoints = c.Password_Strength(password);
            Assert.AreEqual(targetPoints, actualPoints);
        }

        [TestMethod]
        public void Password_Strength_allcases_5Points()
        {
            string password = "passworD1!";
            int targetPoints = 5;
            Registration c = new Registration();
            int actualPoints = c.Password_Strength(password);
            Assert.AreEqual(targetPoints, actualPoints);
        }
    }
}
