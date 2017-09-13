using System.Collections.Generic;

namespace Core.Sources
{
    public interface IMessageSource
    {
         List<string> GetAllMessages();
    }
}