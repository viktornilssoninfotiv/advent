#include <iostream>
#include <vector>
#include <string>
#include <fstream>
#include <math.h>
#include <array>
#include <sstream>

using namespace std;

bool runProgram(vector<string> &inputVec)
{
    int pointer = 0;
    vector<int> visitedInstructions;
    int accumulator = 0;
    while (pointer < inputVec.size())
    {
        string instruction = inputVec[pointer].substr(0, 3);
        visitedInstructions.push_back(pointer);
        if (instruction == "nop")
        {
            pointer++;
        }
        else if (instruction == "acc")
        {
            int value = stoi(inputVec[pointer].substr(4, size(inputVec[pointer])));
            accumulator = accumulator + value;
            pointer++;
        }
        else if (instruction == "jmp")
        {
            int value = stoi(inputVec[pointer].substr(4, size(inputVec[pointer])));
            pointer = pointer + value;
        }

        if (find(visitedInstructions.begin(), visitedInstructions.end(),
                 pointer) != visitedInstructions.end())
        {
            //cout << "Accumulator " << accumulator;
            return false;
        }
    }
    cout << "Accumulator " << accumulator;
    return true;
}

int main()
{
    string line;
    ifstream myfile("input.txt");

    if (myfile.is_open())
    {
        string line;
        vector<string> inputVec;
        while (getline(myfile, line))
        {
            inputVec.push_back(line);
        }

        for (int i = 0; i < inputVec.size(); i++)
        {
            vector<string> inputVecTmp = inputVec;
            string instruction = inputVec[i].substr(0, 3);
            if (instruction == "nop"){
                inputVecTmp[i] = "jmp" + inputVec[i].substr(3, inputVec[i].size());
            }
            else if (instruction == "jmp"){
                inputVecTmp[i] = "nop" + inputVec[i].substr(3, inputVec[i].size());
            }
            bool success = runProgram(inputVecTmp);

            if (success){
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