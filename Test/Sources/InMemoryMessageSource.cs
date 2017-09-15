using System.Collections.Generic;
using System.Collections.ObjectModel;
using Core.Sources;

namespace Test.Sources
{
    public class InMemoryMessageSource : IMessageSource
    {
        public ReadOnlyCollection<string> GetAllMessages()
        {
            List<string> messages = new List<string>(){"Panda","Octopus","Mammoth","Owl","Dragon","Gorilla"};
            return new ReadOnlyCollection<string>(messages);
        }
    }
}