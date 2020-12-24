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
            long argument = GetArgument(ref remainingProblem);

            while (remainingProblem.Length > 0)
            {
                char operand = remainingProblem[0];
                remainingProblem = remainingProblem.Substring(1);

                long secondArgument = GetArgument(ref remainingProblem);

                switch (operand)
                {
                    case '+':
                        argument += secondArgument;
                        break;
                    case '*':
                        argument *= secondArgument;
                        break;
                }
            }

            return argument;
        }

        public static long GetArgument(ref string problem)
        {
            long argument;
            int iArgument = 0;
            if (problem[iArgument] == '(')
            {
                var iEndParenthesis = FindEndParenthesis(problem);

                // Handle the case for parenthesis within another parenthesis
                if (iEndParenthesis == -1)
                {
                    // if no end parenthesis found, keep the string until the end
                    argument = Solve(problem.Substring(1));
                    iArgument = problem.Length;
                }
                else
                {
                    argument = Solve(problem.Substring(1, iEndParenthesis - 1));
                    iArgument = iEndParenthesis + 1;
                }
            }
            else
            {
                argument = long.Parse(problem[iArgument].ToString());
                iArgument++;
            }

            problem = problem.Substring(iArgument);

            return argument;
        }

        public static int FindEndParenthesis(string problem)
        {
            int iEndParenthesis;
            int startParenthesis = 0;
            int endParenthesis = 0;
            for (iEndParenthesis = 0; iEndParenthesis < problem.Length; iEndParenthesis++)
            {
                switch (problem[iEndParenthesis])
                {
                    case '(':
                        startParenthesis++;
                        break;
                    case ')':
                        endParenthesis++;
                        break;
                }

                // Check if matching numbers of start and end parenthesises have been found
                if (endParenthesis == startParenthesis)
                {
                    break;
                }
            }

            return iEndParenthesis;
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