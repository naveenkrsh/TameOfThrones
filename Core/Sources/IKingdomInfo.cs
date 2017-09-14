using System.Collections.Generic;

namespace Core.Sources
{
    public interface IKingdomInfo
    {
        string Name { get; }
        List<string> GetAllies();
    }
}