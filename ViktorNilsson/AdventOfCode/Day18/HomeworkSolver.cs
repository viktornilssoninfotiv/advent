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
            int firstArgument = GetArgument(ref remainingProblem);

            while (remainingProblem.Length > 0)
            {
                char operand = remainingProblem[0];
                remainingProblem = remainingProblem.Substring(1);
                int secondArgument = GetArgument(ref remainingProblem);

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
            }

            return answer;
        }

        private static int GetArgument(ref string remainingProblem)
        {
            int argument;
            int iArgument = 0;
            if (remainingProblem[iArgument] == '(')
            {
                var iEndParenthesis = remainingProblem.IndexOf(')');

                // Handle the case for parenthesis within another parenthesis
                if (iEndParenthesis == -1)
                {
                    // if no end parenthesis found, keep the string until the end
                    argument = Solve(remainingProblem = remainingProblem.Substring(1));
                }
                else
                {
                    argument = Solve(remainingProblem.Substring(1, iEndParenthesis - 1));
                    iArgument = iEndParenthesis;
                }
            }
            else
            {
                argument = int.Parse(remainingProblem[iArgument].ToString());
            }

            remainingProblem = remainingProblem.Substring(iArgument + 1);

            return argument;
        }
    }
}