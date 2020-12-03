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
if (myfile.is_open())
{
    float totalFuel = 0;
    vector<int> myVec; 
    while ( myfile.good() )
    {
        getline (myfile,line);
        myVec.emplace_back(stoi(line));
    }
    for (int i = 0; i<myVec.size()-3;i++){
        for (int j = i+1; j<myVec.size()-2;j++){
            for (int k = j+1; k<myVec.size()-1;k++){
            
            
            if (myVec[i] + myVec[j] + myVec[k]== 2020){
                cout << "Solution found" << endl;
                cout << myVec[i]*myVec[j]*myVec[k];
                
            }
            }
        }
    }

    myfile.close();
}
else 
{  
    cout << "Unable to open file"; 
}

}