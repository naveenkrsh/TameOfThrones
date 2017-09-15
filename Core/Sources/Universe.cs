using System.Collections.Generic;
using System.Linq;
using System.Collections.ObjectModel;
namespace Core.Sources
{
    public class Universe
    {
        public string Name { get; }
        private List<Kingdom> kingdoms;
        private IKingdom ruller;
        public Universe(string name)
        {
            this.Name = name;
            this.kingdoms = new List<Kingdom>();
            ruller = NullKingdom.Instance;
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
        public List<Kingdom> Kingdoms
        {
            get { return kingdoms; }
        }
        public bool ContainsKingdom(string kingdomName)
        {
            if (this[kingdomName] != null)
                return true;
            else
                return false;
        }

        public string GetRullerName()
        {
            return ruller.Name;
        }
        public string GetRullerAllies()
        {
            return string.Join(",", ruller.GetAllies());
        }

        public void SetRandomRuller(IRullerStrategy ballotSystem)
        {
            ruller = ballotSystem.FindWinner();
        }
    }
}
