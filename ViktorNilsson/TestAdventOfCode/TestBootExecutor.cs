namespace AdventOfCode
{
    using System.Collections.Generic;
    using NUnit.Framework;

    public class TestBootExecutor
    {
        private const string Day = "Eight";
        private const string FilePathInputData = "../../../../AdventOfCode/InputData/Day" + Day + "Input.txt";
        private const string FilePathInputData2 = "../../../../AdventOfCode/InputData/Day" + Day + "Input2.txt";
        private const string FilePathTestData = "../../../TestData/Day" + Day + "TestData.txt";

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestGetInputData()
        {
            string[] testData = BootExecutor.GetInputData(FilePathTestData);
            Assert.AreEqual(9, testData.GetLength(0));
            Assert.AreEqual("nop +0", testData[0]);
        }

        [Test]
        public void TestBootExecutorConstructor()
        {
            var instruction = new BootExecutor("nop +0");
            Assert.AreEqual("nop", instruction.instruction);
            Assert.AreEqual(0, instruction.argument);
            Assert.AreEqual(0, instruction.visits);
        }

        [Test]
        public void TestCreateInstructionList()
        {
            string[] testData = BootExecutor.GetInputData(FilePathTestData);
            List<BootExecutor> instructionList = BootExecutor.CreateInstructionList(testData);
            Assert.AreEqual(9, instructionList.Count);
        }

        [Test]
        public void TestRunBoot()
        {
            string[] testData = BootExecutor.GetInputData(FilePathTestData);
            List<BootExecutor> instructionList = BootExecutor.CreateInstructionList(testData);
            int accumulator = BootExecutor.RunBoot(instructionList);
            Assert.AreEqual(5, accumulator);
        }

        [Test]
        public void FindAnswerDayEightPuzzleOne()
        {
            string[] testData = BootExecutor.GetInputData(FilePathInputData);
            List<BootExecutor> instructionList = BootExecutor.CreateInstructionList(testData);
            int accumulator = BootExecutor.RunBoot(instructionList);
            Assert.AreEqual(1797, accumulator);
        }

        [Test]
        public void FindAnswerDayEightPuzzleTwo()
        {
            string[] testData = BootExecutor.GetInputData(FilePathInputData2);
            List<BootExecutor> instructionList = BootExecutor.CreateInstructionList(testData);
            int accumulator = BootExecutor.RunBoot(instructionList);
            Assert.Warn("Not solved");

            // Assert.Less(accumulator, 1752);
            // Assert.AreEqual(1797, accumulator);
        }
    }
}