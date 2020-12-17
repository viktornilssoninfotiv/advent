#include <iostream>
#include <vector>
#include <string>
#include <fstream>
#include <math.h>
#include <array>
#include <sstream>
#include <algorithm>
#include <chrono>
#include <map> 
#include <unordered_map> 
#include <regex> 
#include <numeric>

using namespace std;

int main()
{
    auto start = chrono::high_resolution_clock::now();
    string line;
    ifstream myfile("input.txt");
    unordered_map<int, int> memory; 

    int numbers[]= {1,0,16,5,17,4}; //[spoken number, lastTimeSpoken]

    for (int i = 0; i<size(numbers); i++){
        memory[numbers[i]] = i+1;
    }
    int nextNumber = 0;
    int lastTimeSpoken;
    bool spokenBefore = find(begin(numbers),end(numbers), nextNumber)!= end(numbers);

    for (int i=size(numbers)+1; i<30000000;i++){
    
        if (spokenBefore){
                    
            lastTimeSpoken = memory[nextNumber];
            memory[nextNumber] = i;
            nextNumber = i-lastTimeSpoken;  
            
            if (memory.count(nextNumber) >0)
                spokenBefore = true;
            else
                spokenBefore = false;
        }
        else{
            memory[nextNumber] = i;
            nextNumber = 0;
            spokenBefore = true;
        }        
    }

        auto stop = chrono::high_resolution_clock::now();
        auto duration = chrono::duration_cast<chrono::milliseconds>(stop - start);
        cout << "Time: " << duration.count() << endl;
        cout << "Result: " << nextNumber << endl;
}