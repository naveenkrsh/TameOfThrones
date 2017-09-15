using Core.Sources;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace Test.Sources
{
    [TestClass]
    public class BallotMessageTest
    {
        BallotMessage ballotMessage;
        Kingdom sender;
        public BallotMessageTest()
        {
            sender = new Kingdom("LAND", "Panda");
            Kingdom receiver = new Kingdom("Test", "Test");
            ballotMessage = new BallotMessage(sender, receiver, "Test");
        }

        [TestMethod]
        public void Should_One_IfMessageSendToReceiverIsCorrect()
        {
            //when
            ballotMessage.SendMessageToReceivingKingdom();
            //then
            Assert.AreEqual(1, sender.GetAlliesCount());
        }
    }
}