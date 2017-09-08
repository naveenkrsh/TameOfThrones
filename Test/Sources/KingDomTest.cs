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
        public void Should_Count_Char()
        {
            Assert.AreEqual(2, kingdom['a']);
            Assert.AreEqual(1, kingdom['P']);
            Assert.AreEqual(1, kingdom['n']);
            Assert.AreEqual(0, kingdom['m']);
        }

        [TestMethod]
        public void Should_True_IfMessageContainsAnimalName()
        {
            Assert.AreEqual(true, kingdom.TryToWin("Panda"));
            Assert.AreEqual(true, kingdom.TryToWin("ndapa"));
            Assert.AreEqual(true, kingdom.TryToWin("Die or play the tame of thrones”"));
        }

        [TestMethod]
        public void Should_False_IfMessageNotContainsAnimalName()
        {
            Assert.AreEqual(false, kingdom.TryToWin("xxxnda"));
            Assert.AreEqual(false, kingdom.TryToWin("ppassaas"));
            Assert.AreEqual(false, kingdom.TryToWin("ad asdas dasd"));
        }

        [TestMethod]
        public void Should_One_IfAddingOneAllies()
        {
            //when
            kingdom.AddAllie(new Kingdom("Test","Test"));
            //then
            Assert.AreEqual(1, kingdom.GetTotalAllies());
        }

        [TestMethod]
        public void Should_Two_IfAddingTwoAllies()
        {
            //when
            kingdom.AddAllie(new Kingdom("Test","Test"));
            kingdom.AddAllie(new Kingdom("Test1","Test1"));
            //then
            Assert.AreEqual(2, kingdom.GetTotalAllies());
        }

        [TestMethod]
        public void Should_One_IfAddingTwoSameAllies()
        {   
            //when
            var temp = new Kingdom("Test","Test");
            kingdom.AddAllie(temp);
            kingdom.AddAllie(temp);
            //then
            Assert.AreEqual(1, kingdom.GetTotalAllies());
        }

        [TestMethod]
        public void Should_Zero_IfAddingItsSelfAsAllies()
        {
            //when
            kingdom.AddAllie(kingdom);
            //then
            Assert.AreEqual(0, kingdom.GetTotalAllies());
        }

        [TestMethod]
        public void Should_One_IfAddingTwoAlliesWithSameValues()
        {
            //when
            kingdom.AddAllie(new Kingdom("Test","Test"));
            kingdom.AddAllie(new Kingdom("Test","Test"));
            //then
            Assert.AreEqual(1, kingdom.GetTotalAllies());
        }
    }
}