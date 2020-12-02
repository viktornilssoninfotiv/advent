using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace TestAdventOfCode
{
    public class ExpepenseReport
    {
        public static List<int> FindSum(List<int> numbers, int sum)
        {
            var result = new List<int>();
            foreach (int x in numbers)
            {
                foreach (int y in numbers)
                {
                    if (x + y == sum)
                    {
                        result.Add(x);
                        result.Add(y);
                        return result;
                    }
                }
            }

            return result;
        }

        public static List<int> GetInputData()
        {
            var numbers = new List<int>();
            // Specify folder since it can be run from elsewhere, e.g. unittest
            string fileContent = File.ReadAllText("../../../../AdventOfCode/DayOneInput.txt");
            string[] stringNumbers = fileContent.Split('\n');

            foreach (string s in stringNumbers)
            {
                numbers.Add(Convert.ToInt32(s));
            }
            return numbers;
        }

        public static List<int> FindTrippleSum(List<int> numbers, int desiredSum)
        {
            var sum = new List<int>();
            foreach (int num1 in numbers)
            {
                sum = ExpepenseReport.FindSum(numbers, desiredSum - num1);
                if (num1 + sum.Sum() == desiredSum)
                {
                    sum.Add(num1);
                    return sum;
                }
            }
            return new List<int>();
        }
    }
}