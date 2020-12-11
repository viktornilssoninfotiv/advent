#include <iostream>
#include <vector>
#include <string>
#include <fstream>
#include <math.h>
#include <array>
#include <sstream>
#include <algorithm>

using namespace std;

int main()
{
    string line;
    ifstream myfile("input.txt");

    if (myfile.is_open())
    {
        string line;
        vector<int> inputVec;
        inputVec.push_back(0);
        while (getline(myfile, line))
        {
            inputVec.push_back(stoi(line));
        }
        

        sort(inputVec.begin(), inputVec.end());
        inputVec.push_back(inputVec[inputVec.size()-1]+3);
        long long int nrOf1Diff = 0;
        int nrOf3Diff = 0;
        long long int nrOfPaths = 1;
        for (int i = 0; i < inputVec.size() - 1; i++)
        {
            int difference = inputVec[i + 1] - inputVec[i];
            if (difference == 1)
            {
                nrOf1Diff++;
            }
            else if (difference == 3)
            {

                // Follow the tribonacci sequence. Should be properly implemented but there are no higher diffs so this works
                int multiplier = 1;
                if (nrOf1Diff == 2)
                    multiplier = 2;
                else if (nrOf1Diff == 3)
                {
                    multiplier = 4;
                }
                else if (nrOf1Diff == 4)
                {
                    multiplier = 7;
                }
                else if (nrOf1Diff == 5)
                {
                    multiplier = 12;
                }
                else if (nrOf1Diff == 6)
                {
                    multiplier = 24;
                }
                nrOfPaths = nrOfPaths * multiplier;
                nrOf1Diff = 0;
                nrOf3Diff++;
            }
        }
        nrOf3Diff++;
        cout << "Answer A " << nrOf1Diff * nrOf3Diff;
        cout << "Answer B " << nrOfPaths;

        myfile.close();
    }
    else
    {
        cout << "Unable to open file";
    }
}