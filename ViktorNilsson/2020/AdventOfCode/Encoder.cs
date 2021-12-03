namespace AdventOfCode
{
    using System.Collections.Generic;

    public class Encoder
    {
        public static List<long> GetInputData(string filePath)
        {
            var inputData = new List<long>();
            string[] inputDataRaw = InputDataHandler.ReadFileAsArray(filePath);

            foreach (var s in inputDataRaw)
            {
                inputData.Add(long.Parse(s));
            }

            return inputData;
        }

        public static (long num, List<long> set) FindWeakness(List<long> data, int preambleLength)
        {
            long weaknessNumber = 0;
            long currentNumber;
            int i;
            for (i = preambleLength; i < data.Count; i++)
            {
                currentNumber = data[i];
                List<long> validNumbers = FindSums(data.GetRange(i - preambleLength, preambleLength));
                if (!validNumbers.Contains(currentNumber))
                {
                    weaknessNumber = currentNumber;
                    break;
                }
            }

            return (weaknessNumber, data.GetRange(0, i));
        }

        public static List<long> FindSums(List<long> numbers)
        {
            var sums = new List<long>();

            for (int i = 0; i < numbers.Count; i++)
            {
                for (int j = numbers.Count - 1; j > i; j--)
                {
                    sums.Add(numbers[i] + numbers[j]);
                }
            }

            sums.Sort();
            return sums;
        }

        public static List<long> FindSumSet(List<long> data, long sumToFind)
        {
            var sumSet = new List<long>();
            int i, j;
            for (i = 1; i < data.Count; i++)
            {
                // TODO: Need to find sum of ALL values in the range, not just 2
                var ammountToSum = data.Count - i;
                var sums = FindSums(data.GetRange(0, i));

                // Check if the end of the sum set has been found
                if (sums.Contains(sumToFind))
                {
                    break;
                }
            }

            for (j = 0; j < data.Count; j++)
            {
                var sums = FindSums(data.GetRange(j, i - j));

                // When the sum to find is no longer present the lower index has been found
                if (!sums.Contains(sumToFind))
                {
                    break;
                }
            }

            int startIdx = j - 1;
            sumSet = data.GetRange(startIdx, i - startIdx);

            return sumSet;
        }
    }
}