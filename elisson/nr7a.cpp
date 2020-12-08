#include <iostream>
#include <vector>
#include <string>
#include <fstream>
#include <math.h>
#include <array>
#include <sstream>
#include <algorithm>
#include <iterator>
#include <chrono>

using namespace std;

bool containsShinyGold(int parent,
                       vector<string> &parentColor,
                       vector<string> &parentType,
                       vector<vector<string>> &childrenColor,
                       vector<vector<string>> &childrenType,
                       vector<vector<int>> &childrenNr)
{

    vector<string> v2 = childrenColor[parent];
    vector<string> v1 = childrenType[parent];
    for (int i = 0; i < size(v1); i++)
    {
        if (v1[i] == "null")
        {
            return false;
        }
        else if (v1[i] == "shiny" && v2[i] == "gold")
        {
            return true;
        }
        else
        {
            for (int j = 0; j < size(parentType); j++)
            {
                if (v1[i] == parentType[j] && v2[i] == parentColor[j])
                {
                    bool temp= containsShinyGold(j,
                                             parentColor,
                                             parentType,
                                             childrenColor,
                                             childrenType,
                                             childrenNr);
                    if (temp == true){
                        return true;
                    }
                }
            }
        }
    }
    return false;
}
int main()
{
    auto start = chrono::high_resolution_clock::now();
    string line;
    ifstream myfile("input.txt");
    int nrOfBags = 0;
    
    if (myfile.is_open())
    {

        while (myfile.good())
        {
            vector<vector<string>> childrenColor;
            vector<vector<string>> childrenType;
            vector<vector<int>> childrenNr;

            vector<string> parentColor;
            vector<string> parentType;
            vector<int> nrOfChildren;

            while (getline(myfile, line) && line.size() > 0)
            {

                stringstream s(line);
                string word;

                vector<int> v1;
                vector<string> v2;
                vector<string> v3;

                string delimiter = "contain ";
                string childrenString = line.substr(line.find(delimiter) + size(delimiter), size(line));
                s >> word;
                parentType.push_back(word);
                s >> word;
                parentColor.push_back(word);
                stringstream ss(childrenString);
                while (ss >> word)
                {
                    if (word == "no")
                    {
                        v3.push_back({"null"});
                        v2.push_back({"null"});
                        v1.push_back({0});
                        break;
                    }
                    else
                    {
                        v1.push_back(stoi(word));
                        ss >> word;
                        v2.push_back(word);
                        ss >> word;
                        v3.push_back(word);
                        ss >> word;
                    }
                }
                childrenNr.push_back(v1);
                childrenType.push_back(v2);
                childrenColor.push_back(v3);
            }
            
            for (int i = 0; i < size(parentColor); i++)
            {
                bool shinyGold = containsShinyGold(i,
                                                   parentColor,
                                                   parentType,
                                                   childrenColor,
                                                   childrenType,
                                                   childrenNr);
                if (shinyGold)
                {
                    nrOfBags++;
                }
                cout << i << endl;
            }
        }
        myfile.close();
    }
    else
    {
        cout << "Unable to open file";
    }
    cout << "Nr of bags :" << nrOfBags << endl;
    auto stop = chrono::high_resolution_clock::now();
    auto duration = chrono::duration_cast<chrono::milliseconds>(stop - start);
    cout << "Time: " << duration.count() << endl;
}