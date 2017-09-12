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
            universe.SetNoOfRequiredAlliesToRule(3);
            universe.SetCurrentKingdomWantsToRule(universe["SPACE"]);
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


        [TestMethod]
        public void Should_Null_IfSendingMessageToOneKingDom()
        {
            //when
            universe.SendMessage("Air, “oaaawaala” ");

            //then
            Assert.IsNull(universe.GetRuller());
        }

        [TestMethod]
        public void Should_Null_IfSendingMessageToSameKingDomAsPerRequiredMajority()
        {
            //when
            universe.SendMessage("Air, “oaaawaala” ");
            universe.SendMessage("Air, “oaaawaala” ");
            universe.SendMessage("Air, “oaaawaala” ");
            //then
            Assert.IsNull(universe.GetRuller());
        }

        [TestMethod]
        public void Should_Kingdom_IfSendingCorrectMessageToUniqueKingDomAsPerRequiredMajority()
        {
            //when
            universe.SendMessage("Air, “oaaawaala” ");
            universe.SendMessage("Land, “a1d22n333a4444p”");
            universe.SendMessage("Ice, “zmzmzmzaztzozh”");
            //then
            Assert.IsNotNull(universe.GetRuller());
        }

        [TestMethod]
        public void Should_Null_IfSendingWrongMessageToUniqueKingDomAsPerRequiredMajority()
        {
            //when
            universe.SendMessage("Air, uytrew ");
            universe.SendMessage("Land, “98765tr”");
            universe.SendMessage("Ice, 76543");
            //then
            Assert.IsNull(universe.GetRuller());
        }

        [TestMethod]
        public void ShouldNotConsiderItselfAsAllie_Null_IfSendingMessageToSelfKingdomAsPerRequiredMajority()
        {
            //when
            universe.SetNoOfRequiredAlliesToRule(1);
            universe.SendMessage("Space, Gorilla ");
            //then
            Assert.IsNull(universe.GetRuller());
        }

        [TestMethod]
        public void Should_Kingdom_IfSendingMessageToOtherKingdomAsPerRequiredMajority()
        {
            //when
            universe.SetNoOfRequiredAlliesToRule(1);
            universe.SendMessage("Air, “oaaawaala” ");
            //then
            Assert.IsNotNull(universe.GetRuller());
        }
    }
}