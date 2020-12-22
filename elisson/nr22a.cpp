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
    ifstream myfile("input.txt");
    string line;

    deque<long long int> player1;
    deque<long long int> player2;
    getline(myfile, line);
    getline(myfile, line);
    while (line.size()!=0)
    {
        player1.push_back(stoi(line));
        getline(myfile, line);
    }
    getline(myfile, line);
    while (getline(myfile, line))
    {
        player2.push_back(stoi(line));
    }

    while(player1.size() > 0 && player2.size() > 0){

        int player1Card = player1[0];
        player1.pop_front();
        int player2Card = player2[0];
        player2.pop_front();

        if (player1Card > player2Card){
            player1.push_back(player1Card);
            player1.push_back(player2Card);
        }
        else{
            player2.push_back(player2Card);
            player2.push_back(player1Card);
        }
    }
    long long int winnerScore = 0;
    if (player1.size() > player2.size()){
        for (int i = 0; i<player1.size();i++){
            winnerScore += (i+1)*player1[player1.size()-1-i];
        }
    }
    else {
        for (int i = 0; i<player2.size();i++){
            winnerScore += (i+1)*player2[player2.size()-1-i];
        }
    }

    auto stop = chrono::high_resolution_clock::now();
    auto duration = chrono::duration_cast<chrono::milliseconds>(stop - start);
    cout << "Time: " << duration.count() << endl;
    cout << "Result A: " << winnerScore << endl;
}