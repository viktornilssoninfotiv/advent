namespace AdventOfCode
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    public class TicketTranslator : InputDataHandler
    {
        private List<string> rawData;

        public TicketTranslator(string filePathData)
        {
            this.rawData = ReadFileAsArray(filePathData).ToList();
        }

        public List<int> GetTicket()
        {
            int ticketIdx = this.FindTicketIndex("your ticket:");
            string dataStr = this.rawData[ticketIdx];
            var ticketFields = GetTicketFields(dataStr);
            return ticketFields;
        }

        public List<List<int>> GetNearbyTickets()
        {
            var nearbyTickets = new List<List<int>>();
            int ticketIdx = this.FindTicketIndex("nearby tickets:");
            List<string> ticketStrings = this.rawData.GetRange(ticketIdx, this.rawData.Count - ticketIdx);
            foreach (var dataStr in ticketStrings)
            {
                List<int> ticketFields = GetTicketFields(dataStr);
                nearbyTickets.Add(ticketFields);
            }

            return nearbyTickets;
        }

        public Dictionary<string, string[]> GetFieldRules()
        {
            var fieldRules = new Dictionary<string, string[]>();
            int iRow = 0;
            string row = this.rawData[iRow];

            while (row != string.Empty)
            {
                var ruleParts = Regex.Split(row, ": ");
                fieldRules[ruleParts[0]] = Regex.Split(ruleParts[1], " or ");
                iRow++;
                row = this.rawData[iRow];
            }

            return fieldRules;
        }

        public int GetTicketScanningErrorRate()
        {
            int errorRate = 0;
            var fieldRules = this.GetFieldRules();
            var nearbyTickets = this.GetNearbyTickets();
            var invalidFields = new List<int>();
            foreach (var ticket in nearbyTickets)
            {
                invalidFields.AddRange(ValidateTicketFields(fieldRules, ticket));
            }

            errorRate = invalidFields.Sum();

            return errorRate;
        }

        private static List<int> GetTicketFields(string dataStr)
        {
            return Array.ConvertAll(dataStr.Split(','), int.Parse).ToList();
        }

        private int FindTicketIndex(string header)
        {
            return this.rawData.FindLastIndex(s => s == header) + 1;
        }

        public static List<int> ValidateTicketFields(Dictionary<string, string[]> fieldRules, List<int> ticketFields)
        {
            var invalidFields = new List<int>();

            // Simplyfy the rules and only care about the number ranges
            var rangeRules = SimplifyRules(fieldRules);

            // Check all rules for every field
            foreach (var field in ticketFields)
            {
                invalidFields.Add(field);
                foreach (var rule in rangeRules)
                {
                    if ((field >= rule[0] && field <= rule[1]) || (field >= rule[2] && field <= rule[3]))
                    {
                        // If the field is valid for any rule it is OK
                        invalidFields.Remove(field);
                        break;
                    }
                }
            }

            return invalidFields;
        }

        private static List<int[]> SimplifyRules(Dictionary<string, string[]> fieldRules)
        {
            var rangeRules = new List<int[]>();
            foreach (var rule in fieldRules.Values)
            {
                var intRange = new List<int>();
                foreach (var range in rule)
                {
                    var numberRange = range.Split('-');
                    intRange.AddRange(Array.ConvertAll(numberRange, s => int.Parse(s)));
                }

                rangeRules.Add(intRange.ToArray());
            }

            return rangeRules;
        }
    }
}