namespace AdventOfCode
{
    using System;
    using System.IO;

    public class InputDataHandler
    {
        public int ColIdxMax;
        public int RowIdxMax;

        public static string[] ReadFileAsArray(string filePath, string dataSplit = "\r\n")
        {
            string fileContent = File.ReadAllText(filePath);

            // string[] fileRows = Regex.Split(fileContent, @"\s+");
            string[] fileRows = fileContent.Split(new string[] { dataSplit }, StringSplitOptions.None);
            return fileRows;
        }

        public char[,] GetInputDataMap(string filePath)
        {
            // Specify folder since it can be run from elsewhere, e.g. unittest
            string[] stringMap = InputDataHandler.ReadFileAsArray(filePath);
            int rows = stringMap.Length;
            int columns = stringMap[0].Length;
            char[,] map = new char[rows, columns];

            this.ColIdxMax = columns;
            this.RowIdxMax = rows;

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