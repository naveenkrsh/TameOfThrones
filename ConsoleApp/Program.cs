using Core.Sources;
using System;
using System.Collections.Generic;
namespace ConsoleApp
{
    class Program
    {
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
            PrintRoundsResult(ballotSystem.RoundResults);
            PrintRullerAndAllies(universe);

        }
        public static void PrintRullerAndAllies(Universe universe)
        {
            Console.WriteLine();
            Console.WriteLine("Who is the ruler of Southeros?");
            Console.WriteLine("Output: {0}", universe.GetRullerName());
            Console.WriteLine("Allies of King Shan?");
            Console.WriteLine("Output: {0} ", universe.GetRullerAllies());
            Console.WriteLine();
        }

        public static void PrintRoundsResult(Dictionary<string, List<string>> results)
        {
            Console.WriteLine();
            foreach (var round in results)
            {
                Console.WriteLine(round.Key);
                foreach (var result in round.Value)
                {
                    Console.WriteLine(result);
                }
            }
            Console.WriteLine();
        }
    }
}
