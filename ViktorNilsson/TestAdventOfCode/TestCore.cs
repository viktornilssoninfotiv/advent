namespace AdventOfCode
{
    using NUnit.Framework;

    public class TestCore : InputDataHandler
    {
        private string DayPath;
        private string FilePathInputData;
        private string FilePathTestData;
        public char[,] testData;
        public char[,] inputData;

        public TestCore(int day)
        {
            this.DayPath = @"../../../../AdventOfCode/Day" + day + "/";
            this.FilePathInputData = this.DayPath + "InputData.txt";
            this.FilePathTestData = this.DayPath + "TestData.txt";
        }

        [SetUp]
        public void Setup()
        {
            this.testData = this.GetInputDataMap(this.FilePathTestData);
            this.inputData = this.GetInputDataMap(this.FilePathInputData);
        }
    }
}