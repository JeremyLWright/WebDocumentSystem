﻿using BusinessObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace WebDocTests
{
    
    
    /// <summary>
    ///This is a test class for PasswordAdvisorTest and is intended
    ///to contain all PasswordAdvisorTest Unit Tests
    ///</summary>
    [TestClass()]
    public class PasswordAdvisorTest
    {


        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        /// <summary>
        ///A test for CheckStrength
        ///</summary>
        [TestMethod()]
        public void CheckStrengthTest()
        {
            string password = string.Empty; // TODO: Initialize to an appropriate value
            PasswordScore expected = PasswordScore.Blank;
            var actual = PasswordAdvisor.CheckStrength(password);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void CheckStrengthTestVeryStrong()
        {
            string password = "Q9MTZx14we!";
            PasswordScore expected = PasswordScore.VeryStrong;
            var actual = PasswordAdvisor.CheckStrength(password);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void CheckStrengthTestStrong()
        {
            string password = "paNther89";
            PasswordScore expected = PasswordScore.Strong;
            var actual = PasswordAdvisor.CheckStrength(password);
            Assert.AreEqual(expected, actual);
        }
    }
}
