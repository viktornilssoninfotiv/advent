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
        int preEmbleLength = 25;
        vector<long long int> inputVec;
        vector<long long int> fullVec;
        for (int i = 0; i < preEmbleLength; i++)
        {
            getline(myfile, line);
            inputVec.push_back(stoi(line));
            fullVec.push_back(stoi(line));
        }

        while (getline(myfile, line))
        {
            bool matchFound = false;
            long long int newNumber = stoi(line);
            for (int j = 0; j < preEmbleLength; j++)
            {
                int num = inputVec.at(j);
                for (int k = j + 1; k < preEmbleLength; k++)
                {
                    if (num + inputVec.at(k) == newNumber)
                    {
                        matchFound = true;
                    }
                }
            }
            if (!matchFound)
            {
                cout << "No match " << newNumber << endl;

                
                for (int i = 0; i<fullVec.size(); i++){
                    long long int sum = 0;
                    for (int j = i; j<fullVec.size(); j++){
                        sum = sum + fullVec.at(j);
                        if (sum == newNumber){
                            long long minNum = *min_element(fullVec.begin()+i, fullVec.begin()+j);
                            long long maxNum = *max_element(fullVec.begin()+i, fullVec.begin()+j);
                            cout << "Max + min " << minNum + maxNum<<endl;
                            return 0;
                        }
                        else if (sum > newNumber){
                            break;
                        }
                    }
                }

                return 0;
            }
            inputVec.erase(inputVec.begin());
            inputVec.push_back(newNumber);
            fullVec.push_back(newNumber);
        }

        myfile.close();
    }
    else
    {
        cout << "Unable to open file";
    }
}