namespace AdventOfCode
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    public class Memory : InputDataHandler
    {
        public static object Round(int iEnd, List<int> numList)
        {
            for (int i = numList.Count; i < iEnd; i++)
            {
                // if it was the first time the last number was spoken
                int lastNumber = numList[i - 1];
                if (numList.FindAll(num => num == lastNumber).Count == 1)
                {
                    numList.Add(0);
                }
                else
                {
                    int lastNumberIdx = numList.FindLastIndex(num => num == lastNumber);
                    int lastNumberIdxPrev = numList.FindLastIndex(lastNumberIdx - 1, num => num == lastNumber);
                    numList.Add(lastNumberIdx - lastNumberIdxPrev);
                }
            }

            return numList[iEnd - 1];
        }
    }
}