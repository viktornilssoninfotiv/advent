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

int main()
{
    auto start = chrono::high_resolution_clock::now();
    string line;
    ifstream myfile("input.txt");
    
    int nrAnswersA = 0;
    int nrAnswersB = 0;
    if (myfile.is_open())
    {

        while (myfile.good())
        {
            vector<char> answers;
            int nrPersons = 0;
            while (getline(myfile, line) && line.size() > 0)
            {
                nrPersons ++;
                
                for (int i = 0; i < size(line); i++)
                {
                    answers.push_back(line[i]);
                }
            }
             if (answers.size() > 0)
            {
                sort(answers.begin(), answers.end());
                int nrOfYes = 0;
                int nrOfPersonYes = 1;
                for (int i = 0; i < answers.size() - 1; i++)
                {
                    if ((answers[i] == answers[i + 1]))
                    {
                        nrOfPersonYes++;
                        answers.erase(answers.begin() + i +1);
                        i--;
                    }
                    else {
                        nrOfPersonYes = 1;
                    }
                    if (1 == nrPersons)
                        nrOfYes = answers.size();
                    else if (nrOfPersonYes == nrPersons)
                        nrOfYes++;
                }
                //A
                nrAnswersA = nrAnswersA + answers.size();
                //B
                nrAnswersB = nrAnswersB + nrOfYes;

            }
        }
        myfile.close();
    }
    else
    {
        cout << "Unable to open file";
    }
    cout << "Nr of answers A " << nrAnswersA << endl;
    cout << "Nr of answers B " << nrAnswersB << endl;
    auto stop = chrono::high_resolution_clock::now();
    auto duration = chrono::duration_cast<chrono::milliseconds>(stop - start);
    cout << "Time: " << duration.count() << endl;
}