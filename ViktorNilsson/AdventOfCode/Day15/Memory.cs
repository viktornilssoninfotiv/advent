namespace AdventOfCode
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    public class Memory : InputDataHandler
    {
        public static int Round(int iEnd, List<int> numList)
        {
            //Dictionary<int, int> numDict = numList.ToDictionary(key => key, idx => numList.FindIndex(v => ));
            Dictionary<int, int> numDict = new Dictionary<int, int>();
            int lastNumber = 0;
            int currentNumber = 0;
            // Convert the list to a Dictionary where the numer is key and the last time it was said is the value
            for (int idx = 0; idx < numList.Count && idx < iEnd; idx++)
            {
                lastNumber = numList[idx];
                numDict[lastNumber] = idx + 1;
            }

            // Find the next number that shall be spoken 
            for (int i = numList.Count + 1; i <= iEnd; i++)
            {
                // if it was the first time the last number was spoken
                if (!numDict.Keys.Contains(lastNumber))
                {
                    numDict[lastNumber] = i - 1;
                    currentNumber = 0;
                }
                else if (numDict[lastNumber] == i - 1)
                {
                    currentNumber = 0;
                }
                else
                {
                    currentNumber = i - numDict[lastNumber] - 1;
                    numDict[lastNumber] = i - 1;
                }

                lastNumber = currentNumber;
            }

            return lastNumber;
        }
    }
}