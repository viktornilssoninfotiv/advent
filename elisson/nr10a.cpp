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
        int nrOf1Diff = 0;
        int nrOf3Diff = 0;
        for (int i = 1; i < inputVec.size(); i++)
        {

            int difference = inputVec[i] - inputVec[i-1];

            if (difference == 1)
            {
                nrOf1Diff++;
            }
            else if (difference == 3)
            {
                nrOf3Diff++;
            }
        }
        nrOf3Diff++;
        cout << "Answer " << nrOf1Diff * nrOf3Diff;


        

        
        myfile.close();
    }
    else
    {
        cout << "Unable to open file";
    }
}