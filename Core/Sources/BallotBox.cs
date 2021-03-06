using Core.Sources;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System;

namespace Core.Sources
{
    public class BallotBox
    {
        private IList<BallotMessage> ballotMessages;
        Random random;
        public BallotBox()
        {
            ballotMessages = new List<BallotMessage>();
            random = new Random();
        }
        public void Add(BallotMessage message)
        {
            if (!this.ballotMessages.Contains(message))
                this.ballotMessages.Add(message);
        }

        public BallotMessage PickMessage(int index)
        {
            BallotMessage message = (BallotMessage)ballotMessages[index].Clone();
            ballotMessages.RemoveAt(index);
            return message;
        }

        public int GetBallotMessageCount()
        {
            return this.ballotMessages.Count;
        }
        private int GetRandomNumber()
        {
            int index = random.Next(ballotMessages.Count - 1);
            return index;
        }

        public ReadOnlyCollection<BallotMessage> GetRandomNBallotMessgae(int total)
        {
            List<BallotMessage> randomMessages = new List<BallotMessage>();
            int actualTotal =  GetActualTotal(total);
            for (int i = 0; i < actualTotal; i++)
            {
                randomMessages.Add(PickMessage(GetRandomNumber()));
            }
            return new ReadOnlyCollection<BallotMessage>(randomMessages);
        }

        private int GetActualTotal(int total)
        {
            return total > ballotMessages.Count ? ballotMessages.Count : total;
        }

        public ReadOnlyCollection<BallotMessage> GetBallotMessgae()
        {
            return new ReadOnlyCollection<BallotMessage>(ballotMessages);
        }

        public void SendMessageToKingdom(ReadOnlyCollection<BallotMessage> ballotMessages)
        {
            foreach (var ballotMessage in ballotMessages)
            {
                ballotMessage.SendMessageToReceivingKingdom();
            }
        }

        public void Clear()
        {
            ballotMessages = new List<BallotMessage>();
        }
    }
}