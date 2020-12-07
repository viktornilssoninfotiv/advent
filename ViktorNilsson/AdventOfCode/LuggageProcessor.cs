using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace TestAdventOfCode
{
    public class LuggageProcessor
    {

        public static string[] GetInputData(string filePath)
        {
            string[] groupAnswers = InputDataHandler.ReadFileAsArray(filePath);

            return groupAnswers;
        }

        public static Dictionary<string, string[]> ParseLuggageRule(string luggageRuleRaw)
        {
            var luggageRule = new Dictionary<string, string[]>();
            string[] bagList = Regex.Split(luggageRuleRaw, " bags contain ");
            string containerBag = bagList[0];
            string cleanedContainedBags = Regex.Replace(bagList[1], @"([0-9]\s)|\sbags|\sbag|\.|(no other)", string.Empty);
            luggageRule[containerBag] = Regex.Split(cleanedContainedBags, ", ");
            return luggageRule;
        }

        public static Dictionary<string, string[]> CreateRuleBook(string[] luggageRuleList)
        {
            var ruleBook = new Dictionary<string, string[]>();
            foreach (string luggageRule in luggageRuleList)
            {
                var parsedRule = ParseLuggageRule(luggageRule);
                ruleBook = ruleBook.Concat(parsedRule).ToDictionary(x => x.Key, x => x.Value);
            }

            return ruleBook;
        }

        public static int CountBagOptions(Dictionary<string, string[]> ruleBook, string desiredBagColor)
        {
            List<string> possibleBagOptions = GetBagOptions(ruleBook, desiredBagColor);
            return possibleBagOptions.Count;
        }

        public static List<string> GetBagOptions(Dictionary<string, string[]> ruleBook, string desiredBagColor)
        {
            List<string> possibleBagOptions = possibleBagOptions = new List<string>();
            //List<string> possibleBagOptions = ruleBook.Keys.ToList();

            // Want to carry the desired bag in at least one other bag
            //possibleBagOptions.Remove(bagColor);

            // Traverse the rule book to find the possible bags
            // Find all bags that can carry the desired color in 1 "step"
            foreach (var potentialBag in ruleBook)
            {
                /*
                // If the bag cannot carry other bags it can be removed from potential bags
                if (potentialBag.Value == null)
                {
                    possibleBagOptions.Remove(potentialBag.Key);
                    continue;
                }
                */
                if (potentialBag.Value.Contains(desiredBagColor))
                {
                    possibleBagOptions.Add(potentialBag.Key);
                }


            }


            Console.WriteLine("Possible bag options: " + possibleBagOptions);
            return possibleBagOptions;
        }
    }
}