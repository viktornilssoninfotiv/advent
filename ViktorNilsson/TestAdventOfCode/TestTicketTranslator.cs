namespace AdventOfCode
{
    using System;
    using System.Collections.Generic;
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