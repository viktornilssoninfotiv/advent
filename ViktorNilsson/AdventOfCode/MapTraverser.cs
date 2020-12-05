using System;

namespace TestAdventOfCode
{
    public class MapTraverser : InputDataHandler
    {
        private const char TreeChar = '#';
        private int colMax;
        private int rowMax;

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

            this.colMax = columns;
            this.rowMax = rows;

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < columns; col++)
                {
                    map[row, col] = stringMap[row][col];
                }
            }

            return map;
        }

        public int TreeCounter(char[,] map, int down, int right)
        {
            int noOfTrees = 0;
            int col = 0;
            int row = 0;

            // Traverse until the bottom of the map
            while (row < this.rowMax)
            {
                if (map[row, col] == MapTraverser.TreeChar)
                {
                    noOfTrees++;
                }

                row += down;
                col += right;

                // Map shall be repeated to the right
                if (col > this.colMax)
                {
                    col -= this.colMax;
                }
            }

            return noOfTrees;
        }
    }
}