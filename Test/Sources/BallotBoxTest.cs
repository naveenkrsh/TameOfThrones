using Core.Sources;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace Test.Sources
{
    [TestClass]
    public class BallotBoxTest
    {
        BallotBox box;
        public BallotBoxTest()
        {
            box = new BallotBox();
        }
        [TestMethod]
        public void Should_One_IfTwoDublicateMessageAdded()
        {
            //when
            Kingdom sender1 = new Kingdom("LAND", "Panda");
            Kingdom receiver1 = new Kingdom("Test", "Test");
            BallotMessage ballotMessage = new BallotMessage(sender1, receiver1, "Test");
            box.Add(ballotMessage);
            box.Add(ballotMessage);

            //then
            Assert.AreEqual(1, box.GetBallotMessageCount());
        }

        [TestMethod]
        public void Should_One_IfTwoMessageAddedWithSameContent()
        {
            //when
            Kingdom sender1 = new Kingdom("LAND", "Panda");
            Kingdom receiver1 = new Kingdom("Test", "Test");
            BallotMessage ballotMessage1 = new BallotMessage(sender1, receiver1, "Test");

            Kingdom sender2 = new Kingdom("LAND", "Panda");
            Kingdom receiver2 = new Kingdom("Test", "Test");
            BallotMessage ballotMessage2 = new BallotMessage(sender2, receiver2, "Test");
            box.Add(ballotMessage1);
            box.Add(ballotMessage2);

            //then
            Assert.AreEqual(1, box.GetBallotMessageCount());
        }

        [TestMethod]
        public void Should_Two_IfTwoMessageAdded()
        {
            //when
            Kingdom sender1 = new Kingdom("LAND", "Panda");
            Kingdom receiver1 = new Kingdom("Test", "Test");
            BallotMessage ballotMessage1 = new BallotMessage(sender1, receiver1, "Test");

            Kingdom sender2 = new Kingdom("Lxx", "Pxxx");
            Kingdom receiver2 = new Kingdom("Tesxx", "Txxx");
            BallotMessage ballotMessage2 = new BallotMessage(sender2, receiver2, "Tesxx");
            box.Add(ballotMessage1);
            box.Add(ballotMessage2);

            //then
            Assert.AreEqual(2, box.GetBallotMessageCount());
        }

        [TestMethod]
        public void Should_Two_IfTwoMessageAddedWithDiffrentSender()
        {
            //when
            Kingdom sender1 = new Kingdom("LAND", "Panda");
            Kingdom receiver1 = new Kingdom("Test", "Test");
            BallotMessage ballotMessage1 = new BallotMessage(sender1, receiver1, "Test");

            Kingdom sender2 = new Kingdom("Sender", "Sender");
            Kingdom receiver2 = new Kingdom("Test", "Test");
            BallotMessage ballotMessage2 = new BallotMessage(sender2, receiver2, "Test");
            box.Add(ballotMessage1);
            box.Add(ballotMessage2);

            //then
            Assert.AreEqual(2, box.GetBallotMessageCount());
        }

        [TestMethod]
        public void Should_Two_IfTwoMessageAddedWithDiffrentReciever()
        {
            //when
            Kingdom sender1 = new Kingdom("LAND", "Panda");
            Kingdom receiver1 = new Kingdom("Test1", "Test1");
            BallotMessage ballotMessage1 = new BallotMessage(sender1, receiver1, "Test1");

            Kingdom sender2 = new Kingdom("LAND", "Panda");
            Kingdom receiver2 = new Kingdom("Test2", "Test2");
            BallotMessage ballotMessage2 = new BallotMessage(sender2, receiver2, "Test2");
            box.Add(ballotMessage1);
            box.Add(ballotMessage2);

            //then
            Assert.AreEqual(2, box.GetBallotMessageCount());
        }

        [TestMethod]
        public void Should_MatchAndRemainOne_IfOneMessagePicked()
        {
            //when
            Kingdom sender1 = new Kingdom("LAND", "Panda");
            Kingdom receiver1 = new Kingdom("Test1", "Test1");
            BallotMessage ballotMessage1 = new BallotMessage(sender1, receiver1, "Test1");

            Kingdom sender2 = new Kingdom("LAND", "Panda");
            Kingdom receiver2 = new Kingdom("Test2", "Test2");
            BallotMessage ballotMessage2 = new BallotMessage(sender2, receiver2, "Test2");
            box.Add(ballotMessage1);
            box.Add(ballotMessage2);
            BallotMessage pickedMessage  =box.PickMessage(0);

            //then
            Assert.AreNotEqual(pickedMessage,ballotMessage2);
            Assert.AreEqual(pickedMessage,ballotMessage1);
            Assert.AreEqual(1, box.GetBallotMessageCount());
        }

        [TestMethod]
        public void Should_Zero_AfterClearing()
        {
            //when
            Kingdom sender1 = new Kingdom("LAND", "Panda");
            Kingdom receiver1 = new Kingdom("Test", "Test");
            BallotMessage ballotMessage1 = new BallotMessage(sender1, receiver1, "Test");

            Kingdom sender2 = new Kingdom("Lxx", "Pxxx");
            Kingdom receiver2 = new Kingdom("Tesxx", "Txxx");
            BallotMessage ballotMessage2 = new BallotMessage(sender2, receiver2, "Tesxx");
            box.Add(ballotMessage1);
            box.Add(ballotMessage2);
            box.Clear();

            //then
            Assert.AreEqual(0, box.GetBallotMessageCount());
        }

        [TestMethod]
        public void Should_Two_RandomMessage()
        {
            //when
            Kingdom sender1 = new Kingdom("LAND", "Panda");
            Kingdom receiver1 = new Kingdom("Test", "Test");
            BallotMessage ballotMessage1 = new BallotMessage(sender1, receiver1, "Test");

            Kingdom sender2 = new Kingdom("Lxx", "Pxxx");
            Kingdom receiver2 = new Kingdom("Tesxx", "Txxx");
            BallotMessage ballotMessage2 = new BallotMessage(sender2, receiver2, "Tesxx");
            box.Add(ballotMessage1);
            box.Add(ballotMessage2);
            
            //then
            Assert.AreEqual(2, box.GetRandomNBallotMessgae(2).Count);
        }
    }
}