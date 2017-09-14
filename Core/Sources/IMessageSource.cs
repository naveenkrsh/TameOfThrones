using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Core.Sources
{
    public interface IMessageSource
    {
        ReadOnlyCollection<string> GetAllMessages();
    }
}