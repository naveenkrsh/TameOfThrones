using System;

namespace Core.Sources
{
    public class Kingdom 
    {

        public Kingdom(string name, string animal)
        {
            this.Name = name;
            this.Animal = animal;
            _asciiCodeOfa = (int)'a';
            IntializeCountArr();
        }
        public string Name { get; }
        public string Animal { get; }
        int _asciiCodeOfa;
        private int[] charCountInAnimal;
        private void IntializeCountArr()
        {
            this.charCountInAnimal = new int[26];
            CountAndStore(this.Animal, this.charCountInAnimal);
        }

        private void CountAndStore(string str, int[] store)
        {
            foreach (char c in str)
            {
                int index = GetIndex(c);
                if (IsInRange(index))
                {
                    store[index]++;
                }
            }
        }

        private bool IsInRange(int index)
        {
            return (index > -1 && index <= 26);
        }

        private int GetIndex(char c)
        {
            return (int)Char.ToLower(c) - _asciiCodeOfa;
        }

        public int this[char c]
        {
            get
            {
                int index = GetIndex(c);
                if (IsInRange(index))
                    return this.charCountInAnimal[index];
                else
                    return 0;
            }
        }
        public bool TryToWin(string message)
        {
            bool result = true;
            int[] charCountInMessage = new int[26];
            
            CountAndStore(message, charCountInMessage);

            for (int index = 0; index < charCountInAnimal.Length; index++)
            {
                if (charCountInAnimal[index] > charCountInMessage[index])
                {
                    result = false;
                    break;
                }
            }
            return result;
        }

        public override string ToString()
        {
            return this.Name;
        }

        public override int GetHashCode()
        {
            return this.ToString().GetHashCode();
        }

        
    }
}