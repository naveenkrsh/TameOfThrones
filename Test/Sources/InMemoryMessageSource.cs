using System.Collections.Generic;
using System.Collections.ObjectModel;
using Core.Sources;

namespace Test.Sources
{
    public class InMemoryMessageSource : IMessageSource
    {
        public ReadOnlyCollection<string> GetAllMessages()
        {
            List<string> messages = new List<string>(){"Hello","World","Geek","Trust"};
            return new ReadOnlyCollection<string>(messages);
        }
    }
}