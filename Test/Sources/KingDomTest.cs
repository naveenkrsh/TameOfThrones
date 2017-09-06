using Core.Sources;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace Test.Sources
{
    [TestClass]
    public class KingDomTest
    {
        Kingdom kingdom;
        public KingDomTest()
        {
            kingdom = new Kingdom("LAND", "Panda");
        }

        [TestMethod]
        public void TestCountChar()
        {
            Assert.AreEqual(2, kingdom['a']);
            Assert.AreEqual(1, kingdom['P']);
            Assert.AreEqual(1, kingdom['n']);
            Assert.AreEqual(0, kingdom['m']);
        }

        [TestMethod]
        public void TestTryToWin()
        {
            Assert.AreEqual(true, kingdom.TryToWin("Panda"));
            Assert.AreEqual(true, kingdom.TryToWin("ndapa"));
            Assert.AreEqual(true, kingdom.TryToWin("Die or play the tame of thrones”"));
           
        }
    }
}