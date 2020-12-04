using System;

namespace TestAdventOfCode
{
    public class MapTraverser : InputDataHandler
    {
        public MapTraverser()
        {
        }

        public static char[,] GetInputData()
        {
            // Specify folder since it can be run from elsewhere, e.g. unittest
            string[] stringMap = InputDataHandler.ReadFileAsArray("../../../../AdventOfCode/DayThreeInput.txt");
            int rows = stringMap.Length;
            int columns = stringMap[0].Length;
            char[,] map = new char[rows, columns];

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < columns; col++)
                {
                    map[row, col] = stringMap[row][col];
                }
            }

            return map;
        }
    }
}