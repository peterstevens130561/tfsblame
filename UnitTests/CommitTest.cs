using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BHI.JewelSuite.Tools.TfsBlame.unittests
{
    [TestClass]
    public class CommitTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            var commit = new Commit(12345,"peter",new DateTime(2014,11,1));
            var result = commit.ToString();
            Assert.AreEqual("12345 peter 11/1/2014",result);
        }
    }
}
