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
        getline(myfile, line);
        int starttime = stoi(line);
        int minWaitTime = INT_MAX;
        int bestBus = 0;
        while(getline(myfile, line, ',')){
            if (line[0] != 'x'){
                int busId = stoi(line);
                int waitTime = busId - starttime%busId;
                if (waitTime < minWaitTime){
                    minWaitTime = min(minWaitTime, waitTime);
                    bestBus = busId;
                }
            }      
        }
        cout << bestBus*minWaitTime;
    }
    else
    {
        cout << "Unable to open file";
    }
}