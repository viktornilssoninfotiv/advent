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
#include <regex> 
#include <numeric>

using namespace std;

int main()
{
    auto start = chrono::high_resolution_clock::now();
    string line;
    ifstream myfile("input.txt");
    map<int, uint64_t> memory; 


    if (myfile.is_open())
    {
        
        string line;
        
        string mask;
        uint64_t mask_value = 0;
        uint64_t mask_valueRaw = 0;
        while(getline(myfile, line)){
        
            if (line.substr(0,3) =="mas"){
                mask_value = 0;
                mask_valueRaw = 0;
                mask = line.substr(7, line.size());
                string rawMask = mask;
                replace( rawMask.begin(), rawMask.end(), 'X', '0'); 
                replace( mask.begin(), mask.end(), 'X', '1'); 
                
                for (int i = 0; i<mask.size(); i++){
                    mask_value = mask_value + ((uint64_t)(mask[mask.size()-1-i])-48)*pow(2, i);
                    mask_valueRaw = mask_valueRaw + ((uint64_t)(rawMask[rawMask.size()-1-i])-48)*pow(2, i);
                }
            }
            else{
                regex r("(\\d+)+"); 
                smatch match;
                regex_search(line, match, r);
                int delimiter1 = line.find_first_of('[');
                int delimiter2 = line.find_first_of(']');
                uint64_t memoryPosition = stoull(line.substr(delimiter1+1, delimiter2-1));
                //regex rr("(?<= )d+");
                //regex_search(line, match, rr);
                int delimiter = line.find_first_of(' =');
                
                uint64_t value = stoull(line.substr(delimiter+2, line.size()));
                memory[memoryPosition]=(value | mask_valueRaw) & mask_value;

            }
                
        }
        uint64_t result = 0;
        for (auto const& x : memory)
        {
                  result = result + x.second;// string's value 

        }

        
        auto stop = chrono::high_resolution_clock::now();
        auto duration = chrono::duration_cast<chrono::milliseconds>(stop - start);
        cout << "Time: " << duration.count() << endl;
        cout << "Result: " << result << endl;
    }
    else
    {
        cout << "Unable to open file";
    }
}