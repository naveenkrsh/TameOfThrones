using System.Collections.Generic;

namespace Core.Sources
{
    public class NullKingdom : IKingdom
    {
        public int this[char c] => 0;

        public string Name => "None";

        void IKingdom.AddAllie(IKingdom allie)
        {
            
        }
        public List<string> GetAllies()
        {
            return new List<string>(){"None"};
        }

        public int GetTotalAllies()
        {
            return 0;
        }

        public bool TryToWin(string message)
        {
            return false;
        }
    }
}