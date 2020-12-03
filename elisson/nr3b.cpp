#include <iostream>
#include <vector>
#include <string>
#include <fstream>
#include <math.h>
#include <array>

using namespace std;

int main()
{
    string line;
    ifstream myfile("input.txt");
    //int lineIndex=3;
    if (myfile.is_open())
    {

        int nrThreesMultiplied = 1;
        getline(myfile, line);
        array<int, 5> lineIndex{1, 3, 5, 7, 1};
        array<int, 5> nrThrees{0, 0, 0, 0, 0};
        int j = 1;
        while (myfile.good())
        {
            getline(myfile, line);

            if (line[lineIndex[0]] == '#')
            {
                nrThrees[0] = nrThrees[0] + 1;
            }
            if (line[lineIndex[1]] == '#')
            {
                nrThrees[1] = nrThrees[1] + 1;
            }
            if (line[lineIndex[2]] == '#')
            {
                nrThrees[2] = nrThrees[2] + 1;
            }
            if (line[lineIndex[3]] == '#')
            {
                nrThrees[3] = nrThrees[3] + 1;
            }
            if ((j % 2 == 0) && line[lineIndex[4]] == '#')
            {
                nrThrees[4] = nrThrees[4] + 1;
            }
            lineIndex[0] = lineIndex[0] + 1;
            lineIndex[1] = lineIndex[1] + 3;
            lineIndex[2] = lineIndex[2] + 5;
            lineIndex[3] = lineIndex[3] + 7;
            if (j % 2 == 0)
            {
                lineIndex[4] = lineIndex[4] + 1;
            }

            if (lineIndex[0] >= size(line))
            {
                lineIndex[0] = lineIndex[0] - size(line);
            }
            if (lineIndex[1] >= size(line))
            {
                lineIndex[1] = lineIndex[1] - size(line);
            }
            if (lineIndex[2] >= size(line))
            {
                lineIndex[2] = lineIndex[2] - size(line);
            }
            if (lineIndex[3] >= size(line))
            {
                lineIndex[3] = lineIndex[3] - size(line);
            }
            if ((j % 2 == 0) && lineIndex[4] >= size(line))
            {
                lineIndex[4] = lineIndex[4] - size(line);
            }
            j++;
        }
        cout << "Nr Threes " << (long long)((long long)nrThrees[0] * (long long)nrThrees[1] * (long long)nrThrees[2] * (long long)nrThrees[3] * (long long)nrThrees[4]);

        myfile.close();
    }
    else
    {
        cout << "Unable to open file";
    }
}