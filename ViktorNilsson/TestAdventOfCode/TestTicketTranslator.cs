namespace AdventOfCode
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using NUnit.Framework;

    public class TestTicketTranslator
    {
        private const string DayPath = @"../../../../AdventOfCode/Day16/";
        private const string FilePathInputData = DayPath + "InputData.txt";
        private const string FilePathTestData = DayPath + "TestData.txt";
        private TicketTranslator testData;
        private TicketTranslator inputData;

        [SetUp]
        public void Setup()
        {
            this.testData = new TicketTranslator(FilePathTestData);
            this.inputData = new TicketTranslator(FilePathInputData);
        }

        [Test]
        public void TestGetTicket()
        {
            List<int> ticketFields = this.testData.GetTicket();
            Assert.AreEqual(3, ticketFields.Count);
        }

        [Test]
        public void TestGetNearbyTicketsCount()
        {
            List<List<int>> nearbyTickets = this.testData.GetNearbyTickets();
            Assert.AreEqual(4, nearbyTickets.Count);
        }

        [Test]
        public void TestGetNearbyTicketsFields()
        {
            var expectedFields = new List<int> { 7, 3, 47 };
            List<List<int>> nearbyTickets = this.testData.GetNearbyTickets();
            Assert.AreEqual(3, nearbyTickets[0].Count);
            Assert.AreEqual(expectedFields, nearbyTickets[0]);
        }

        [Test]
        public void TestGetFieldRules()
        {
            Dictionary<string, string[]> fieldRules = this.testData.GetFieldRules();
            Assert.Contains("class", fieldRules.Keys);
            Assert.AreEqual(3, fieldRules.Count);
        }

        [Test]
        public void TestGetFieldRulesContent()
        {
            Dictionary<string, string[]> fieldRules = this.testData.GetFieldRules();
            Assert.Contains("1-3", fieldRules["class"]);
            Assert.Contains("5-7", fieldRules["class"]);
            Assert.AreEqual(2, fieldRules["class"].Length);
        }

        [Test]
        public void TestGetTicketScanningErrorRate()
        {
            int errorRate = this.testData.GetTicketScanningErrorRate();
            Assert.AreEqual(71, errorRate);
        }

        [TestCase(0, new int[] { })]
        [TestCase(1, new int[] { 4 })]
        [TestCase(2, new int[] { 55 })]
        [TestCase(3, new int[] { 12 })]
        public void TestValidateTicketFields(int iTicket, int[] expectedInvalidFields)
        {
            var nearbyTickets = this.testData.GetNearbyTickets();
            Dictionary<string, string[]> fieldRules = this.testData.GetFieldRules();
            List<int> invalidFields = TicketTranslator.ValidateTicketFields(fieldRules, nearbyTickets[iTicket]);
            Assert.AreEqual(expectedInvalidFields.ToList(), invalidFields);
        }

        [Test]
        public void FindAnserDaySixteenPuzzleOne()
        {
            Assert.Warn("Not solved");
        }

        [Test]
        public void FindAnserDaySixteenPuzzleTwo()
        {

            Assert.Warn("Not solved");
        }
    }
}