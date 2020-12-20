#include <iostream>
#include <vector>
#include <string>
#include <fstream>
//#include <math.h>
//#include <array>
#include <sstream>
#include <algorithm>
#include <chrono>
#include <map>
#include <unordered_map>
//#include <regex>
//#include <numeric>
//#include <set>
#include <iterator>

using namespace std;

bool checkRule(string &line, unordered_map<int, vector<string>> &rules, int ruleNr, int &messageIndex){

    vector<string> rule = rules[ruleNr];
    bool ruleOk = true;
    int initMessageIndex = messageIndex;
    for (int i = 0; i < size(rule);i++){
        if (rule[i] == "a" || rule[i] == "b"){
            if (line[messageIndex, messageIndex] != rule[i][0])
                return false;
            else{
                messageIndex++;
            }
        }
        else if (rule[i] == "|"){
            if (ruleOk) // no need to check the next expression since the first one was true
                return true;
        }
        else{
            ruleOk = checkRule(line, rules, stoi(rule[i]), messageIndex);
        }
        if (!ruleOk){
            // return if a rule has failed no OR rules exist
            auto it = find(rule.begin()+i, rule.end(), "|");
            if (it !=rule.end()){
                messageIndex = initMessageIndex;
                i = it - rule.begin();
            }
            else{
                messageIndex = initMessageIndex;
                return false;
            }
        }
        // return true if the end of message is reached and rules are ok
        if (messageIndex == size(line) && ruleOk){
            return true;
        }
    }
    return true;
}

int validateMessage(string &line, unordered_map<int, vector<string>> &rules){

    int ruleNr = 0;
    int messageIndex = 0;
    bool ruleOk = checkRule(line, rules, ruleNr, messageIndex);
    if (messageIndex == size(line) && ruleOk) //check if the complete message is covered by rules
        return true;
    else
        return false;
}


int main()
{
    auto start = chrono::high_resolution_clock::now();
    ifstream myfile("input.txt");
    string line;
    unordered_map<int, vector<string>> rules;

    // collect all rules in a map
    while (getline(myfile, line))
    {
        if (size(line) == 0)
            break;
        int delimiter = find(line.begin(), line.end(), ':')-line.begin();
        istringstream s(line.substr(delimiter+2, size(line)));
        int ruleNr = stoi(line.substr(0, delimiter));
        string rule;
        vector<string> temp_rules;
        while(getline(s,rule, ' ')){
            if (rule[0]!='"')
                temp_rules.push_back(rule);
            else
                temp_rules.push_back(rule.substr(1,1));
        }
        rules[ruleNr] = temp_rules;
    }

    //getline(myfile, line);
    // Check all lines
    int validMessages = 0;
    while(getline(myfile, line)){

        validMessages = validMessages + validateMessage(line, rules);
    }

    auto stop = chrono::high_resolution_clock::now();
    auto duration = chrono::duration_cast<chrono::milliseconds>(stop - start);
    cout << "Time: " << duration.count() << endl;
    cout << "Result: " << validMessages << endl;
}