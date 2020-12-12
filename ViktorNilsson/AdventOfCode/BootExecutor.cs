namespace AdventOfCode
{
    using System.Collections.Generic;

    public class BootExecutor
    {
        public string instruction;
        public int argument;
        public int visits;

        public BootExecutor(string instructionRaw)
        {
            this.instruction = instructionRaw.Split(' ')[0];
            this.argument = int.Parse(instructionRaw.Split(' ')[1]);
            this.visits = 0;
        }

        public static string[] GetInputData(string filePath)
        {
            string[] groupAnswers = InputDataHandler.ReadFileAsArray(filePath);

            return groupAnswers;
        }

        public static List<BootExecutor> CreateInstructionList(string[] data)
        {
            var instructionList = new List<BootExecutor>();
            foreach (var instructionRaw in data)
            {
                instructionList.Add(new BootExecutor(instructionRaw));
            }

            return instructionList;
        }

        public static int RunBoot(List<BootExecutor> instructionList)
        {
            int accumulator = 0;
            int instructionRow = 0;
            int prevInstructionRow = 0;
            BootExecutor currentInstruction;
            do
            {
                prevInstructionRow = instructionRow;
                currentInstruction = instructionList[instructionRow];
                instructionList[instructionRow].visits++;
                switch (currentInstruction.instruction)
                {
                    case "nop":
                        instructionRow++;
                        break;
                    case "acc":
                        accumulator += currentInstruction.argument;
                        instructionRow++;
                        break;
                    case "jmp":
                        instructionRow += currentInstruction.argument;
                        break;
                }
            } while (instructionRow <= instructionList.Count && instructionList[instructionRow].visits == 0);

            return accumulator;
        }
    }
}