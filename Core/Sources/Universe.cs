using System.Collections.Generic;
using System.Linq;
using System.Collections.ObjectModel;
namespace Core.Sources
{
    public class Universe
    {
        public string Name { get; }
        private IList<Kingdom> kingdoms;
        private IList<Kingdom> lostKingDom;
        public Universe(string name)
        {
            this.Name = name;
            this.kingdoms = new List<Kingdom>();
            this.lostKingDom = new List<Kingdom>();
            Construct();
        }
        private void Construct()
        {
            this.kingdoms.Add(new Kingdom("LAND", "Panda"));
            this.kingdoms.Add(new Kingdom("WATER", "Octopus"));
            this.kingdoms.Add(new Kingdom("ICE", "Mammoth"));
            this.kingdoms.Add(new Kingdom("AIR", "Owl"));
            this.kingdoms.Add(new Kingdom("FIRE", "Dragon"));
        }

        private Kingdom this[string kingdomName]
        {
            get
            {
                return this.kingdoms.FirstOrDefault(x => x.Name == kingdomName.ToUpper());
            }
        }

        public bool ContainsKingdom(string kingdomName)
        {
            return this[kingdomName] == null?false:true;
        }
        public void SendMessage(string message)
        {
            string[] splitedMessage = message.Split(',');
            if (this.ContainsKingdom(splitedMessage[0]))
            {
                Kingdom kindom = this[splitedMessage[0]];
                if (kindom.TryToWin(splitedMessage[1]))
                {
                    this.lostKingDom.Add(kindom);
                }
            }
        }

        public List<string> GetAllies()
        {
            return this.lostKingDom.Select(x => x.Name).ToList();
        }
    }
}
