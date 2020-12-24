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

int main()
{
    auto start = chrono::high_resolution_clock::now();
    ifstream myfile("input.txt");
    string line;
    map<string, vector<string>> ingridients; //allergen, ingridient
    unordered_map<string, int> ingridientsCounter; //ingridient, count
    // collect all rules in a map
    while (getline(myfile, line))
    {
        bool allergenMode = false;
        istringstream s(line);
        string str;
        vector<string> ingridientsTemp;
        vector<string> allergens;
        int iAllergen = 0;
        int iIngridient = 0;
        while (getline(s, str, ' ')){
            if (str[0] == '('){
                allergenMode = true;
                continue;
            }
            if (allergenMode){
                str.erase(remove(str.begin(), str.end(), '('), str.end());
                str.erase(remove(str.begin(), str.end(), ')'), str.end());
                str.erase(remove(str.begin(), str.end(), ','), str.end());
                allergens.push_back(str);
            }
            else {
                ingridientsTemp.push_back(str);
                if ((ingridientsCounter.find(str) != ingridientsCounter.end()))
                    ingridientsCounter[str] = ingridientsCounter[str]++;
                else
                    ingridientsCounter[str] = 1;

            }
        }
        
        for (int i= 0; i<allergens.size();i++){

            // check if the current ingridients exits in the map
            if (ingridients.find(allergens[i]) != ingridients.end()){
                vector<string> currentIngridient = ingridients[allergens[i]];
                vector<string> intersection;
                sort(currentIngridient.begin(), currentIngridient.end());
                sort(ingridientsTemp.begin(), ingridientsTemp.end());
                
                // Intersect the current ingridients with the possible ingridients 
                set_intersection(currentIngridient.begin(),currentIngridient.end(),
                                    ingridientsTemp.begin(),ingridientsTemp.end(),
                                    back_inserter(intersection));
                //push back the possible ingridients
                ingridients[allergens[i]] = intersection;
            }
            // if the allergen does not exist in the map before just push it
            else {
                ingridients[allergens[i]] = ingridientsTemp;
            }
        }
    }
    // Clean vector until only one possible ingridient per allergen
    bool cleaningCompleted = true;
    int k=0;
    while (true){
        cleaningCompleted = true;
        for (auto evaluatedElement : ingridients){
            if (evaluatedElement.second.size() == 1){
                for (auto currentElement : ingridients){
                    if (evaluatedElement.first != currentElement.first 
                        && currentElement.second.size() > 1)
                    {
                        cleaningCompleted = false;
                        vector<string>::iterator position = find(currentElement.second.begin(), currentElement.second.end(), evaluatedElement.second[0]);
                        if (position != currentElement.second.end())
                            currentElement.second.erase(position);
                        ingridients[currentElement.first] = currentElement.second;
                    }
                }
            }
        }
        if (cleaningCompleted)
            break;
    }

    //check if the ingridient contains an allergen. Count all that does not.
    int nrOfIngridientsWithoutAllergens = 0;
    for (auto &currentIngridient:ingridientsCounter){
        bool containsAllergens = false;
        for (auto &currentAllergen:ingridients){ 
            if (currentIngridient.first == currentAllergen.second[0]){
                containsAllergens = true;
                break;
            }
        }
        if (!containsAllergens)
            nrOfIngridientsWithoutAllergens += currentIngridient.second;
    }
    string canonical = "";
    for (auto &currentIngridient:ingridients){ //map is sorted already
        canonical = canonical + ","+ currentIngridient.second[0];
    }
    canonical.erase(0,1);

    auto stop = chrono::high_resolution_clock::now();
    auto duration = chrono::duration_cast<chrono::milliseconds>(stop - start);
    cout << "Time: " << duration.count() << endl;
    cout << "Result A: " << nrOfIngridientsWithoutAllergens << endl;
    cout << "Result B: " << canonical << endl;
}