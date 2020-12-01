using System;
using System.Collections.Generic;

namespace TestAdventOfCode
{
    public class ExpepenseReport
    {
        public (int, int) FindSum(List<int> numbers, int sum)
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
    }
}