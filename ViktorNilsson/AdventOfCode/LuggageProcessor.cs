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
            var possibleBagOptions = new HashSet<string>();
            var bagsToLookIn = new List<string>();
            var bagsToLookFor = new HashSet<string>();

            // Traverse the rule book to find the possible bags
            bagsToLookIn = ruleBook.Keys.ToList();
            bagsToLookFor.Add(desiredBagColor);

            // Search for possible bag options until adding another level doesn't find any new bags,
            // i.e the HshSet has not increased in size
            while (bagsToLookFor.Count > 0)
            {
                var addedOptions = new HashSet<string>();
                foreach (var potentialBag in bagsToLookIn)
                {
                    // If the potential bag contains any of the bag we are looking for at the current level, store it
                    if (ruleBook[potentialBag].Any(bagsToLookFor.Contains))
                    {
                        possibleBagOptions.Add(potentialBag);
                        addedOptions.Add(potentialBag);
                    }
                }

                // Now look in the next level for the bags we found here, to see if we can find new ones
                bagsToLookFor = addedOptions;
            }

            return possibleBagOptions.ToList();
        }
    }
}