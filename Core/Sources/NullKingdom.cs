using System.Collections.Generic;

namespace Core.Sources
{
    public class NullKingdom : IKingdom
    {
        private static NullKingdom nullKingdom;
        static NullKingdom()
        {
            nullKingdom = new NullKingdom();
        }
        private NullKingdom()
        {

        }



        public int this[char c] => 0;
        public string Name => "None";
        public void AddAllie(IKingdom allie)
        {

        }
        public void ClearAllies()
        {

        }
        public List<string> GetAllies()
        {
            return new List<string>() { "None" };
        }
        public bool TryToWin(string message)
        {
            return false;
        }

        public static NullKingdom Instance
        {
            get { return nullKingdom; }
        }
    }
}