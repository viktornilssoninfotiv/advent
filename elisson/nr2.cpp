#include <iostream>
#include <vector>
#include <string>
#include <fstream>
#include <math.h>
#include <cstddef> 

using namespace std;

int main()
{
string line;
ifstream myfile ("input.txt");
if (myfile.is_open())
{
    float totalFuel = 0;
    vector<int> myVec; 
    int nrOfOkPasswords = 0;
    while ( myfile.good() )
    {
        getline (myfile,line);
        size_t found = line.find_first_of("-");
        size_t found2 = line.find_first_of(" ");
        size_t found3 = line.find_first_of(":");
        int lowerBound = stoi(line.substr(0, found));
        int upperBound = stoi(line.substr(found+1, found2));
        char character = line[found3-1];
        string password = line.substr(found3 + 2, line.size());

        int nrOfCharsMatch = 0;
        bool LowerValid = false;
        bool UpperValid = false;
        if (lowerBound-1 < password.size() && password[lowerBound-1] == character){
            LowerValid = true;
        }
        if (upperBound-1 < password.size() && password[upperBound-1] == character){
            UpperValid = true;
        }

        if (UpperValid != LowerValid){
            nrOfOkPasswords++;
        }
    }
    cout << "Nr passwords" << nrOfOkPasswords;

    myfile.close();
}
else 
{  
    cout << "Unable to open file"; 
}

}