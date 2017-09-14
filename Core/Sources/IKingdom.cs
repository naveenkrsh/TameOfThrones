using System.Collections.Generic;

namespace Core.Sources
{
    public interface IKingdom
    {
        string Name { get; }
    
        int this[char c] { get; }
        bool TryToWin(string message);
        void AddAllie(IKingdom allie);
        int GetTotalAllies();
        List<string> GetAllies();
    }
}