#include <iostream>
#include <vector>
#include <string>
#include <fstream>
#include <math.h>
#include <array>
#include <sstream>
#include <algorithm>
#include <chrono>
using namespace std;

int main()
{
    string line;
    ifstream myfile("input.txt");

    if (myfile.is_open())
    {
        string line;
        //getline(myfile, line);
        vector<long long int> busIDs;
        vector<long long int> multiplier;
        vector<long long int> offset;
        
        int i = -1;
        while(getline(myfile, line, ',')){
               
            if (line[0] != 'x'){
                busIDs.push_back(stoi(line));
                multiplier.push_back(1);
                offset.push_back(1);
                i++;

            }
            else
                offset[i]++;
                
        }

        int pointer = 0;
        int j = 0;

        auto start = chrono::high_resolution_clock::now();
        while (true){
            
            

            long long int currentTimeN1 = busIDs[pointer]*multiplier[pointer];
            long long int temp = multiplier[pointer+1];
            
            long long int maxId = 0;
        // for (int i = 0; i<busIDs.size();i++){
        //     maxId=max(maxId, busIDs[i]);
        // }
            
            // Start time must always be larger than the largest element times its multiplier

            multiplier[pointer+1] = (currentTimeN1)/busIDs[pointer+1]+1;   
            if (temp == multiplier[pointer+1])
                    multiplier[pointer+1]++;
            long long int currentTimeN2 = busIDs[pointer+1]*multiplier[pointer+1];



            //cout << currentTimeN1 <<endl;
            //Last element matches precvious means that we are done
            if (pointer == busIDs.size()-1){
                break;
            }
            // If current matches the next + offset. Continue to next
            else if (currentTimeN1 + offset[pointer]== currentTimeN2){
                pointer++;
                //cout << currentTimeN2<< endl;
            }
            // increase multiplier of current if current time +offset is less than next<
            else if (pointer == 0 && currentTimeN1+offset[pointer] < currentTimeN2){

                    //currentTimeN1 = busIDs[pointer]*multiplier[pointer];
                    multiplier[0]++;
            }
            // if pointer is larger than zero and next element is larger than current it
            // means that we have to restart from first element
            else if (pointer > 0 && currentTimeN1 +offset[pointer]< currentTimeN2){
                     //
                     pointer = 0;
                     multiplier[0]++;
                     //cout << currentTimeN2<< endl;
            }
            // if current time is smaller than next. Increase multipler of next
            else if (currentTimeN1 + offset[pointer]> currentTimeN2){

                    //multiplier[pointer+1]++;
                //multiplier[pointer+1]++;
            }

        }
        auto stop = chrono::high_resolution_clock::now();
        auto duration = chrono::duration_cast<chrono::milliseconds>(stop - start);
        cout << "Time: " << duration.count() << endl;
        cout << busIDs[0]*multiplier[0];
    }
    else
    {
        cout << "Unable to open file";
    }
}