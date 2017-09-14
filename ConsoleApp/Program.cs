using Core.Sources;
using System;
using System.Collections.Generic;
namespace ConsoleApp
{
    class Program
    {
        public static List<Kingdom> kingdoms { get; private set; }
        public static List<Kingdom> competing { get; private set; }


        static void Main(string[] args)
        {
            Universe universe = new Universe("Southeros");
            PrintRullerAndAllies(universe);

            Console.WriteLine("Enter the kingdoms competing to be the ruler:");
            string input = Console.ReadLine().Trim();
            string[] kingdomsNames = input.Split(' ');

            List<Kingdom> competingKingDoms = new List<Kingdom>();

            foreach (string name in kingdomsNames)
            {
                string nameUpperCase = name.ToUpper();
                if (universe.ContainsKingdom(nameUpperCase))
                    competingKingDoms.Add(universe[nameUpperCase]);
            }

            RandomizeMessage rndMessage = new RandomizeMessage(new FileMessageSource("./boc-messages.txt"));
            BallotSystem ballotSystem = new BallotSystem(competingKingDoms, universe.Kingdoms, rndMessage, 6);

            universe.SetRandomRuller(ballotSystem);
            PrintRullerAndAllies(universe);

        }



        public static void PrintOutPut(List<string> inputs)
        {
            Universe universe = new Universe("Southeros");
            universe.SetCurrentKingdomWantsToRule(universe["SPACE"]);

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
            Console.WriteLine("Output: {0}", universe.GetRullerName());
            Console.WriteLine("Allies of King Shan?");
            Console.WriteLine("Output: {0} ", universe.GetRullerAllies());
        }
    }
}
