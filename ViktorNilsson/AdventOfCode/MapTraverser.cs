namespace AdventOfCode
{
    public class MapTraverser : InputDataHandler
    {
        private const char TreeChar = '#';

        public MapTraverser()
        {
        }

        public int TreeCounter(char[,] map, int right, int down)
        {
            int noOfTrees = 0;
            int col = 0;
            int row = 0;

            // Traverse until the bottom of the map
            while (row < this.RowIdxMax)
            {
                if (map[row, col] == MapTraverser.TreeChar)
                {
                    noOfTrees++;
                }

                row += down;
                col += right;

                // Map shall be repeated to the right
                if (col >= this.ColIdxMax)
                {
                    col -= this.ColIdxMax;
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