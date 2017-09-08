using System.Collections.Generic;
using System.Linq;
using System.Collections.ObjectModel;
namespace Core.Sources
{
    public class Universe
    {
        public string Name { get; }
        private IList<Kingdom> kingdoms;
        private Kingdom currentKingdomWantsToRule;
        private int noOfrequiredAlliesToRule;
        public Universe(string name)
        {
            this.Name = name;
            this.kingdoms = new List<Kingdom>();
            noOfrequiredAlliesToRule = 3;
            Construct();
        }
        private void Construct()
        {
            this.kingdoms.Add(new Kingdom("LAND", "Panda"));
            this.kingdoms.Add(new Kingdom("WATER", "Octopus"));
            this.kingdoms.Add(new Kingdom("ICE", "Mammoth"));
            this.kingdoms.Add(new Kingdom("AIR", "Owl"));
            this.kingdoms.Add(new Kingdom("FIRE", "Dragon"));
            this.kingdoms.Add(new Kingdom("SPACE", "Gorilla"));
        }

        public Kingdom this[string kingdomName]
        {
            get
            {
                return this.kingdoms.FirstOrDefault(x => x.Name == kingdomName.ToUpper());
            }
        }
        public bool ContainsKingdom(string kingdomName)
        {
            return this[kingdomName] == null ? false : true;
        }
        public void SendMessage(string message)
        {
            string[] splitedMessage = message.Split(',');
            if (this.ContainsKingdom(splitedMessage[0]))
            {
                Kingdom kingdom = this[splitedMessage[0]];
                if (kingdom != currentKingdomWantsToRule)
                {
                    if (kingdom.TryToWin(splitedMessage[1]))
                    {
                        this.currentKingdomWantsToRule.AddAllie(kingdom);
                    }
                }
            }
        }
        public void SetCurrentKingdomWantsToRule(Kingdom kingdom)
        {
            this.currentKingdomWantsToRule = kingdom;
        }
        public void SetNoOfRequiredAlliesToRule(int no)
        {
            this.noOfrequiredAlliesToRule = no;
        }
        public Kingdom GetRuller()
        {
            return this.currentKingdomWantsToRule.GetTotalAllies() >= noOfrequiredAlliesToRule ? this.currentKingdomWantsToRule : null;
        }
    }
}
