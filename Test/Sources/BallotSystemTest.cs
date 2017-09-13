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
            ballotSystem.Add(competing[0], kingdoms[1], "Octopus"); ;
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
            ballotSystem.Add(competing[0], kingdoms[3], "Owl"); ;
            ballotSystem.Add(competing[1], kingdoms[4], "Dragon");
            ballotSystem.SendMessageToKingdom();

            Assert.AreEqual(2, ballotSystem.BallotMessageCount());
            Assert.AreEqual(1, competing[0].GetTotalAllies());
            Assert.AreEqual(1, competing[1].GetTotalAllies());
            Assert.AreEqual(true, ballotSystem.IsTie());

        }

        [TestMethod]
        public void Should_False_Tie()
        {
            ballotSystem.Add(competing[0], kingdoms[3], "Owl");
            ballotSystem.Add(competing[1], kingdoms[4], "Dragon");
            ballotSystem.Add(competing[1], kingdoms[5], "Gorilla");
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
            if (ballotSystem.IsTie())
                ballotSystem.RefreshCompetingKingdom();
            //then        
            Assert.AreEqual(2, ballotSystem.CompetingKingdomCount());
        }

        private void SetUpForTie()
        {
            ballotSystem.Add(competing[0], kingdoms[3], "Owl");
            ballotSystem.Add(competing[1], kingdoms[3], "Owl");
            ballotSystem.Add(competing[0], kingdoms[4], "Dragon");
            ballotSystem.Add(competing[1], kingdoms[4], "Dragon");
            ballotSystem.Add(competing[2], kingdoms[5], "Gorilla");
            ballotSystem.SendMessageToKingdom();
        }
    }
}