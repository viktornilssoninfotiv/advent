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
            int firstArgument;
            int iFirstArgument = 0;

            if (remainingProblem[0] == '(')
            {
                // Extract the part within parenthesis and solve that first
                var iEndParenthesis = remainingProblem.IndexOf(')');
                firstArgument = Solve(remainingProblem.Substring(iFirstArgument + 1, iEndParenthesis - iFirstArgument - 1));
                iFirstArgument = iEndParenthesis;
            }
            else
            {
                firstArgument = int.Parse(remainingProblem[iFirstArgument].ToString());
            }

            remainingProblem = remainingProblem.Substring(iFirstArgument + 1);

            while (remainingProblem.Length > 0)
            {
                int secondArgument;
                int iSecondArgument = 1;
                if (remainingProblem[iSecondArgument] == '(')
                {
                    // Extract the part within parenthesis and solve that first
                    var iEndParenthesis = remainingProblem.IndexOf(')');
                    secondArgument = Solve(remainingProblem.Substring(2, iEndParenthesis - 2));
                    iSecondArgument = iEndParenthesis;
                }
                else
                {
                    secondArgument = int.Parse(remainingProblem[iSecondArgument].ToString());
                }
                char operand = remainingProblem[0];

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
                remainingProblem = remainingProblem.Substring(iSecondArgument + 1);
            }

            return answer;
        }
    }

}