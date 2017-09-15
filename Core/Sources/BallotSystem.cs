using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
namespace Core.Sources
{
    public class BallotSystem : IRullerStrategy
    {
        private BallotBox BallotBox { get; set; }
        private List<Kingdom> CompetingKingdom { get; set; }
        public List<Kingdom> AllKingDoms { get; }
        private RandomizeMessage RandomizeMessage { get; }

        public Dictionary<string, List<string>> RoundResults { get; private set; }

        public int Round { get; private set; }
        private int PickNRandomMessage { get; }
        public BallotSystem(List<Kingdom> competingKingdom, List<Kingdom> allKingDoms)
        : this(competingKingdom, allKingDoms, null, 0)
        {

        }
        public BallotSystem(List<Kingdom> competingKingdom, List<Kingdom> allKingDoms, RandomizeMessage randomizeMessage, int pickNRandomMessage)
        {
            CompetingKingdom = competingKingdom.Distinct().ToList();
            AllKingDoms = allKingDoms.Except(CompetingKingdom).ToList();
            BallotBox = new BallotBox();
            RoundResults = new Dictionary<string, List<string>>();
            RandomizeMessage = randomizeMessage;
            PickNRandomMessage = pickNRandomMessage;
            Round = 1;
        }


        public int BallotMessageCount()
        {
            return BallotBox.GetBallotMessageCount();
        }
        public void AddMessageToBallot(Kingdom sender, Kingdom receiver, string message)
        {
            if (!CompetingKingdom.Contains(receiver))
                BallotBox.Add(BallotMessage.Create(sender, receiver, message));
        }

        public void SendMessageToKingdom()
        {
            BallotBox.SendMessageToKingdom(BallotBox.GetBallotMessgae());
        }

        public Kingdom GetKingdomWithMaxAllies()
        {
            Kingdom kingdom = CompetingKingdom
            .OrderByDescending(x => x.GetAlliesCount())
            .First();

            return kingdom;
        }

        public bool IsAnyAllies(Kingdom kindom)
        {
            return kindom.GetAlliesCount() > 0;
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
        public void ReElectionSetup()
        {
            Round++;
            if (IsTie())
                CompetingKingdom = GetTiedQuery().OrderByDescending(x => x.Key).First().ToList();
            CompetingKingdom.ForEach(Kingdom => Kingdom.ClearAllies());
            BallotBox.Clear();
        }

        private IEnumerable<IGrouping<int, Kingdom>> GetTiedQuery()
        {
            IEnumerable<IGrouping<int, Kingdom>> tiedQuery = CompetingKingdom
            .Where(x => x.GetAlliesCount() > 0)
            .GroupBy(x => x.GetAlliesCount())
            .Where(x => x.Count() > 1);

            return tiedQuery;
        }

        public void RecordRoundsResult()
        {
            string round = string.Format("Results after round {0} ballot count", Round.ToWords());
            List<string> results = new List<string>();

            CompetingKingdom.ForEach(Kingdom =>
            {
                results.Add(string.Format("Allies for {0} : {1}", Kingdom.Name, Kingdom.GetAlliesCount()));
            });
            RoundResults.Add(round, results);
        }

        public IKingdom FindWinner()
        {
            if (CompetingKingdom.Count == 0 || AllKingDoms.Count==0)
                return NullKingdom.Instance;
   
            StartElection();
            while (IsReElectionRequired())
            {
                ReElectionSetup();
                StartElection();
            }
            return GetKingdomWithMaxAllies();
        }

        public bool IsReElectionRequired()
        {
            return IsTie() || !IsAnyAllies(GetKingdomWithMaxAllies());
        }
        private void StartElection()
        {
            AddMessageToBallotRandomly();
            ReadOnlyCollection<BallotMessage> rndMessages = BallotBox.GetRandomNBallotMessgae(PickNRandomMessage);
            BallotBox.SendMessageToKingdom(rndMessages);
            RecordRoundsResult();
        }

        private void AddMessageToBallotRandomly()
        {
            foreach (Kingdom sender in CompetingKingdom)
            {
                foreach (Kingdom receiver in AllKingDoms)

                    AddMessageToBallot(sender, receiver, RandomizeMessage.GetNextMessage());
            }
        }
    }
}