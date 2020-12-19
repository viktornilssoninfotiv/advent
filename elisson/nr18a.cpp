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
using Quadruple = array<int, 4>;

long long int evaluateExpression(string::iterator &currentIt, string &line, int &currentNumber){
        long long int result = 0; 
       
        char current;
        char currentOperator = '+';
        for (&currentIt; currentIt !=line.end();currentIt++){
            current = *currentIt;
            if (current >= '0' && current <= '9'){
                currentNumber = int(current-48);
                if (currentOperator == '+')
                    result = result + currentNumber;
                else
                    result = result* currentNumber;
            }
            else if (current == '+'){
                currentOperator = '+';
            }
            else if (current == '*'){
                currentOperator = '*';
            }
            else if (current == '('){
                    currentIt++;
                    if (currentOperator == '+')
                        result = result + evaluateExpression(currentIt,line, currentNumber);
                    else 
                        result = result * evaluateExpression(currentIt,line, currentNumber);
            }
            else if (current == ')'){
                    return result;
            }
        }
        return result;
}

int main()
{
    auto start = chrono::high_resolution_clock::now();
    ifstream myfile("input.txt");
    string line;
    long long int result = 0;
    while (getline(myfile, line))
    {
        int currentNumber = 0;
        string::iterator currentIt = line.begin();
        result = result + evaluateExpression(currentIt,line, currentNumber);
    }
    auto stop = chrono::high_resolution_clock::now();
    auto duration = chrono::duration_cast<chrono::milliseconds>(stop - start);
    cout << "Time: " << duration.count() << endl;
    cout << "Result: " << result << endl;
}