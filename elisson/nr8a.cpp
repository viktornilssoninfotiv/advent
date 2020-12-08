#include <iostream>
#include <vector>
#include <string>
#include <fstream>
#include <math.h>
#include <array>
#include <sstream>

using namespace std;

int main()
{
    string line;
    ifstream myfile("input.txt");

    if (myfile.is_open())
    {   
        string line;
        vector<string> inputVec;
        while (getline(myfile, line)){
            inputVec.push_back(line);
        }
        int pointer = 0;
        vector<int> visitedInstructions;
        int accumulator = 0;

        
        while(true){
            string instruction = inputVec[pointer].substr(0,3);
            visitedInstructions.push_back(pointer);
            if (instruction == "nop"){
                pointer++;
            }
            else if (instruction == "acc"){
                int value = stoi(inputVec[pointer].substr(4, size(inputVec[pointer])));
                accumulator = accumulator + value;
                pointer++;
            }
            else if (instruction == "jmp"){
                int value = stoi(inputVec[pointer].substr(4, size(inputVec[pointer])));
                pointer = pointer + value;

            }
            
            if (find(visitedInstructions.begin(), visitedInstructions.end(), 
                 pointer) != visitedInstructions.end()){
                     cout << "Accumulator " << accumulator;
                     break;
            }
        }

        myfile.close();
    }
    else
    {
        cout << "Unable to open file";
    }
}