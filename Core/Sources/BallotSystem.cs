using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
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

        public BallotMessage Add(Kingdom sender, Kingdom receiver, string message)
        {
            BallotMessage ballotMessage = BallotMessage.Create(sender, receiver, message);
            ballotBox.Add(ballotMessage);
            return ballotMessage;
        }
        public void SendMessageToKingdom(ReadOnlyCollection<BallotMessage> ballotMessages)
        {
            foreach (var ballotMessage in ballotMessages)
            {
                ballotMessage.SendMessageToReceivingKingdom();
            }
        }

        // public Kingdom FindWinner()
        // {
        //     if (IsTie())
        //     {

        //     }
        // }

        public Kingdom FindKingdomWithMaxAllies()
        {
            Kingdom kingdom = (from x in CompetingKingdom
                               group x by x.GetTotalAllies() into g
                               orderby g.Key descending
                               select g.Max()).First();
            return kingdom;
        }

        public bool IsTie()
        {
            var query = (from x in CompetingKingdom
                         group x by x.GetTotalAllies() into g
                         where g.Count() > 1
                         orderby g.Key descending
                         select new
                         {
                             g.Key
                         }).ToList();
            
            
            if (query.Count > 0)
                return true;
            else
                return false;
        }

    }
}