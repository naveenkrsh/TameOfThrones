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
        public void Should_None_IfSendingMessageToOneKingDom()
        {
            //when
            universe.SendMessage("Air, “oaaawaala” ");

            //then
            Assert.AreEqual("None",universe.GetRullerName());
            Assert.AreEqual("None",universe.GetRullerAllies());
        }

        [TestMethod]
        public void Should_None_IfSendingMessageToSameKingDomAsPerRequiredMajority()
        {
            //when
            universe.SendMessage("Air, “oaaawaala” ");
            universe.SendMessage("Air, “oaaawaala” ");
            universe.SendMessage("Air, “oaaawaala” ");
            //then
            Assert.AreEqual("None",universe.GetRullerName());
            Assert.AreEqual("None",universe.GetRullerAllies());
        }

        [TestMethod]
        public void Should_SPACE_IfSendingCorrectMessageToUniqueKingDomAsPerRequiredMajority()
        {
            //when
            universe.SendMessage("Air, “oaaawaala” ");
            universe.SendMessage("Land, “a1d22n333a4444p”");
            universe.SendMessage("Ice, “zmzmzmzaztzozh”");
            //then
             Assert.AreEqual("SPACE",universe.GetRullerName());
             Assert.AreEqual("AIR,ICE,LAND",universe.GetRullerAllies());
        }

        [TestMethod]
        public void Should_None_IfSendingWrongMessageToUniqueKingDomAsPerRequiredMajority()
        {
            //when
            universe.SendMessage("Air, uytrew ");
            universe.SendMessage("Land, “98765tr”");
            universe.SendMessage("Ice, 76543");
            //then
            Assert.AreEqual("None",universe.GetRullerName());
            Assert.AreEqual("None",universe.GetRullerAllies());
        }

        [TestMethod]
        public void ShouldNotConsiderItselfAsAllie_Null_IfSendingMessageToSelfKingdomAsPerRequiredMajority()
        {
            //when
            universe.SetNoOfRequiredAlliesToRule(1);
            universe.SendMessage("Space, Gorilla ");
            //then
            Assert.AreEqual("None",universe.GetRullerName());
            Assert.AreEqual("None",universe.GetRullerAllies());
        }

        [TestMethod]
        public void Should_SPACE_IfSendingMessageToOtherKingdomAsPerRequiredMajority()
        {
            //when
            universe.SetNoOfRequiredAlliesToRule(1);
            universe.SendMessage("Air, “oaaawaala” ");
            //then
            Assert.AreEqual("SPACE",universe.GetRullerName());
            Assert.AreEqual("Air".ToLower(),universe.GetRullerAllies().ToLower());
        }
    }
}