using Core.Sources;
using System;
using System.Collections.Generic;
namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            PrintOutPut(GetSampleInputs1());
            Console.WriteLine("+++++++++++++++++++++");
            PrintOutPut(GetSampleInputs2());
        }

        public static void PrintOutPut(List<string> inputs)
        {
            Universe universe = new Universe("Southeros");
            PrintRullerAndAllies(universe);
            Console.WriteLine();
            Console.WriteLine("Input Messages to kingdoms from King Shan:");

            foreach (string input in inputs)
            {
                Console.WriteLine("Input : " + input);
                universe.SendMessage(input);
            }
            Console.WriteLine();
            PrintRullerAndAllies(universe);
        }
        public static List<string> GetSampleInputs1()
        {
            List<string> inputs = new List<string>();
            inputs.Add("Air, “oaaawaala”");
            inputs.Add("Land, “a1d22n333a4444p”");
            inputs.Add("Ice, “zmzmzmzaztzozh” ");
            return inputs;
        }

        public static List<string> GetSampleInputs2()
        {
            List<string> inputs = new List<string>();
            inputs.Add("Air, “Let’s swing the sword together”");
            inputs.Add("Land,“Die or play the tame of thrones”");
            inputs.Add("Ice, “Ahoy! Fight for me with men and money”");
            inputs.Add("Water, “Summer is coming”");
            inputs.Add("Fire, “Drag on Martin!” ");
            return inputs;
        }


        public static void PrintRullerAndAllies(Universe universe)
        {
            Console.WriteLine("Who is the ruler of Southeros?");
            Console.WriteLine("Output: {0}", GetRullerName(universe));
            Console.WriteLine("Allies of King Shan?");
            Console.WriteLine("Output: {0} ", GetAllies(universe));
        }

        private static string GetAllies(Universe universe)
        {
            return universe.GetAllies().Count >= 3 ? string.Join(",", universe.GetAllies()) : "None";
        }

        private static string GetRullerName(Universe universe)
        {
            return universe.GetAllies().Count >= 3 ? "King Shan " : "None";
        }
    }
}
