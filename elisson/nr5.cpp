#include <iostream>
#include <vector>
#include <string>
#include <fstream>
#include <math.h>
#include <array>
#include <sstream>
#include <algorithm> 
#include<iterator>

using namespace std;

int main()
{
    string line;
    ifstream myfile("input.txt");
    int maxSeatID = 0;
    vector<int> seatIds;
    if (myfile.is_open())
    {

        while (myfile.good())
        {

            getline(myfile, line);
            float lowerBound = 0;
            float upperBound = 127;
            for (int i = 0; i<7; i++){
                if (line[i]=='B'){
                    lowerBound = lowerBound + ceil((upperBound - lowerBound)/2);
                }
                else {
                    upperBound = upperBound - ceil((upperBound - lowerBound)/2);
                }
            }
            int row = lowerBound;

            //cout << "Row " << row << endl;
            lowerBound = 0;
            upperBound = 7;

            for (int i = 7; i <10; i++){
                if (line[i]=='R'){
                    lowerBound = lowerBound + ceil((upperBound - lowerBound)/2);
                }
                else {
                    upperBound = upperBound - ceil((upperBound - lowerBound)/2);
                }
            }
            int column = lowerBound;
            //cout << "column " << column << endl;
            seatIds.emplace_back(row*8 + column);
            maxSeatID = max(maxSeatID, row*8 + column);
            
        }
        sort(seatIds.begin(), seatIds.end());

        int mySeatID = 0;
        for (int i = 8; i < size(seatIds)-1; i++){
                if (abs(seatIds[i] - seatIds[i+1])== 2){
                    mySeatID = (seatIds[i] + seatIds[i+1])/2;
                    cout << "My seat "<< mySeatID<<endl;
                }
            
        }
        myfile.close();
        cout << "Max seat id " << maxSeatID;

    }
    else
    {
        cout << "Unable to open file";
    }
}