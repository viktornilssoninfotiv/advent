#include <iostream>
#include <vector>
#include <string>
#include <fstream>
#include <math.h>
#include <array>
#include <sstream>
#include <algorithm>
#include <chrono>
#include <map>
#include <unordered_map>
#include <regex>
#include <numeric>
#include <set>
#include <iterator>

using namespace std;
using Triple = array<int, 3>;

int main()
{
    auto start = chrono::high_resolution_clock::now();
    ifstream myfile("input.txt");
    string line;
    map<Triple, bool> grid; //x y z

    int j = 0;
    while (getline(myfile, line))
    {
        for (int i = 0; i < line.size(); i++)
        {
            Triple position1 = {i, j, 0};
            grid[position1] = line[i] == '#';
        }
        j++;
    }
    array<Triple, 26> directions;
    int l = 0;
    for (int i = -1; i <= 1; i++)
    {
        for (int j = -1; j <= 1; j++)
        {
            for (int k = -1; k <= 1; k++)
            {
                if (!(i == 0 && j == 0 && k == 0))
                {
                    directions[l] = {i, j, k};
                    l++;
                }
            }
        }
    }

    map<Triple, bool> gridNext = grid;

    for (auto const &currentPoint : grid) //Pad the grid  with inactive nodes
    {
        for (int iNeighbors = 0; iNeighbors < size(directions); iNeighbors++)
        {
            int x1 = currentPoint.first[0] + directions[iNeighbors][0];
            int y1 = currentPoint.first[1] + directions[iNeighbors][1];
            int z1 = currentPoint.first[2] + directions[iNeighbors][2];
            if (grid.find({x1, y1, z1}) != grid.end())
            { // check if point exists
            }
            else
            {
                gridNext[{x1, y1, z1}] = false;
            }
        }
    }

    for (int iteration = 0; iteration < 6; iteration++)
    {
        grid = gridNext;
        for (auto const &currentPoint : grid)
        {
            int nrOfActiveNeighbors = 0;
            for (int iNeighbors = 0; iNeighbors < size(directions); iNeighbors++)
            {
                int x1 = currentPoint.first[0] + directions[iNeighbors][0];
                int y1 = currentPoint.first[1] + directions[iNeighbors][1];
                int z1 = currentPoint.first[2] + directions[iNeighbors][2];
                if (grid.find({x1, y1, z1}) != grid.end())
                { // check if point exists
                    if (grid[{x1, y1, z1}])
                        nrOfActiveNeighbors++;
                }
                else
                {
                    gridNext[{x1, y1, z1}] = false;
                }
            }
            if (currentPoint.second && !(nrOfActiveNeighbors == 2 || nrOfActiveNeighbors == 3))
            {
                gridNext[currentPoint.first] = false;
            }
            else if ((!currentPoint.second) && nrOfActiveNeighbors == 3)
            {
                gridNext[currentPoint.first] = true;
            }
        }
    }
    int nrOfActive = 0;
    for (auto const &currentPoint : gridNext)
    {
        if (currentPoint.second)
            nrOfActive++;
    }

    auto stop = chrono::high_resolution_clock::now();
    auto duration = chrono::duration_cast<chrono::milliseconds>(stop - start);
    cout << "Time: " << duration.count() << endl;
    cout << "Result: " << nrOfActive << endl;
}