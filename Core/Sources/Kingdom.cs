using System;
using System.Collections.Generic;
using System.Linq;
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

        private HashSet<Kingdom> Allies{get;set;}
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

        public void AddAllie(Kingdom allie)
        {
            Allies.Add(allie);
        }

        public List<string> GetAllies()
        {
            return Allies.Select(x=>x.Name).ToList();
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