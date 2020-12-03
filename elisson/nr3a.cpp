#include <iostream>
#include <vector>
#include <string>
#include <fstream>
#include <math.h>

using namespace std;

int main()
{
string line;
ifstream myfile ("input.txt");
int lineIndex=3;
if (myfile.is_open())
{
    int nrThrees = 0;
    getline (myfile,line);

    while ( myfile.good() )
    {
        getline (myfile,line);

        
            if (line[lineIndex]=='#'){
                nrThrees++;
            }
            lineIndex=lineIndex+3;
            if (lineIndex>=size(line)){
                lineIndex = lineIndex - size(line);
            } 
        
    }
    cout << "Nr Threes " << nrThrees;

    myfile.close();
}
else 
{  
    cout << "Unable to open file"; 
}

}