namespace AdventOfCode
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    public class HomeworkSolver : InputDataHandler
    {
        public static long Solve(string problem)
        {
            // Trim away whitespaces
            var remainingProblem = Regex.Replace(problem, " ", string.Empty);
            long answer = GetArgument(ref remainingProblem);

            // Check length > 1 in case of a leftover "double parenthesis"
            while (remainingProblem.Length > 1)
            {
                char operand = remainingProblem[0];
                remainingProblem = remainingProblem.Substring(1);
                if (operand == ')')
                {
                    operand = remainingProblem[0];
                    remainingProblem = remainingProblem.Substring(1);
                }

                long secondArgument = GetArgument(ref remainingProblem);

                switch (operand)
                {
                    case '+':
                        answer += secondArgument;
                        break;
                    case '*':
                        answer *= secondArgument;
                        break;

                }
            }

            return answer;
        }

        private static long GetArgument(ref string remainingProblem)
        {
            long argument;
            int iArgument = 0;
            if (remainingProblem[iArgument] == '(')
            {
                var iEndParenthesis = remainingProblem.IndexOf(')');

                // Handle the case for parenthesis within another parenthesis
                if (iEndParenthesis == -1)
                {
                    // if no end parenthesis found, keep the string until the end
                    argument = Solve(remainingProblem.Substring(1));
                    iArgument = remainingProblem.Length;
                }
                else
                {
                    argument = Solve(remainingProblem.Substring(1, iEndParenthesis - 1));
                    iArgument = iEndParenthesis + 1;
                }
            }
            else
            {
                argument = long.Parse(remainingProblem[iArgument].ToString());
                iArgument++;
            }

            remainingProblem = remainingProblem.Substring(iArgument);

            return argument;
        }

        public static long SolveAll(string[] problems)
        {
            long sum = 0;

            foreach (var problem in problems)
            {
                sum += Solve(problem);
            }

            return sum;
        }
    }
}