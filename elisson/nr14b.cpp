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
    map<uint64_t, uint64_t> memory; 


    if (myfile.is_open())
    {
        
        string line;
        
        string mask;
        uint64_t And_mask = 0;
        uint64_t Or_mask = 0;
        vector<uint64_t> floating_and_mask;
        vector<uint64_t> floating_or_mask;

        while(getline(myfile, line)){
            
            if (line.substr(0,3) =="mas"){
                And_mask = 0;
                Or_mask = 0;
                mask = line.substr(7, line.size());
                string OrMask = mask;
                string AndMask = mask;
                replace( OrMask.begin(), OrMask.end(), 'X', '0'); 
                replace( AndMask.begin(), AndMask.end(), 'X', '1'); 
                
                for (int i = 0; i<mask.size(); i++){
                    And_mask = And_mask + ((uint64_t)(AndMask[AndMask.size()-1-i])-48)*pow(2, i);
                    Or_mask = Or_mask + ((uint64_t)(OrMask[OrMask.size()-1-i])-48)*pow(2, i);
                }

                // Generate permutations of floating mask
                vector<int> floting_index;
                
                for (int i = 0; i<mask.size();i++){   
                    if (mask[i] == 'X'){
                        floting_index.push_back(i);
                    }
                }
                if (floting_index.size()>0){
                vector<uint64_t> permutation;
                uint64_t value = 0;
                for (int i = 0; i<floting_index.size(); i++){
                    value = value + pow(2, i);
                }
                int i=0;
                while (i<=value){
                    permutation.push_back(i);
                    i++;
                }
                floating_and_mask.clear();
                floating_or_mask.clear();
                for (int i = 0; i<permutation.size();i++){
                    string temp_or_mask = "000000000000000000000000000000000000";
                    string temp_and_mask ="111111111111111111111111111111111111";;

                    int nrOfBits = floting_index.size();
                    for (int j = 0; j<nrOfBits;j++){
                        if (permutation[i] & ( 1 << j )){
                            temp_and_mask[floting_index[j]] = '0';
                            temp_or_mask[floting_index[j]] = '0';

                        }
                        else{
                            temp_and_mask[floting_index[j]] = '1';
                            temp_or_mask[floting_index[j]] = '1';
                        }
                    }
                    uint64_t temp_int_mask_and = 0;
                    uint64_t temp_int_mask_or = 0;
                    for (int k = 0; k<mask.size(); k++){
                        temp_int_mask_and = temp_int_mask_and + ((uint64_t)(temp_and_mask[temp_and_mask.size()-1-k])-48)*pow(2, k);
                        temp_int_mask_or = temp_int_mask_or + ((uint64_t)(temp_or_mask[temp_or_mask.size()-1-k])-48)*pow(2, k);
                    }
                    floating_and_mask.push_back(temp_int_mask_and);
                    floating_or_mask.push_back(temp_int_mask_or);
                    
                }
                }
                else{
                    floating_and_mask.clear();
                    floating_or_mask.clear();
                    floating_and_mask.push_back(ULLONG_MAX);
                    floating_or_mask.push_back(0);
                }

            }
            else{
                regex r("(\\d+)+"); 
                smatch match;
                regex_search(line, match, r);
                int delimiter1 = line.find_first_of('[');
                int delimiter2 = line.find_first_of(']');
                uint64_t raw_memoryPosition = stoull(line.substr(delimiter1+1, delimiter2-1));
                //regex rr("(?<= )d+");
                //regex_search(line, match, rr);
                int delimiter = line.find_first_of(' =');
                
                uint64_t value = stoull(line.substr(delimiter+2, line.size()));
                 
                for (int i = 0; i<floating_and_mask.size();i++){
                    uint64_t memoryPosition = raw_memoryPosition;
                    memoryPosition = (memoryPosition | Or_mask);
                    memoryPosition = (memoryPosition | floating_or_mask[i]) & floating_and_mask[i];
                    memory[memoryPosition]=value;
                }
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