using System;
using System.Collections.Generic;
using System.Linq;
namespace Core.Sources
{
    public class Kingdom : IEquatable<Kingdom>
    {
        private const int TOTAL_NO_CHAR = 26;
        private const int A_AsciiCode = 97;
        public string Name { get; }
        public string Animal { get; }
        private int[] charCountInAnimal;
        private HashSet<Kingdom> Allies { get; set; }
        public Kingdom(string name, string animal)
        {
            this.Name = name;
            this.Animal = animal;
            this.Allies = new HashSet<Kingdom>();
            IntializeCountArr();
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

        private void IntializeCountArr()
        {
            this.charCountInAnimal = new int[TOTAL_NO_CHAR];
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
            return (index > -1 && index <= TOTAL_NO_CHAR);
        }
        private int GetIndex(char c)
        {
            return (int)Char.ToLower(c) - A_AsciiCode;
        }
        public bool TryToWin(string message)
        {
            bool result = true;
            int[] charCountInMessage = new int[TOTAL_NO_CHAR];

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
            if (this != allie)
                Allies.Add(allie);
        }

        public int GetTotalAllies()
        {
            return this.Allies.Count;
        }

        public List<string> GetAllies()
        {
            return this.Allies.Select(x => x.Name).ToList();
        }

        public override string ToString()
        {
            return this.Name;
        }

        public override int GetHashCode()
        {
            return this.ToString().GetHashCode();
        }

        public bool Equals(Kingdom other)
        {
            return this.Name == other.Name && this.Animal == other.Animal;
        }

        public override bool Equals(Object obj)
        {
            if (obj == null)
                return false;

            Kingdom kingdomObj = obj as Kingdom;
            if (kingdomObj == null)
                return false;
            else
                return Equals(kingdomObj);
        }

        public static bool operator ==(Kingdom operand1, Kingdom operand2)
        {
            if (((object)operand1) == null || ((object)operand2) == null)
                return Object.Equals(operand1, operand2);

            return operand1.Equals(operand2);
        }

        public static bool operator !=(Kingdom operand1, Kingdom operand2)
        {
            if (((object)operand1) == null || ((object)operand2) == null)
                return !Object.Equals(operand1, operand2);

            return !(operand1.Equals(operand2));
        }

    }
}