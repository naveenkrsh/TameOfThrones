using Core.Sources;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace Test.Sources
{
    [TestClass]
    public class RandomizeMessageTest
    {
        RandomizeMessage rndMessage;
        public RandomizeMessageTest()
        {
            rndMessage = new RandomizeMessage(new InMemoryMessageSource());
        }

        [TestMethod]
        public void Should_Four_TotalMessage()
        {
            Assert.AreEqual(6,rndMessage.MessageCount);
        }

        [TestMethod]
        public void Should_Hello_Message()
        {
            Assert.AreEqual("Panda",rndMessage[0]);
        }
    }
}