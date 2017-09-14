using System.Collections.Generic;

namespace Core.Sources
{
    public class NullKingdom : IKingdomInfo
    {
       
        public string Name => "None";

        public List<string> GetAllies()
        {
            return new List<string>() { "None" };
        }
    }
}