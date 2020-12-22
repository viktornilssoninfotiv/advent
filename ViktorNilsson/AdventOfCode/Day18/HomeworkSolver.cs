namespace AdventOfCode
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    public class HomeworkSolver : InputDataHandler
    {
        public static int Solve(string problem)
        {
            int answer = 0;

            // Trim away whitespaces
            var remainingProblem = Regex.Replace(problem, " ", string.Empty);
            int firstArgument = int.Parse(remainingProblem[0].ToString());
            remainingProblem = remainingProblem.Substring(1);

            while (remainingProblem.Length > 0)
            {
                char operand = remainingProblem[0];
                int secondArgument = int.Parse(remainingProblem[1].ToString());

                // TODO: Handle parenthesis (first in the middle of the string then at the beginning, then multiple)
                switch (operand)
                {
                    case '+':
                        answer = firstArgument + secondArgument;
                        break;
                    case '*':
                        answer = firstArgument * secondArgument;
                        break;
                }

                firstArgument = answer;
                remainingProblem = remainingProblem.Substring(2);
            }

            return answer;
        }
    }

}