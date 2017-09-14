using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Core.Sources
{
    public class RandomizeMessage
    {
        private Random random;
        private ReadOnlyCollection<string> Messages { get; set; }
        private string Path { get; }
        public int MessageCount => Messages.Count;

        public string this[int index] => Messages[index];
        public RandomizeMessage(IMessageSource messageSource)
        {
            Messages = messageSource.GetAllMessages();
            random = new Random();
        }
        public string GetNextMessage()
        {
            return this[GetRandomNumber()];
        }
        private int GetRandomNumber()
        {
            int index = random.Next(this.MessageCount - 1);
            return index;
        }
    }
}