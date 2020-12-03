#include <iostream>
#include <vector>
#include <string>
#include <fstream>
#include <math.h>
#include <array>
#include <sstream>

using namespace std;

int main()
{
    string line;
    ifstream myfile("input.txt");
    int valid = 0;
    if (myfile.is_open())
    {
        bool byr = false;
        bool iyr = false;
        bool eyr = false;
        bool hgt = false;
        bool hcl = false;
        bool ecl = false;
        bool pid = false;
        bool cid = false;

        while (myfile.good())
        {

            getline(myfile, line);

            auto iss = istringstream{line};
            auto str = string{};

            while (iss >> str)
            {
                string values = str.substr(4, str.size());

                if (str.substr(0, 3).compare("byr") == 0 && values.size() == 4 &&
                    stoi(values) >= 1920 && stoi(values) <= 2002)
                {
                    byr = true;
                };
                if (str.substr(0, 3).compare("iyr") == 0 && values.size() == 4 &&
                    stoi(values) >= 2010 && stoi(values) <= 2020)
                {

                    iyr = true;
                };
                if (str.substr(0, 3).compare("eyr") == 0 && values.size() == 4 &&
                    stoi(values) >= 2020 && stoi(values) <= 2030)
                {
                    eyr = true;
                };
                if (str.substr(0, 3).compare("hgt") == 0)
                {
                    string unit, num;

                    for (int i = 0; i < values.length(); i++)
                    {

                        if (isdigit(values[i]))
                        {
                            num.push_back(values[i]);
                        }
                        else if ((values[i] >= 'a' && values[i] <= 'z'))
                        {
                            unit.push_back(values[i]);
                        }
                    }
                    if (unit == "cm" && stoi(num) >= 150 && stoi(num) <= 193)
                    {
                        hgt = true;
                    }
                    else if (unit == "in" && stoi(num) >= 59 && stoi(num) <= 76)
                    {
                        hgt = true;
                    }
                };
                if (str.substr(0, 3).compare("hcl") == 0 && values[0] == '#' && size(values) == 7)
                {
                    for (int i = 1; i < values.length(); i++)
                    {
                        if ((values[i] >= '0' && values[i] <= '9') || (values[i] >= 'a' && values[i] <= 'f'))
                        {
                            hcl = true;
                        }
                        else
                        {
                            hcl = false;
                            break;
                        }
                    }
                };
                if (str.substr(0, 3).compare("ecl") == 0)
                {
                    string okColors[7]{"amb", "blu", "brn", "gry", "grn", "hzl", "oth"};
                    for (int i = 0; i < size(okColors); i++)
                    {
                        if (values == okColors[i] && values.size() == 3)
                        {
                            ecl = true;
                            break;
                        }
                    }
                };
                if (str.substr(0, 3).compare("pid") == 0 && size(values) == 9)
                {
                    pid = true;
                    for (int i = 0; i < size(values); i++)
                    {
                        if (!isdigit(values[i]))
                        {
                            pid = false;
                            break;
                        }
                    }
                };
            }

            if (size(line) == 0 || myfile.eof())
            {
                if (byr && iyr && eyr && hgt && hcl && ecl && pid)
                {
                    valid++;
                }
                byr = false;
                iyr = false;
                eyr = false;
                hgt = false;
                hcl = false;
                ecl = false;
                pid = false;
            }
        }
        cout << "Valid " << valid;

        myfile.close();
    }
    else
    {
        cout << "Unable to open file";
    }
}