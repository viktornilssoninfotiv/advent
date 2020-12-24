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


int playGame(deque<int> &player1, deque<int> &player2){
    vector<deque<int>> player1PlayedHands;
    vector<deque<int>> player2PlayedHands;
    while(player1.size() > 0 && player2.size() > 0){
        player1PlayedHands.push_back(player1);
        player2PlayedHands.push_back(player2);
        
        int player1Card = player1[0];
        player1.pop_front();
        int player2Card = player2[0];
        player2.pop_front();


        if (player1Card <= player1.size() && player2Card <= player2.size()){
            deque<int> player1_rec_combat(player1.begin(), player1.begin()+player1Card);
            deque<int> player2_rec_combat(player2.begin(), player2.begin()+player2Card);
            int winner = playGame(player1_rec_combat, player2_rec_combat);

            if(winner == 1){
                player1.push_back(player1Card);
                player1.push_back(player2Card);
            }
            else
            {
                player2.push_back(player2Card);
                player2.push_back(player1Card);
            }
            
        }
        else if (player1Card > player2Card){
            player1.push_back(player1Card);
            player1.push_back(player2Card);
        }
        else{
            player2.push_back(player2Card);
            player2.push_back(player1Card);
        }

        if (find(player1PlayedHands.begin(), player1PlayedHands.end(), player1) !=player1PlayedHands.end()){
            return 1; //Player 1 always win if played before. 3 means autowin for p1
        }
        else if (find(player2PlayedHands.begin(), player2PlayedHands.end(), player2) !=player2PlayedHands.end()){
            return 1; //Player 1 always win if played before
        }
    }
    if (player1.size() == 0)
        return 2;
    else
        return 1;
}

int main()
{
    auto start = chrono::high_resolution_clock::now();
    ifstream myfile("input.txt");
    string line;

    deque<int> player1;
    deque<int> player2;
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

    int winner = playGame(player1, player2);

    int winnerScore = 0;
    if (winner != 2){
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
    cout << "Result: " << winnerScore << endl;
}