using System;
using System.Collections.Generic;
using System.IO;

namespace TestAdventOfCode
{
    public class ExpepenseReport
    {
        public static(int, int) FindSum(List<int> numbers, int sum)
        {
            foreach (int x in numbers)
            {
                foreach (int y in numbers)
                {
                    if (x + y == sum)
                    {
                        return (x, y);
                    }
                }
            }

            return (0, 0);
        }

        public List<int> GetInputData()
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

        public List<int> FindTrippleSum(List<int> numbers, int desiredSum)
        {
            int num2, num3;
            foreach (int num1 in numbers)
            {
                (num2, num3) = ExpepenseReport.FindSum(numbers, desiredSum - num1);
                if (num1 + num2 + num3 == desiredSum)
                {
                    return new List<int>() { num1, num2, num3 };
                }
            }
            return new List<int>();
        }
    }
}