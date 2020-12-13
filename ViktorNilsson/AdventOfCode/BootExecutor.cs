namespace AdventOfCode
{
    using System.Collections.Generic;

    public class BootExecutor
    {
        public string Instruction;
        public int Argument;
        public int Visits;

        public BootExecutor(string instructionRaw)
        {
            this.Instruction = instructionRaw.Split(' ')[0];
            this.Argument = int.Parse(instructionRaw.Split(' ')[1]);
            this.Visits = 0;
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
            BootExecutor currentInstruction;
            do
            {
                currentInstruction = instructionList[instructionRow];
                instructionList[instructionRow].Visits++;
                switch (currentInstruction.Instruction)
                {
                    case "nop":
                        instructionRow++;
                        break;
                    case "acc":
                        accumulator += currentInstruction.Argument;
                        instructionRow++;
                        break;
                    case "jmp":
                        instructionRow += currentInstruction.Argument;
                        break;
                }
            }
            while (instructionRow <= instructionList.Count && instructionList[instructionRow].Visits == 0);

            return accumulator;
        }
    }
}