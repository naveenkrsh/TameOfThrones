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

            ballotSystem = new BallotSystem(competing, kingdoms);

        }

        [TestMethod]
        public void Test()
        {
            ballotSystem.Add(competing[0], kingdoms[2], "Mammoth").SendMessageToReceivingKingdom();
            ballotSystem.Add(competing[1], kingdoms[3], "Owl").SendMessageToReceivingKingdom();

            Assert.AreEqual(1, competing[0].GetTotalAllies());
            Assert.AreEqual(1, competing[1].GetTotalAllies());
            Assert.AreEqual(true, ballotSystem.IsTie());
        }

        [TestMethod]
        public void Test1()
        {
            ballotSystem.Add(competing[0], kingdoms[2], "Mammoth").SendMessageToReceivingKingdom();
            ballotSystem.Add(competing[1], kingdoms[3], "Owl").SendMessageToReceivingKingdom();
            ballotSystem.Add(competing[1], kingdoms[4], "Dragon").SendMessageToReceivingKingdom();

            Assert.AreEqual(1, competing[0].GetTotalAllies());
            Assert.AreEqual(2, competing[1].GetTotalAllies());
            Assert.AreEqual(false, ballotSystem.IsTie());
            Assert.AreEqual(competing[1], ballotSystem.FindKingdomWithMaxAllies());
        }
    }
}