using NUnit.Framework;

namespace TestAdventOfCode
{
    public class TestMapTraverser
    {

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestGetInputDataSize()
        {
            char[,] map = MapTraverser.GetInputData();
            Assert.AreEqual(323, map.GetLength(0));
            Assert.AreEqual(31, map.GetLength(1));
            Assert.AreEqual('.', map[0, 0]);
        }
    }
}