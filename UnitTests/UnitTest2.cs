using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.TeamFoundation.VersionControl.Client;

namespace BHI.JewelSuite.tools.tfsblame.unittests
{
    [TestClass]
    public class SomeTest
    {
        [TestMethod]
        public void TestBlame()
        {
            Blame blame = new Blame() ;
            String result=blame.RunAnnotate("joker");
            Assert.IsNotNull(result);
        }
    }
}
