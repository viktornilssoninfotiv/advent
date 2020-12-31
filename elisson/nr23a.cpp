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

    deque<int> cups{5, 9, 8, 1, 6, 2, 7 ,3 ,4};

    for (int i = 10; i <= 1000000;i++){
        cups.push_back(i);
    }

    int max_cup = 1000000;
    int min_cup = 1;
    int currentCup = 5;
    for (int i = 0; i<10;i++){

        int currentCupIndex = distance(cups.begin(), find(cups.begin(), cups.end(), currentCup));
        
        // Pick up new cups
        deque<int> pickUp;
        int pickUpIndex = currentCupIndex;
        deque<int> tempCups = cups;
        for(int j = 1; j<4;j++){
            if (pickUpIndex + j == size(cups))
                pickUpIndex = -j;

            pickUp.push_back(cups[pickUpIndex+j]);

            // erase the picked cup from the list
            tempCups.erase(find(tempCups.begin(), tempCups.end(), cups[pickUpIndex+j]));

        }
        cups = tempCups;

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
        currentCupIndex = distance(cups.begin(), find(cups.begin(), cups.end(), currentCup));
        currentCupIndex++;
        if (currentCupIndex >= size(cups))
            currentCupIndex = 0;
        currentCup = cups[currentCupIndex];


        // insert the picked cups
        int destinationCupIndex = distance(cups.begin(), find(cups.begin(), cups.end(), destinationCupStart)) + 1;
        for(int j = 0; j<3;j++){
            int destinationCup = destinationCupIndex + j;
            if (destinationCup > max_cup)
                destinationCup = min_cup;
            cups.insert(cups.begin() + destinationCup, pickUp[j]);

        }


        //cout << i << endl;

    }

    int index_of_one = distance(cups.begin(), find(cups.begin(), cups.end(), 1));
    // string result;
    // for (int i = 0; i<size(cups)-1;i++){
    //     index_of_one++;
    //     if (index_of_one >= size(cups))
    //         index_of_one = 0;
    //     result = result + to_string(cups[index_of_one]);

    // }

    auto stop = chrono::high_resolution_clock::now();
    auto duration = chrono::duration_cast<chrono::milliseconds>(stop - start);
    cout << "Time: " << duration.count() << endl;
    cout << "Result: " << 0 << endl;
}