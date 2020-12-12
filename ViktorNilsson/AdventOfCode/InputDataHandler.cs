namespace AdventOfCode
{
    using System;
    using System.IO;

    public class InputDataHandler
    {
        public int colIdxMax;
        public int rowIdxMax;

        public static string[] ReadFileAsArray(string FilePath, string dataSplit = "\r\n")
        {
            string fileContent = File.ReadAllText(FilePath);

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
    }
}