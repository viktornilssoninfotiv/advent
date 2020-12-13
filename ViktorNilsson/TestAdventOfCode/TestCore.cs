namespace AdventOfCode
{
    using NUnit.Framework;

    public class TestCore : InputDataHandler
    {
        private char[,] testData;
        private char[,] inputData;
        private readonly string dayPath;
        private readonly string filePathInputData;
        private readonly string filePathTestData;

        public TestCore(int day)
        {
            this.dayPath = @"../../../../AdventOfCode/Day" + day + "/";
            this.filePathInputData = this.dayPath + "InputData.txt";
            this.filePathTestData = this.dayPath + "TestData.txt";
        }

        [SetUp]
        public void Setup()
        {
            this.testData = this.GetInputDataMap(this.filePathTestData);
            this.inputData = this.GetInputDataMap(this.filePathInputData);
        }
    }
}