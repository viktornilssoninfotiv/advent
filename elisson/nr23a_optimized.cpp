#include <iostream>
#include <vector>
#include <string>
#include <fstream>
//#include <math.h>
//#include <array>
#include <sstream>
#include <algorithm>
#include <chrono>
//#include <map>
//#include <unordered_map>
//#include <regex>
//#include <numeric>
//#include <set>
#include <deque>
#include <iterator>

using namespace std;

int main()
{
    auto start = chrono::high_resolution_clock::now();
    auto duration2 = chrono::high_resolution_clock::now() - chrono::high_resolution_clock::now();

    vector<int> cups{5, 9, 8, 1, 6, 2, 7 ,3 ,4};

    int max_cup = 9;
    // for (int i = 10; i <= max_cup;i++){
    //     cups.push_back(i);
    // }

    
    int min_cup = 1;
    int currentCup = 5;
    int currentCupIndex = 0;
    
    for (int i = 0; i<100;i++){
        // Pick up new cups
        vector<int> pickUp;
        int pickUpIndex = currentCupIndex + 1;
        auto start2 = chrono::high_resolution_clock::now(); 
        for(int j = 1; j<4;j++){
            if (pickUpIndex == cups.size())
                pickUpIndex = 0;

            pickUp.push_back(cups[pickUpIndex]);

            if (pickUpIndex < currentCupIndex)
                currentCupIndex--;
            //erase the picked cup from the list
            if (j==1 && pickUpIndex < max_cup-3){
                pickUp.push_back(cups[pickUpIndex+1]);
                pickUp.push_back(cups[pickUpIndex+2]);
                cups.erase(cups.begin() + pickUpIndex, cups.begin() + pickUpIndex + 3);
                break;
            }
            else
            {
                cups.erase(cups.begin() + pickUpIndex);    
            }
        }

            auto stop2 = chrono::high_resolution_clock::now();
            duration2 = duration2 + stop2-start2; 
        int destinationCupStart = currentCup;
        // Set new destination cup not within pick up
        
        while(true){

            destinationCupStart = destinationCupStart - 1;
            if (destinationCupStart<min_cup)
                destinationCupStart = max_cup;

            if (find(pickUp.begin(), pickUp.end(), destinationCupStart) == pickUp.end())
                break;
        }
 
        

        // select new current cup
        currentCupIndex++;
        if (currentCupIndex >= cups.size())
            currentCupIndex = 0;
        currentCup = cups[currentCupIndex];


        // insert the picked cups
        
        int destinationCupIndex = distance(cups.begin(), find(cups.begin(), cups.end(), destinationCupStart)) + 1;

        
        for(int j = 0; j<3;j++){
            int destinationCup = destinationCupIndex + j;
            if (destinationCup > max_cup)
                destinationCup = min_cup;
            
            if (j==0 && destinationCup < max_cup-3){
                if (destinationCup < currentCupIndex){
                    currentCupIndex = currentCupIndex + 3;
                }
                cups.insert(cups.begin() + destinationCup, pickUp.begin(), pickUp.end());
                break;
            }
            else
            {
                cups.insert(cups.begin() + destinationCup, pickUp[j]);
            }

        }

    


        //cout << i << endl;

    }

    int index_of_one = distance(cups.begin(), find(cups.begin(), cups.end(), 1));
    string result;
    for (int i = 0; i<size(cups)-1;i++){
        index_of_one++;
        if (index_of_one >= size(cups))
            index_of_one = 0;
        result = result + to_string(cups[index_of_one]);

    }

    auto stop = chrono::high_resolution_clock::now();
    auto duration = chrono::duration_cast<chrono::milliseconds>(stop - start);
    auto duration3 = chrono::duration_cast<chrono::milliseconds>(duration2);
    cout << "Time: " << duration3.count() << endl;  
    cout << "Result: " << result << endl;
}