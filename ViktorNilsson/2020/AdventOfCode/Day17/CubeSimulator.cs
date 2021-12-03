namespace AdventOfCode
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class CubeSimulator : InputDataHandler
    {
        private const char Active = '#';
        private const char Inactive = '.';

        public static List<int[]> Simulate(char[,] initialPlane, int simulationSteps = 100)
        {
            var activeCubes = GetActiveCubes(initialPlane);
            for (int iSim = 0; iSim < simulationSteps; iSim++)
            {
                var updatedActiveCubes = new List<int[]>();

                // TODO: Only loop the active cubes once and return two lists of adjacent active and adjacent inactive
                // Check the surrounding conditions of each active cube
                foreach (var cube in activeCubes)
                {
                    int noOfSurroundingActive = GetSurroundingActive(cube, activeCubes);

                    // Condition to keep the cube active
                    if (noOfSurroundingActive == 2 || noOfSurroundingActive == 3)
                    {
                        updatedActiveCubes.Add(cube);
                    }
                }

                // Get all adjacent inactive
                // Count surrounding active
                // Update
                var inactiveCubes = GetSurroundingInactive(activeCubes);
                foreach (var cube in inactiveCubes)
                {
                    int noOfSurroundingActive = GetSurroundingActive(cube, activeCubes);

                    // Condition to make the inactive cube go active
                    if (noOfSurroundingActive == 3)
                    {
                        updatedActiveCubes.Add(cube);
                    }
                }

                activeCubes = updatedActiveCubes;
            }

            return activeCubes;
        }

        public static List<int[]> GetActiveCubes(char[,] initialPlane)
        {
            var activeCubes = new List<int[]>();

            for (int x = 0; x < initialPlane.GetLength(0); x++)
            {
                for (int y = 0; y < initialPlane.GetLength(1); y++)
                {
                    var currentCube = initialPlane[x, y];
                    if (currentCube == CubeSimulator.Active)
                    {
                        // Save the coordinates. Z is zer o in the initial plane
                        activeCubes.Add(new int[] { x, y, 0 });
                    }
                }
            }

            return activeCubes;
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

        public static int GetSurroundingActive(int[] cube, List<int[]> activeCubes)
        {
            int noOfActive = 0;

            // Loop over all surrounding coordinates (and evaluate ralative to the supplied cube
            for (int x = -1; x <= 1; x++)
            {
                for (int y = -1; y <= 1; y++)
                {
                    for (int z = -1; z <= 1; z++)
                    {
                        var cubeToEvaluate = new int[]
                        {
                            cube[0] + x,
                            cube[1] + y,
                            cube[2] + z,
                        };

                        // Make sure to not count the supplied cube
                        if (cubeToEvaluate.SequenceEqual(cube))
                        {
                            continue;
                        }

                        // Check if the cube to evaluate is active
                        else if (activeCubes.Any(p => p.SequenceEqual(cubeToEvaluate)))
                        {
                            noOfActive++;
                        }
                    }
                }
            }

            return noOfActive;
        }

        public static List<int[]> GetSurroundingInactive(List<int[]> activeCubes)
        {
            var inactiveCubes = new List<int[]>();

            foreach (var cube in activeCubes)
            {
                // Loop over all surrounding coordinates (and evaluate ralative to the supplied cube
                for (int x = -1; x <= 1; x++)
                {
                    for (int y = -1; y <= 1; y++)
                    {
                        for (int z = -1; z <= 1; z++)
                        {
                            var cubeToEvaluate = new int[]
                            {
                            cube[0] + x,
                            cube[1] + y,
                            cube[2] + z,
                            };

                            // Only add inactive cubes that are not already added
                            bool isActiveCube = activeCubes.Any(p => p.SequenceEqual(cubeToEvaluate));
                            bool alreadyExist = inactiveCubes.Any(p => p.SequenceEqual(cubeToEvaluate));

                            if (!isActiveCube && !alreadyExist)
                            {
                                inactiveCubes.Add(cubeToEvaluate);
                            }
                        }
                    }
                }
            }

            return inactiveCubes;
        }
    }
}