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

        private List<Kingdom> CompetingKingdom { get; set; }
        public List<Kingdom> AllKingDoms { get; }

        public int BallotMessageCount()
        {
            return ballotBox.GetTotalBallotMessage();
        }
        public void Add(Kingdom sender, Kingdom receiver, string message)
        {
            if (!CompetingKingdom.Contains(receiver))
                ballotBox.Add(BallotMessage.Create(sender, receiver, message));
        }

        public void SendMessageToKingdom()
        {
            ballotBox.SendMessageToKingdom(ballotBox.GetBallotMessgae());
        }
        // public Kingdom FindWinner()
        // {
        //     if (IsTie())
        //     {

        //     }
        // }

        public Kingdom FindKingdomWithMaxAllies()
        {
            Kingdom kingdom = CompetingKingdom
            .OrderByDescending(x => x.GetTotalAllies())
            .First();

            return kingdom;
        }

        public bool IsTie()
        {
            if (GetTiedQuery().Count() > 0)
                return true;
            else
                return false;
        }
        public int CompetingKingdomCount()
        {
            return this.CompetingKingdom.Count();
        }
        public void RefreshCompetingKingdom()
        {
            CompetingKingdom = GetTiedQuery().OrderByDescending(x => x.Key).First().ToList();
        }

        private IEnumerable<IGrouping<int, Kingdom>> GetTiedQuery()
        {
            IEnumerable<IGrouping<int, Kingdom>> tiedQuery = CompetingKingdom
           .GroupBy(x => x.GetTotalAllies())
           .Where(x => x.Count() > 1);
            return tiedQuery;
        }
    }
}