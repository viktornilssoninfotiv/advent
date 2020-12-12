#include <iostream>
#include <vector>
#include <string>
#include <fstream>
#include <math.h>
#include <array>
#include <sstream>
#include <algorithm>


using namespace std;

int checkAdjacent(vector<vector<char>> &inputVec, int adjacent_i, int adjacent_j, const int rowSize, const int &colSize)
{
    if (adjacent_i >= 0 && adjacent_i < rowSize && adjacent_j >= 0 && adjacent_j < colSize)
    {
        if (inputVec[adjacent_i][adjacent_j] == '#') //occupied
            return 1;
        else if (inputVec[adjacent_i][adjacent_j] == 'L') //free
            return 2;
        else //floor
            return 3;
    }
    else //out of bounds
    {
        return 0;
    }
}

int nrOfOccupied(vector<vector<char>> &previous, int i, int j, const int rowSize, const int colSize)
{

    int nrOfAdjacentOccupied = 0;
    const int direction[8][2] = {{0, 1}, {1, 0}, {0, -1}, {-1, 0},
                           {1, 1}, {-1,-1,},{1, -1},{-1, 1}};

    for (int k = 0; k < 8; k++)
    {
        int counter = 1;
        while (true)
        {
            int result = checkAdjacent(previous, i + counter * direction[k][0], j + counter * direction[k][1], rowSize, colSize);
            if (result == 1)
            {
                nrOfAdjacentOccupied++;
                break;
            }
            else if (result == 2 || result == 0)
            {
                break;
            }
            counter++;
        }
    }

    return nrOfAdjacentOccupied;
}

void checkFree(vector<vector<char>> &previous, vector<vector<char>> &inputVec, int i, int j, int &nrOfChanged, const int rowSize, const int colSize)
{

    int nrOfAdjacentOccupied = nrOfOccupied(previous, i, j, rowSize, colSize);

    if (nrOfAdjacentOccupied >= 5)
    {
        inputVec[i][j] = 'L';
        nrOfChanged++;
    }
}

void checkOccupied(vector<vector<char>> &previous, vector<vector<char>> &inputVec, int i, int j, int &nrOfChanged, const int rowSize, const int colSize)
{

    int nrOfAdjacentOccupied = nrOfOccupied(previous, i, j, rowSize, colSize);
    if (nrOfAdjacentOccupied == 0)
    {
        inputVec[i][j] = '#';
        nrOfChanged++;
    }
}

int main()
{
    string line;
    ifstream myfile("input.txt");

    if (myfile.is_open())
    {
        string line;
        vector<vector<char>> inputVec;

        while (getline(myfile, line))
        {

            vector<char> temp;
            for (int i = 0; i < line.size(); i++)
            {
                temp.push_back(line[i]);
            }
            inputVec.push_back(temp);
        }
        myfile.close();
        const int rowSize = inputVec.size();
        const int colSize = inputVec[0].size();

        int nrOfChanged = 1;
        int iteration = 0;
        while (nrOfChanged > 0)
        {
            iteration++;
            cout << "iteration " << iteration << endl;
            vector<vector<char>> previous = inputVec;
            nrOfChanged = 0;
            for (int i = 0; i < rowSize; i++)
            {
                for (int j = 0; j < colSize; j++)
                {
                    if (inputVec[i][j] == '.')
                    {
                        //cout << inputVec[i][j] << " ";
                        continue; // floor always the same
                    }
                    else if (inputVec[i][j] == '#')
                    { //seat occupied
                        checkFree(previous, inputVec, i, j, nrOfChanged, rowSize, colSize);
                    }
                    else
                    { //seat free
                        checkOccupied(previous, inputVec, i, j, nrOfChanged, rowSize, colSize);
                    }
                    //cout << inputVec[i][j] << " ";
                }
                //cout << endl;
            }
        }
        int nrOccupied = 0;
        for (int i = 0; i < rowSize; i++)
        {
            for (int j = 0; j < colSize; j++)
            {
                if (inputVec[i][j] == '#')
                {
                    nrOccupied++;
                }
            }
        }
        cout << "Nr occupued" << nrOccupied;
    }
    else
    {
        cout << "Unable to open file";
    }
}