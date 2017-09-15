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
        public void Should_True_IfKingdomExitsInUniverse()
        {
            Assert.AreEqual(true, universe.ContainsKingdom("Air"));
        }

        [TestMethod]
        public void Should_False_IfKingdomDoesNotExitsInUniverse()
        {
            Assert.AreEqual(false, universe.ContainsKingdom("Aireee"));
        }
    }
}