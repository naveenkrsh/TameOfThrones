using System.Collections.Generic;
using Core.Sources;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace Test.Sources
{
    [TestClass]
    public class BallotSystemTest
    {
        BallotSystem ballotSystem;
        List<Kingdom> kingdoms;
        List<Kingdom> competing;
        public BallotSystemTest()
        {
            kingdoms = new List<Kingdom>();
            kingdoms.Add(new Kingdom("LAND", "Panda"));
            kingdoms.Add(new Kingdom("WATER", "Octopus"));
            kingdoms.Add(new Kingdom("ICE", "Mammoth"));
            kingdoms.Add(new Kingdom("AIR", "Owl"));
            kingdoms.Add(new Kingdom("FIRE", "Dragon"));
            kingdoms.Add(new Kingdom("SPACE", "Gorilla"));

            competing = new List<Kingdom>();
            competing.Add(kingdoms[0]);
            competing.Add(kingdoms[1]);
            competing.Add(kingdoms[2]);

            ballotSystem = new BallotSystem(competing, kingdoms);

        }

        [TestMethod]
        public void Should_Zero_TotalBallotMessage()
        {
            Assert.AreEqual(0, ballotSystem.BallotMessageCount());
        }

        [TestMethod]
        public void Should_Zero_TotalBallotMessageIfReviverIsCompeting()
        {
            ballotSystem.AddMessageToBallot(competing[0], kingdoms[1], "Octopus"); ;
            Assert.AreEqual(0, ballotSystem.BallotMessageCount());
        }

        [TestMethod]
        public void Should_Three_CompetingKingDom()
        {
            Assert.AreEqual(3, ballotSystem.CompetingKingdomCount());
        }

        [TestMethod]
        public void Should_True_Tie()
        {
            ballotSystem.AddMessageToBallot(competing[0], kingdoms[3], "Owl"); ;
            ballotSystem.AddMessageToBallot(competing[1], kingdoms[4], "Dragon");
            ballotSystem.SendMessageToKingdom();

            Assert.AreEqual(2, ballotSystem.BallotMessageCount());
            Assert.AreEqual(1, competing[0].GetTotalAllies());
            Assert.AreEqual(1, competing[1].GetTotalAllies());
            Assert.AreEqual(true, ballotSystem.IsTie());

        }

        [TestMethod]
        public void Should_False_Tie()
        {
            ballotSystem.AddMessageToBallot(competing[0], kingdoms[3], "Owl");
            ballotSystem.AddMessageToBallot(competing[1], kingdoms[4], "Dragon");
            ballotSystem.AddMessageToBallot(competing[1], kingdoms[5], "Gorilla");
            ballotSystem.SendMessageToKingdom();

            Assert.AreEqual(3, ballotSystem.BallotMessageCount());
            Assert.AreEqual(1, competing[0].GetTotalAllies());
            Assert.AreEqual(2, competing[1].GetTotalAllies());
            Assert.AreEqual(false, ballotSystem.IsTie());
            Assert.AreEqual(competing[1], ballotSystem.FindKingdomWithMaxAllies());
            Assert.AreEqual(competing[1].GetTotalAllies(), ballotSystem.FindKingdomWithMaxAllies().GetTotalAllies());
        }

        [TestMethod]
        public void Should_True_TieWithThreeCompeting()
        {
            //when
            SetUpForTie();
            //then        
            Assert.AreEqual(5, ballotSystem.BallotMessageCount());
            Assert.AreEqual(2, competing[0].GetTotalAllies());
            Assert.AreEqual(2, competing[1].GetTotalAllies());
            Assert.AreEqual(1, competing[2].GetTotalAllies());
            Assert.AreEqual(true, ballotSystem.IsTie());
        }



        [TestMethod]
        public void Should_Two_CompetingKingDomAfterTieAndRefresh()
        {
            //when
            SetUpForTie();
            ballotSystem.ReElectionSetup();
            //then        
            Assert.AreEqual(2, ballotSystem.CompetingKingdomCount());
        }

        [TestMethod]
        public void Should_Winner_AfterRepeating()
        {
            //when
            SetUpForTie();
            ballotSystem.ReElectionSetup();
            ballotSystem.AddMessageToBallot(competing[0], kingdoms[3], "Owl");
            ballotSystem.AddMessageToBallot(competing[1], kingdoms[4], "Dragon");
            ballotSystem.AddMessageToBallot(competing[1], kingdoms[5], "Gorilla");
            ballotSystem.SendMessageToKingdom();

            //then
            Assert.AreEqual(3, ballotSystem.BallotMessageCount());
            Assert.AreEqual(1, competing[0].GetTotalAllies());
            Assert.AreEqual(2, competing[1].GetTotalAllies());
            Assert.AreEqual(false, ballotSystem.IsTie());
            Assert.AreEqual(competing[1], ballotSystem.FindKingdomWithMaxAllies());
            Assert.AreEqual(competing[1].GetTotalAllies(), ballotSystem.FindKingdomWithMaxAllies().GetTotalAllies());

        }

        [TestMethod]
        public void Should_RoundResults_AfterElectionRoundOne()
        {
            ballotSystem.AddMessageToBallot(competing[0], kingdoms[3], "Owl");
            ballotSystem.AddMessageToBallot(competing[1], kingdoms[4], "Dragon");
            ballotSystem.AddMessageToBallot(competing[1], kingdoms[5], "Gorilla");
            ballotSystem.SendMessageToKingdom();
            ballotSystem.RecordRoundsResult();
            //then
            Assert.AreEqual(1, ballotSystem.Round);
            Assert.AreEqual(1, ballotSystem.RoundResults.Count);
            Assert.IsTrue(ballotSystem.RoundResults.ContainsKey("Results after round one ballot count"));
            List<string> roundOneResult = ballotSystem.RoundResults["Results after round one ballot count"];

            Assert.IsTrue(roundOneResult.Contains("Allies for LAND : 1"));
            Assert.IsTrue(roundOneResult.Contains("Allies for WATER : 2"));
            Assert.IsTrue(roundOneResult.Contains("Allies for ICE : 0"));
        }

        [TestMethod]
        public void Should_RoundResults_AfterElectionRoundTwo()
        {
            SetUpForTie();
            ballotSystem.RecordRoundsResult();
            ballotSystem.ReElectionSetup();
            ballotSystem.AddMessageToBallot(competing[0], kingdoms[3], "Owl");
            ballotSystem.AddMessageToBallot(competing[1], kingdoms[4], "Dragon");
            ballotSystem.AddMessageToBallot(competing[1], kingdoms[5], "Gorilla");
            ballotSystem.SendMessageToKingdom();
            ballotSystem.RecordRoundsResult();
            //then
            Assert.AreEqual(2, ballotSystem.Round);
            Assert.AreEqual(2, ballotSystem.RoundResults.Count);
            Assert.IsTrue(ballotSystem.RoundResults.ContainsKey("Results after round one ballot count"));
            List<string> roundOneResult = ballotSystem.RoundResults["Results after round one ballot count"];

            Assert.IsTrue(roundOneResult.Contains("Allies for LAND : 2"));
            Assert.IsTrue(roundOneResult.Contains("Allies for WATER : 2"));
            Assert.IsTrue(roundOneResult.Contains("Allies for ICE : 1"));

            Assert.IsTrue(ballotSystem.RoundResults.ContainsKey("Results after round two ballot count"));
            List<string> roundTwoResult = ballotSystem.RoundResults["Results after round two ballot count"];

            Assert.IsTrue(roundTwoResult.Contains("Allies for LAND : 1"));
            Assert.IsTrue(roundTwoResult.Contains("Allies for WATER : 2"));

        }
        private void SetUpForTie()
        {
            ballotSystem.AddMessageToBallot(competing[0], kingdoms[3], "Owl");
            ballotSystem.AddMessageToBallot(competing[1], kingdoms[3], "Owl");
            ballotSystem.AddMessageToBallot(competing[0], kingdoms[4], "Dragon");
            ballotSystem.AddMessageToBallot(competing[1], kingdoms[4], "Dragon");
            ballotSystem.AddMessageToBallot(competing[2], kingdoms[5], "Gorilla");
            ballotSystem.SendMessageToKingdom();
        }
    }
}