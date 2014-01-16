using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using tfsblame;

namespace BHI.JewelSuite.tools.tfsblame.unittests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void InvocationAsExpectedShouldGetFile()
        {
            ArgumentParser parser = new ArgumentParser();
            var expected = "john.cs";
            String[] arguments = {"/noprompt", expected};
            var actual = parser.getFile();
            parser.Parse(arguments);
            Assert.AreEqual(expected,actual);
        }

        [TestMethod]
        public void InvocationWithJustFilenameShouldGetFile()
        {
            ArgumentParser parser = new ArgumentParser();
            var expected = "john.cs";
            String[] arguments = { expected };
            var actual = parser.getFile();
            Assert.AreEqual(expected, actual);
        }
    }
}
