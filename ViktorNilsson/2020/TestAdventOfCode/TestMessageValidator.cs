namespace AdventOfCode
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using NUnit.Framework;

    public class TestMessageValidator
    {
        private const string DayPath = @"../../../../AdventOfCode/Day19/";
        private const string FilePathInputData = DayPath + "InputData.txt";
        private const string FilePathTestData = DayPath + "TestData.txt";
        private string[] testData;
        private string[] inputData;

        [SetUp]
        public void Setup()
        {
            this.testData = MessageValidator.ReadFileAsArray(FilePathTestData);
            this.inputData = MessageValidator.ReadFileAsArray(FilePathInputData);
        }

        [Test]
        public void TestGetRules()
        {
            Dictionary<string, string> rules = MessageValidator.GetRules(this.testData);
            Assert.AreEqual(6, rules.Keys.Count);
            Assert.AreEqual("b", rules["5"]);
        }

        [Test]
        public void TestGetMessages()
        {
            List<string> messages = MessageValidator.GetMessages(this.testData);
            Assert.AreEqual(5, messages.Count);
            Assert.AreEqual("aaaabbb", messages[4]);
        }

        [Test]
        public void TestGetValidMessages()
        {
            Dictionary<string, string> rules = MessageValidator.GetRules(this.testData);
            string validMessagePath = TestMessageValidator.DayPath + "TestValidMessages.txt";
            List<string> validMessages = MessageValidator.ReadFileAsArray(validMessagePath).ToList();

            List<string> messages = MessageValidator.GetValidMessages(rules);

            Assert.AreEqual(validMessages.Count, messages.Count);
            Assert.AreEqual(validMessages, messages);
        }

        [TestCase(0, true)]
        [TestCase(1, false)]
        [TestCase(2, true)]
        [TestCase(3, false)]
        [TestCase(4, false)]
        public void TestValidate(int iMessage, bool expectedValid)
        {
            List<string> messages = MessageValidator.GetMessages(this.testData);
            Dictionary<string, string> rules = MessageValidator.GetRules(this.testData);
            bool valid = MessageValidator.Validate(messages[iMessage], rules);
            Assert.AreEqual(expectedValid, valid);
        }

        [Test]
        public void FindAnserDayNineteenPuzzleOne()
        {
            Assert.Warn("Not solved");
        }

        [Test]
        public void FindAnserDayNineteenPuzzleTwo()
        {

            Assert.Warn("Not solved");
        }
    }
}