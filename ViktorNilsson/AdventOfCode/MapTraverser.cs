using System;

namespace TestAdventOfCode
{
    public class MapTraverser : InputDataHandler
    {
        private const char TreeChar = '#';
        private int colIdxMax;
        private int rowIdxMax;

        public MapTraverser()
        {
        }

        public char[,] GetInputData(string filePath)
        {
            // Specify folder since it can be run from elsewhere, e.g. unittest
            string[] stringMap = InputDataHandler.ReadFileAsArray(filePath);
            int rows = stringMap.Length;
            int columns = stringMap[0].Length;
            char[,] map = new char[rows, columns];

            this.colIdxMax = columns;
            this.rowIdxMax = rows;

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < columns; col++)
                {
                    map[row, col] = stringMap[row][col];
                }
            }

            return map;
        }

        public int TreeCounter(char[,] map, int right, int down)
        {
            int noOfTrees = 0;
            int col = 0;
            int row = 0;

            // Traverse until the bottom of the map
            while (row < this.rowIdxMax)
            {
                if (map[row, col] == MapTraverser.TreeChar)
                {
                    noOfTrees++;
                }

                row += down;
                col += right;

                // Map shall be repeated to the right
                if (col >= this.colIdxMax)
                {
                    col -= this.colIdxMax;
                }
            }

            return noOfTrees;
        }

        public int TreeCounterMultiSlope(char[,] map, int[,] slopes)
        {
            int multipliedTrees = 1;
            for (int slopeIdx = 0; slopeIdx < slopes.GetLength(0); slopeIdx++)
            {
                int right = slopes[slopeIdx, 0];
                int down = slopes[slopeIdx, 1];
                multipliedTrees *= this.TreeCounter(map, right, down);
            }

            return multipliedTrees;
        }
    }
}