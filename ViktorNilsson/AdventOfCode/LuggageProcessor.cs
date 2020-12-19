namespace AdventOfCode
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

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
            var bagsToLookFor = new HashSet<string>();

            // Search for possible bag options until adding another level doesn't find any new bags,
            bagsToLookFor.Add(desiredBagColor);
            while (bagsToLookFor.Count > 0)
            {
                var addedOptions = new HashSet<string>();
                foreach (var potentialBag in ruleBook)
                {
                    // If the potential bag contains any of the bag we are looking for at the current level, store it
                    if (potentialBag.Value.Any(bagsToLookFor.Contains))
                    {
                        possibleBagOptions.Add(potentialBag.Key);
                        addedOptions.Add(potentialBag.Key);
                    }
                }

                // Now look in the next level for the bags we found here, to see if we can find new ones
                bagsToLookFor = addedOptions;
            }

            return possibleBagOptions.ToList();
        }
    }
}