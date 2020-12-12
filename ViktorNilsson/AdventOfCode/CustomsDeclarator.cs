namespace AdventOfCode
{
    using System;
    using System.Linq;
    using System.Text.RegularExpressions;

    public class CustomsDeclarator
    {

        public static string[] GetInputData(string filePath)
        {
            string[] groupAnswers = InputDataHandler.ReadFileAsArray(filePath, "\r\n\r\n");

            return groupAnswers;
        }

        public static int CountAnswers(string groupAnswer)
        {
            string cleanedAnswer = Regex.Replace(groupAnswer, @"\s+", string.Empty);
            string uniqueAnswers = new String(cleanedAnswer.Distinct().ToArray());
            int uniquePositiveAnswers = uniqueAnswers.Length;
            return uniquePositiveAnswers;
        }

        public static int SumAnswers(string[] groupAnswerArray)
        {
            int sum = 0;
            foreach (var groupAnswer in groupAnswerArray)
            {
                sum += CountAnswers(groupAnswer);
            }

            return sum;
        }

        public static int CountConsensusAnswers(string groupAnswer)
        {
            string[] answerArray = groupAnswer.Split(new string[] { "\r\n" }, StringSplitOptions.None);

            if (answerArray.Length == 1)
            {
                return answerArray[0].Length;
            }

            // Start with person one and check one by one who also asnwered yes
            var answerConsensus = answerArray[0].ToArray().Intersect(answerArray[1].ToArray());
            for (int iAnswer = 2; iAnswer < answerArray.Length; iAnswer++)
            {
                answerConsensus = answerConsensus.Intersect(answerArray[iAnswer].ToArray());
            }

            return answerConsensus.ToArray().Length;
        }

        public static int SumConsensusAnswers(string[] groupAnswerArray)
        {
            int sum = 0;
            foreach (var groupAnswer in groupAnswerArray)
            {
                sum += CountConsensusAnswers(groupAnswer);
            }

            return sum;
        }
    }
}