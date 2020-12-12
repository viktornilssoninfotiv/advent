namespace AdventOfCode
{
    using System;
    using System.Collections.Generic;
    using NUnit.Framework;

    public class TestLuggageProcessor
    {
        private const string FilePathInputData = @"C:\Users\Viktor\source\repos\advent\ViktorNilsson\AdventOfCode\InputData\DaySevenInput.txt";
        private const string FilePathTestData = "../../../TestData/DaySevenTestData.txt";

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestGetInputData()
        {
            string[] groupAnswers = LuggageProcessor.GetInputData(FilePathTestData);
            Assert.AreEqual(9, groupAnswers.GetLength(0));
        }

        [TestCase(0, "light red", new string[] { "bright white", "muted yellow" })]
        [TestCase(1, "dark orange", new string[] { "bright white", "muted yellow" })]
        [TestCase(2, "bright white", new string[] { "shiny gold" })]
        [TestCase(7, "faded blue", new string[] { "" })]
        public void TestParseLuggageRule(int iTestData, string colorKey, string[] colorValues)
        {
            Dictionary<string, string[]> expectedAnswer = new Dictionary<string, string[]>();
            expectedAnswer[colorKey] = colorValues;

            string[] rawData = LuggageProcessor.GetInputData(FilePathTestData);
            Dictionary<string, string[]> parsedRule = LuggageProcessor.ParseLuggageRule(rawData[iTestData]);
            Assert.AreEqual(expectedAnswer, parsedRule);
        }

        [Test]
        public void TestCreateRuleBook()
        {
            string[] rawData = LuggageProcessor.GetInputData(FilePathTestData);
            Dictionary<string, string[]> ruleBook = LuggageProcessor.CreateRuleBook(rawData);
            Assert.AreEqual(9, ruleBook.Keys.Count);
        }

        [TestCase("shiny gold", "bright white")]
        [TestCase("shiny gold", "muted yellow")]
        [TestCase("shiny gold", "dark orange")]
        [TestCase("shiny gold", "light red")]
        public void TestGetBagOptionsContains(string bagColor, string expectedColor)
        {
            string[] rawData = LuggageProcessor.GetInputData(FilePathTestData);
            Dictionary<string, string[]> ruleBook = LuggageProcessor.CreateRuleBook(rawData);
            List<string> bagOptions = LuggageProcessor.GetBagOptions(ruleBook, bagColor);
            Assert.Contains(expectedColor, bagOptions);
        }

        [Test]
        public void TestGetBagOptionsContains()
        {
            string[] rawData = LuggageProcessor.GetInputData(FilePathTestData);
            Dictionary<string, string[]> ruleBook = LuggageProcessor.CreateRuleBook(rawData);
            List<string> bagOptions = LuggageProcessor.GetBagOptions(ruleBook, "not existing");
            Assert.IsEmpty(bagOptions);
        }

        [Test]
        public void TestGetBagOptionsEquality()
        {
            var expectedColors = new List<string> { "bright white", "muted yellow", "dark orange", "light red" };
            string[] rawData = LuggageProcessor.GetInputData(FilePathTestData);
            Dictionary<string, string[]> ruleBook = LuggageProcessor.CreateRuleBook(rawData);
            List<string> bagOptions = LuggageProcessor.GetBagOptions(ruleBook, "shiny gold");
            Assert.Warn("Not solved");

            // Assert.AreEqual(expectedColors, bagOptions);
        }

        [TestCase("shiny gold", 4)]
        [TestCase("not existing", 0)]
        public void TestCountBagOptions(string bagColor, int exptectedOptions)
        {
            string[] rawData = LuggageProcessor.GetInputData(FilePathTestData);
            Dictionary<string, string[]> ruleBook = LuggageProcessor.CreateRuleBook(rawData);
            int numberOfBagOptions = LuggageProcessor.CountBagOptions(ruleBook, bagColor);
            Assert.AreEqual(exptectedOptions, numberOfBagOptions);
        }

        [Test]
        public void FindAnserDaySevenPuzzleOne()
        {
            string[] rawData = LuggageProcessor.GetInputData(FilePathInputData);
            Dictionary<string, string[]> ruleBook = LuggageProcessor.CreateRuleBook(rawData);
            int numberOfBagOptions = LuggageProcessor.CountBagOptions(ruleBook, "shiny gold");
            Console.WriteLine("Number of bag options: " + numberOfBagOptions);
            Assert.AreEqual(224, numberOfBagOptions);
        }

        [Test]
        public void FindAnserDaySevenPuzzleTwo()
        {
            string[] rawData = LuggageProcessor.GetInputData(FilePathInputData);
            Dictionary<string, string[]> ruleBook = LuggageProcessor.CreateRuleBook(rawData);
            Assert.Warn("Not solved");
        }
    }
}