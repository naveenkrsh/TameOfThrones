using System.Collections.Generic;

namespace Core.Sources
{
    public interface IKingdom
    {
        string Name { get; }

        int this[char c] { get; }
        void AddAllie(IKingdom allie);
        List<string> GetAllies();
        bool TryToWin(string message);

        void ClearAllies();
    }
}