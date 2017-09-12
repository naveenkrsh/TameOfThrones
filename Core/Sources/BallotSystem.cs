using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Core.Sources
{
    public class BallotSystem
    {
        BallotBox ballotBox;
        public BallotSystem(List<Kingdom> competingKingdom, List<Kingdom> allKingDoms)
        {
            CompetingKingdom = competingKingdom;
            AllKingDoms = allKingDoms;
            ballotBox = new BallotBox();
        }

        public List<Kingdom> CompetingKingdom { get; }
        public List<Kingdom> AllKingDoms { get; }


        public void SendMessageToKingdom(ReadOnlyCollection<BallotMessage> ballotMessages)
        {
            foreach (var ballotMessage in ballotMessages)
            {
                ballotMessage.SendMessageToReceivingKingdom();
            }
        }
        
    }
}