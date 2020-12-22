namespace AdventOfCode
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class CubeSimulator : InputDataHandler
    {
        private const char Free = 'L';
        private const char Active = '#';
        private const char Inactive = '.';

        public static (int occupied, int free) CountSeats(char[,] seatMap)
        {
            string mapString = string.Empty;
            foreach (var row in seatMap)
            {
                mapString += row.ToString();
            }

            int occupied = mapString.Count(f => f == Active);
            int free = mapString.Count(f => f == Free);

            return (occupied, free);
        }

        public static (int occupied, int free) Simulate(char[,] seatMap, int simulationSteps = 100)
        {
            var mapToSimulate = (char[,])seatMap.Clone();
            char[,] simulatedMap;
            var simSeats = CountSeats(seatMap);
            for (int iSim = 0; iSim < simulationSteps; iSim++)
            {
                simSeats = CountSeats(mapToSimulate);
                simulatedMap = SimulateOneStep(mapToSimulate);

                // Continue simulation as long as seats change
                Console.WriteLine("Simseats: " + simSeats);
                if (CountSeats(simulatedMap) != simSeats)
                {
                    simSeats = CountSeats(simulatedMap);
                    mapToSimulate = simulatedMap;
                }
                else
                {
                    break;
                }
            }

            return simSeats;
        }

        public static char[,,] GetInitialState(char[,] initialPlane)
        {
            int size = 3;
            var initialState = new char[size, size, size];
            for (int x = 0; x < size; x++)
            {
                for (int y = 0; y < size; y++)
                {
                    for (int z = 0; z < size; z++)
                    {
                        if (z == 0)
                        {
                            initialState[x, y, z] = initialPlane[x, y];
                        }
                        else
                        {
                            initialState[x, y, z] = CubeSimulator.Inactive;
                        }
                    }
                }
            }

            return initialState;
        }

        private static char[,] SimulateOneStep(char[,] seatMap)
        {
            var simulatedMap = (char[,])seatMap.Clone();

            for (int row = 0; row < seatMap.GetLength(0); row++)
            {
                for (int col = 0; col < seatMap.GetLength(1); col++)
                {
                    // Check for floor
                    if (seatMap[row, col] == Inactive)
                    {
                        continue;
                    }

                    // Obtain adjacent seats
                    var adjSeats = AdjacentSeats(seatMap, row, col);

                    // Free seat becoming occupied
                    if (adjSeats.All(seat => (seat == Free || seat == Inactive)))
                    {
                        simulatedMap[row, col] = Active;
                        continue;
                    }

                    // Occupied seat becoming free
                    bool seatIsOccupied = seatMap[row, col] == Active;
                    int adjOccupiedSeats = adjSeats.Count(seat => seat == Active);

                    // adjOccupiedSeats must be larger than 4 since the current seat is included
                    if (seatIsOccupied && (adjOccupiedSeats > 4))
                    {
                        simulatedMap[row, col] = Free;
                    }
                }
            }

            return simulatedMap;
        }

        public static List<char> AdjacentSeats(char[,] seatMap, int row, int col)
        {
            // TODO: Handle cases at the edges where current solution indexes outside the map
            var adjSeats = new List<char>();
            for (int i = -1; i <= 1; i++)
            {
                for (int j = -1; j <= 1; j++)
                {
                    int iRow = row + i;
                    int iCol = col + j;

                    // Only check an adjacent seat if inside the map bounds
                    if (iRow >= 0 && iRow < seatMap.GetLength(0) && iCol >= 0 && iCol < seatMap.GetLength(1))
                    {
                        adjSeats.Add(seatMap[iRow, iCol]);
                    }
                }
            }

            return adjSeats;
        }
    }
}