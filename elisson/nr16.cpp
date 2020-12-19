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
#include <set>
#include <iterator>

using namespace std;

int main()
{
    auto start = chrono::high_resolution_clock::now();
    ifstream myfile("input.txt");

    string line;
    vector<vector<int>> bounds;
    vector<long long int> myTicket;

    while (getline(myfile, line))
    {
        if (size(line) == 0)
            break;

        int startindex = line.find(":");
        int delimiter = line.find("-");
        int splitter = line.find("or ");

        int lowerBound = stoi(line.substr(startindex + 2, delimiter));
        int upperBound = stoi(line.substr(delimiter + 1, splitter - 1));

        delimiter = line.find("-", delimiter + 1);
        int lowerBound2 = stoi(line.substr(splitter + 3, delimiter));
        int upperBound2 = stoi(line.substr(delimiter + 1));

        vector<int> tempBound;
        tempBound.push_back(lowerBound);
        tempBound.push_back(upperBound);
        tempBound.push_back(lowerBound2);
        tempBound.push_back(upperBound2);
        bounds.push_back(tempBound);
    }

    getline(myfile, line);
    getline(myfile, line);

    istringstream ss(line);
    string myticketvalue;
    while (getline(ss, myticketvalue, ',')){
        int intvalue = stoll(myticketvalue);
        myTicket.push_back(intvalue);
    }
    getline(myfile, line);
    getline(myfile, line);

    vector<set<int>> possibleCategories;

    int errorRate = 0;
    while (getline(myfile, line))
    {
        istringstream s(line);
        string value;
        bool ticketOk = true;
        vector<pair<int, int>> possibleCatoriesTicket; //<ticket index, cat index>
        int ticketCategory = 0;
        while (getline(s, value, ','))
        {
            bool fieldOk = false;
            int intvalue = stoi(value);

            for (int i = 0; i < size(bounds); i++)
            {
                if (intvalue >= bounds[i][0] && intvalue <= bounds[i][1])
                {
                    possibleCatoriesTicket.push_back({ticketCategory, i});
                    fieldOk = true;
                }
                else if (intvalue >= bounds[i][2] && intvalue <= bounds[i][3])
                {
                    possibleCatoriesTicket.push_back({ticketCategory, i});
                    fieldOk = true;
                }
                else
                {
                }
            }
            if (!fieldOk)
            {
                ticketOk = false;
                errorRate = errorRate + intvalue;
            }
            ticketCategory++;
        }
        if (ticketOk)
        {
            if (possibleCategories.size() == 0)
            {
                int j = 0;
                for (int i = 0; i < bounds.size(); i++)
                {
                    set<int> tempset = {};
                    while (possibleCatoriesTicket[j].first == i)
                    {
                        tempset.insert(possibleCatoriesTicket[j].second);
                        j++;
                    }
                    possibleCategories.push_back(tempset);
                }
            }
            else
            {
                int j = 0;
                for (int i = 0; i < size(bounds); i++)
                {
                    set<int> tempset = {};
                    while (possibleCatoriesTicket[j].first == i)
                    {
                        tempset.insert(possibleCatoriesTicket[j].second);
                        j++;
                    }
                    set<int> currentSet = possibleCategories[i];
                    set<int> interSection;
                    set_intersection(tempset.begin(), tempset.end(), currentSet.begin(), currentSet.end(), inserter(interSection, interSection.begin()));
                    possibleCategories[i] = interSection;
                }
            }
        }
    }
    
    // Clean vector until only one possible per category
    bool cleaningCompleted = true;
    int k=0;
    while (true){
        if (size(possibleCategories[k]) == 1)
        {
            for (int j = 0; j < size(possibleCategories); j++)
            {
                if (k != j && possibleCategories[j].size()>1)
                {
                    cleaningCompleted = false;
                    possibleCategories[j].erase(*possibleCategories[k].begin());
                }
            }
        }
        k++;
        if (k == possibleCategories.size()){
            k = 0;
            if (cleaningCompleted)
                break;
            cleaningCompleted = true;
        }
    }
    long long int value = 1;
    for (int i = 0; i<size(possibleCategories);i++){
        if (*possibleCategories[i].begin() < 6)
            value *=myTicket[i];
    }
    auto stop = chrono::high_resolution_clock::now();
    auto duration = chrono::duration_cast<chrono::milliseconds>(stop - start);
    cout << "Time: " << duration.count() << endl;
    cout << "Result: " << value << endl;
}