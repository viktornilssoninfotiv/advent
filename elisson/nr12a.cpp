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
    
        int dir=0; //{East, North, West, South}
        int steps[4][2] ={{1, 0}, {0, 1}, {-1, 0}, {0, -1}};
        while (getline(myfile, line))
        {
            char action = line[0];
            int value = stoi(line.substr(1, line.size()));
            if (action == 'R'){
                dir = dir - value/90;
                if (dir < 0){
                    dir = dir + 4;;
                }
            }
            else if (action == 'L'){
                dir = dir + value/90;
                if (dir > 3){
                    dir = dir - 4;;
                }               
            }
            else if (action == 'F'){
                x = x + value*steps[dir][0];
                y = y + value*steps[dir][1];
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
                x = x + value*steps[move][0];
                y = y + value*steps[move][1];
            }
        }
        cout << "Manhattan" << abs(x) + abs(y);

    }
    else
    {
        cout << "Unable to open file";
    }
}