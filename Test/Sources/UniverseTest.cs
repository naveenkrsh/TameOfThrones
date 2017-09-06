using Core.Sources;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
namespace Test.Sources
{
    [TestClass]
    public class UniverseTest
    {
        Universe universe;

        public UniverseTest()
        {
            universe = new Universe("Southeros");
        }

        [TestMethod]
        public void TestContainsKingDom()
        {
            Assert.AreEqual(true,universe.ContainsKingdom("Air"));
        }

        [TestMethod]
        public void TestDoesNotContainsKingDom()
        {
            Assert.AreEqual(false,universe.ContainsKingdom("Aireee"));
        }


        [TestMethod]
        public void TestSendMessageWithCorrectMessage()
        {
            //when
            universe.SendMessage("Air, “oaaawaala” ");
            //then
            Assert.AreEqual(1,universe.GetAllies().Count);
            Assert.AreEqual("AIR",universe.GetAllies()[0]);
        }

        [TestMethod]
        public void TestSendMessageWithWrongMessage()
        {
            //when
            universe.SendMessage("Air, “qwertyui” ");
            //then
            Assert.AreEqual(0,universe.GetAllies().Count);
        }
   }
}