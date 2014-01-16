using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using tfsblame;
namespace BHI.JewelSuite.tools.tfsblame.unittests
{
    /// <summary>
    /// Summary description for BlameTest
    /// </summary>
    [TestClass]
    public class BlameTest
    {
        public BlameTest()
        {
            //
            // TODO: Add constructor logic here
            //
        }


        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void DecorateLineTest()
        {
            var commitsMock = new Mock<Commits>();
            var commits = commitsMock.Object;
            String expectedCommit="12345 Peter Stevens 2014-01-01";
            commitsMock.Setup(instance => instance.GetFormattedCommit(12345)).Returns(expectedCommit);
            Blame blame = new Blame(commits);
            String expectedLine = expectedCommit + " MyOriginalTest";
            String decoratedLine=blame.DecorateLine("12345 MyOriginalTest");
            Assert.AreEqual(expectedLine,decoratedLine);
        }
    }
}
