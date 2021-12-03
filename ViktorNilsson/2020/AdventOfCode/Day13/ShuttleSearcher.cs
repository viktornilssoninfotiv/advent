namespace AdventOfCode
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    public class ShuttleSearcher : InputDataHandler
    {
        public static int NextDeparture(int startTimestamp, int busId)
        {
            return ((startTimestamp / busId) + 1) * busId;
        }

        public static (int departure, int waitTime, int busId) EarliestDeparture(int startTimestamp, List<int> busList)
        {
            int iBus = 0;
            int nextBus = busList[iBus];
            int minDeparture = NextDeparture(startTimestamp, nextBus);
            int newDeparture;
            foreach (var bus in busList)
            {
                newDeparture = NextDeparture(startTimestamp, bus);

                if (newDeparture < minDeparture)
                {
                    minDeparture = newDeparture;
                    nextBus = bus;
                }
            }

            return (minDeparture, minDeparture - startTimestamp, nextBus);
        }

        public static List<int> GetBusList(string[] rawData)
        {
            string rawBusList = rawData[1];

            // Remove busses that doesn't depart
            string validBuses = Regex.Replace(rawBusList, ",x", string.Empty);

            // Split valid busses into list
            var busList = validBuses.Split(',').Select(int.Parse).ToList();
            busList.Sort();
            return busList;
        }
    }
}