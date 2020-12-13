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
        vector<vector<char>> inputVec;

        int x = 0;
        int y = 0;

        int x_way = 10;
        int y_way = 1;

        int dir=0; //{East, North, West, South}
        int steps[4][2] ={{1, 0}, {0, 1}, {-1, 0}, {0, -1}};
        while (getline(myfile, line))
        {
            char action = line[0];
            int value = stoi(line.substr(1, line.size()));
            if (action == 'R'){

                int nrOfRotations = value/90;
                for (int i = 1;i<=nrOfRotations;i++){
                    int x_way_prev = x_way;
                    int y_way_prev = y_way;
                    x_way =  y_way_prev;
                    y_way = -x_way_prev;
                }
            }
            else if (action == 'L'){

                int nrOfRotations = value/90;
                for (int i = 1;i<=nrOfRotations;i++){
                    int x_way_prev = x_way;
                    int y_way_prev = y_way;
                    x_way =  -y_way_prev;
                    y_way = x_way_prev;
                }        
            }
            else if (action == 'F'){
                x = x + x_way*value;
                y = y + y_way*value;
            }
            
            else{
                int move;
                if (action == 'E')
                    move = 0;
                else if (action == 'N')
                    move = 1;
                else if (action == 'W')
                    move = 2;
                else 
                    move = 3;
                x_way = x_way + value*steps[move][0];
                y_way = y_way + value*steps[move][1];
            }
        }
        cout << "Manhattan" << abs(x) + abs(y);

    }
    else
    {
        cout << "Unable to open file";
    }
}