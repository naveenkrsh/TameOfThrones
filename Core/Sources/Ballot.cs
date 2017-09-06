using Core.Sources;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System;

namespace Core.Sources
{
    public class Ballot
    {
        private IList<BallotMessage> ballotMessages;
        Random random;
        public Ballot()
        {
            ballotMessages = new List<BallotMessage>();
            random = new Random();
        }
        public void Add(BallotMessage message)
        {
            this.ballotMessages.Add(message);
        }

        public BallotMessage PickMessage(int index)
        {
            BallotMessage message = (BallotMessage)ballotMessages[index].Clone();
            ballotMessages.RemoveAt(index);
            return message;
        }
        private int GetRandomNumber()
        {
            int index = random.Next(ballotMessages.Count - 1);
            return index;
        }

        public ReadOnlyCollection<BallotMessage> GetRandomNMessgae(int total)
        {
            List<BallotMessage> randomMessages = new List<BallotMessage>();

            foreach (BallotMessage message in ballotMessages)
            {
                randomMessages.Add(PickMessage(GetRandomNumber()));
            }
            return new ReadOnlyCollection<BallotMessage>(randomMessages);
        }

        public void SendMessageToKingdom(ReadOnlyCollection<BallotMessage> ballotMessages)
        {
            foreach (var ballotMessage in ballotMessages)
            {
                if (ballotMessage.Receiver.TryToWin(ballotMessage.Message))
                {
                    ballotMessage.Sender.AddAllie(ballotMessage.Receiver);
                }
            }
        }
    }
}