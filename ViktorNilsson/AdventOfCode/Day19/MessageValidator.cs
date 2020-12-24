namespace AdventOfCode
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    public class MessageValidator : InputDataHandler
    {
        public static Dictionary<string, string> GetRules(string[] rawData)
        {
            var rules = new Dictionary<string, string>();

            foreach (var row in rawData)
            {
                // Rules and messages are separated by empty row
                if (row == string.Empty)
                {
                    break;
                }

                string[] kvp = Regex.Split(row, ": ");

                // Remove quotations around letters
                var rule = Regex.Replace(kvp[1], "\"", string.Empty);
                rules[kvp[0]] = rule;
            }

            return rules;
        }

        public static List<string> GetMessages(string[] rawData)
        {
            var messages = new List<string>();

            foreach (var row in rawData.Reverse())
            {
                // Rules and messages are separated by empty row
                if (row == string.Empty)
                {
                    break;
                }

                messages.Add(row);
            }

            messages.Reverse();

            return messages;
        }

        public static bool Validate(string message, Dictionary<string, string> rules)
        {
            bool valid = false;
            List<string> validMessages = GetValidMessages(rules);
            valid = validMessages.Contains(message);

            return valid;
        }

        public static List<string> GetValidMessages(Dictionary<string, string> rules)
        {
            var validMessages = new List<string>();
            string allValidMessages = string.Empty;

            string currentRule = rules["0"];

            allValidMessages = UnfoldRule(rules, currentRule);

            validMessages = allValidMessages.Split('|').ToList();

            return validMessages;
        }

        private static string UnfoldRule(Dictionary<string, string> rules, string currentRule)
        {
            string allValidMessages = string.Empty;
            foreach (var subRule in currentRule)
            {
                // Keep the OR as is
                if (subRule == '|')
                {
                    allValidMessages += subRule;
                }
                else
                {
                    allValidMessages += rules[subRule.ToString()];
                }
            }
            allValidMessages = UnfoldRule(rules, allValidMessages);

            return allValidMessages;
        }
    }
}