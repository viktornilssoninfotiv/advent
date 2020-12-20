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

        private static List<int> GetTicketFields(string dataStr)
        {
            return Array.ConvertAll(dataStr.Split(','), int.Parse).ToList();
        }

        private int FindTicketIndex(string header)
        {
            return this.rawData.FindLastIndex(s => s == header) + 1;
        }

        public Dictionary<string, string[]> GetFieldRules()
        {
            throw new NotImplementedException();
        }
    }
}