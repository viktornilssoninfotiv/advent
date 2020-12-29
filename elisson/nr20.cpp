#include <iostream>
#include <vector>
#include <string>
#include <fstream>
#include <utility>  
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

vector<int> getVerticalTile(vector<vector<int>> &currentTile, int index){

    vector<int> verticalTile;
    for (int i = 0; i<currentTile.size();i++){
        verticalTile.push_back(currentTile[i][index]);
    }
    return verticalTile;
}

void setVerticalTile(vector<vector<int>> &currentTile, int index, vector<int> &verticalTile){
    for (int i = 0; i<currentTile.size();i++){
        currentTile[i][index] = verticalTile[i];
    }
}

vector<int> flipTile(vector<int> currentTile){
     reverse(currentTile.begin(), currentTile.end());
     return currentTile;
}

vector<vector<int>> flipImageVertical(vector<vector<int>> tileImage){

    vector<vector<int>> tileImageRaw = tileImage;
    for (int i = 0; i<size(tileImage);i++){
        vector<int> edge = tileImageRaw[size(tileImageRaw)-i-1];
        tileImage[i] = edge;
    }
    return tileImage;
}

vector<vector<int>> flipImageHorizontal(vector<vector<int>> tileImage){
    vector<vector<int>> tileImageRaw = tileImage;

    for (int i = 0; i<size(tileImage);i++){
        vector<int> edge = tileImageRaw[i];
        tileImage[i] = flipTile(edge);
    }
    return tileImage;
}

vector<vector<int>> rotateImageRight(vector<vector<int>> tileImage){
    
    vector<vector<int>> tileImageRaw = tileImage;

    for (int i = 0; i<size(tileImage);i++){
        vector<int> edge = tileImageRaw[size(tileImage) - i - 1];
        setVerticalTile(tileImage, i, edge);
    }

    return tileImage;
}



int checkMatching(vector<int> &edge, vector<vector<int>> &matchTile){
// returns 0-no match, 1-top, 2-top flip 3-bottom 4-bottom flipped 
//         5-left 6-left flipped 7-right 8-right flipped
    //check first edge
    const int dimension = size(matchTile) - 1;

    if (edge == matchTile[0])
        return 1;
    else if (edge == flipTile(matchTile[0]))
        return 2;
    else if (edge == matchTile[dimension])
        return 3;
    else if (edge == flipTile(matchTile[dimension]))
        return 4;
    else if (edge == getVerticalTile(matchTile, 0))
        return 5;
    else if (edge == flipTile(getVerticalTile(matchTile, 0)))
        return 6;  
    else if (edge == getVerticalTile(matchTile, dimension))
        return 7;
    else if (edge == flipTile(getVerticalTile(matchTile, dimension)))
        return 8;  
    else
        return 0;

}

void setMatch(map<int, pair<int, int>> &tilePosition, pair<int, int> matchPosition,int currentPosition , int edge){
// returns 0-no match, 1-top, 2-top flip 3-bottom 4-bottom flipped 
//         5-left 6-left flipped 7-right 8-right flipped
    if (edge == 1 || edge == 2)
        tilePosition[currentPosition] = {matchPosition.first, matchPosition.second+1};
    else if (edge == 3 || edge == 4)
        tilePosition[currentPosition] = {matchPosition.first, matchPosition.second-1};
    else if (edge == 5 || edge == 6)
        tilePosition[currentPosition] = {matchPosition.first-1, matchPosition.second};
    else if (edge == 7 || edge == 8)
        tilePosition[currentPosition] = {matchPosition.first+1, matchPosition.second};
}

void matchTile(pair<const int, vector<vector<int>>> &currentTile,map<int, vector<vector<int>>> &tileImage,map<int, pair<int, int>> &tilePosition){
    // returns 0-no match, 1-top, 2-top flip 3-bottom 4-bottom flipped 
    //         5-left 6-left flipped 7-right 8-right flipped
    const int dimension = currentTile.second.size() - 1;
    for (auto &matchTile:tilePosition){
        if (currentTile.first == matchTile.first)
            continue;
        vector<int> topEdge = currentTile.second[0];
        int match = checkMatching(topEdge, tileImage[matchTile.first]);
        if (match>0){
            if (match==1){
                tileImage[currentTile.first] = rotateImageRight(tileImage[currentTile.first]);
                tileImage[currentTile.first] = rotateImageRight(tileImage[currentTile.first]);
                tileImage[currentTile.first] = flipImageHorizontal(tileImage[currentTile.first]);
            }
            else if (match == 2){
                tileImage[currentTile.first] = rotateImageRight(tileImage[currentTile.first]);
                tileImage[currentTile.first] = rotateImageRight(tileImage[currentTile.first]);

            }
            else if (match == 3){
                // do nothing. already algined
            }
            else if (match == 4){
                tileImage[currentTile.first] = flipImageHorizontal(tileImage[currentTile.first]);
            }
            else if (match == 5){
                tileImage[currentTile.first] = rotateImageRight(tileImage[currentTile.first]);
                
            }
            else if (match == 6){
                tileImage[currentTile.first] = rotateImageRight(tileImage[currentTile.first]);
                tileImage[currentTile.first] = flipImageVertical(tileImage[currentTile.first]);

            }
            else if (match == 7){
                tileImage[currentTile.first] = rotateImageRight(tileImage[currentTile.first]);
                tileImage[currentTile.first] = rotateImageRight(tileImage[currentTile.first]);
                tileImage[currentTile.first] = rotateImageRight(tileImage[currentTile.first]);
                tileImage[currentTile.first] = flipImageVertical(tileImage[currentTile.first]);

            }
            else if (match == 8){
                tileImage[currentTile.first] = rotateImageRight(tileImage[currentTile.first]);
                tileImage[currentTile.first] = rotateImageRight(tileImage[currentTile.first]);
                tileImage[currentTile.first] = rotateImageRight(tileImage[currentTile.first]); 

            }
            setMatch(tilePosition, matchTile.second, currentTile.first, match);
            return;
        }

    // returns 0-no match, 1-top, 2-top flip 3-bottom 4-bottom flipped 
    //         5-left 6-left flipped 7-right 8-right flipped
        vector<int> bottomEdge = currentTile.second[dimension];
        match = checkMatching(bottomEdge, tileImage[matchTile.first]);
        if (match>0){
            match = checkMatching(bottomEdge, tileImage[matchTile.first]);
            if (match==3){
                tileImage[currentTile.first] = rotateImageRight(tileImage[currentTile.first]);
                tileImage[currentTile.first] = rotateImageRight(tileImage[currentTile.first]);
                tileImage[currentTile.first] = flipImageHorizontal(tileImage[currentTile.first]);
            }
            else if (match == 4){
                tileImage[currentTile.first] = rotateImageRight(tileImage[currentTile.first]);
                tileImage[currentTile.first] = rotateImageRight(tileImage[currentTile.first]);

            }
            else if (match == 1){
                // do nothing. already algined
            }
            else if (match == 2){
                tileImage[currentTile.first] = flipImageHorizontal(tileImage[currentTile.first]);
            }
            else if (match == 7){
                tileImage[currentTile.first] = rotateImageRight(tileImage[currentTile.first]);
                
            }
            else if (match == 8){
                tileImage[currentTile.first] = rotateImageRight(tileImage[currentTile.first]);
                tileImage[currentTile.first] = flipImageVertical(tileImage[currentTile.first]);

            }
            else if (match == 5){
                tileImage[currentTile.first] = rotateImageRight(tileImage[currentTile.first]);
                tileImage[currentTile.first] = rotateImageRight(tileImage[currentTile.first]);
                tileImage[currentTile.first] = rotateImageRight(tileImage[currentTile.first]);
                tileImage[currentTile.first] = flipImageVertical(tileImage[currentTile.first]);

            }
            else if (match == 6){
                tileImage[currentTile.first] = rotateImageRight(tileImage[currentTile.first]);
                tileImage[currentTile.first] = rotateImageRight(tileImage[currentTile.first]);
                tileImage[currentTile.first] = rotateImageRight(tileImage[currentTile.first]); 

            }
            setMatch(tilePosition, matchTile.second, currentTile.first, match);
            return;
        }


            // returns 0-no match, 1-top, 2-top flip 3-bottom 4-bottom flipped 
            //         5-left 6-left flipped 7-right 8-right flipped
        vector<int> leftEdge = getVerticalTile(currentTile.second,0);
        match = checkMatching(leftEdge, tileImage[matchTile.first]);
        if (match>0){
            if (match==5){
                tileImage[currentTile.first] = rotateImageRight(tileImage[currentTile.first]);
                tileImage[currentTile.first] = rotateImageRight(tileImage[currentTile.first]);
                tileImage[currentTile.first] = flipImageVertical(tileImage[currentTile.first]);
            }
            else if (match == 6){
                tileImage[currentTile.first] = rotateImageRight(tileImage[currentTile.first]);
                tileImage[currentTile.first] = rotateImageRight(tileImage[currentTile.first]);

            }
            else if (match == 7){
                // do nothing. already algined
            }
            else if (match == 8){
                tileImage[currentTile.first] = flipImageVertical(tileImage[currentTile.first]);
            }
            else if (match == 4){
                tileImage[currentTile.first] = rotateImageRight(tileImage[currentTile.first]);
                
            }
            else if (match == 3){
                tileImage[currentTile.first] = rotateImageRight(tileImage[currentTile.first]);
                tileImage[currentTile.first] = flipImageHorizontal(tileImage[currentTile.first]);

            }
            else if (match == 2){
                tileImage[currentTile.first] = rotateImageRight(tileImage[currentTile.first]);
                tileImage[currentTile.first] = rotateImageRight(tileImage[currentTile.first]);
                tileImage[currentTile.first] = rotateImageRight(tileImage[currentTile.first]);
                tileImage[currentTile.first] = flipImageHorizontal(tileImage[currentTile.first]);

            }
            else if (match == 1){
                tileImage[currentTile.first] = rotateImageRight(tileImage[currentTile.first]);
                tileImage[currentTile.first] = rotateImageRight(tileImage[currentTile.first]);
                tileImage[currentTile.first] = rotateImageRight(tileImage[currentTile.first]); 

            }
            setMatch(tilePosition, matchTile.second, currentTile.first, match);
            return;
        }
            // returns 0-no match, 1-top, 2-top flip 3-bottom 4-bottom flipped 
            //         5-left 6-left flipped 7-right 8-right flipped
        vector<int> rightEdge = getVerticalTile(currentTile.second, dimension);
        match = checkMatching(rightEdge, tileImage[matchTile.first]);
        if (match>0){
            if (match==7){
                tileImage[currentTile.first] = rotateImageRight(tileImage[currentTile.first]);
                tileImage[currentTile.first] = rotateImageRight(tileImage[currentTile.first]);
                tileImage[currentTile.first] = flipImageVertical(tileImage[currentTile.first]);
            }
            else if (match == 8){
                tileImage[currentTile.first] = rotateImageRight(tileImage[currentTile.first]);
                tileImage[currentTile.first] = rotateImageRight(tileImage[currentTile.first]);

            }
            else if (match == 5){
                // do nothing. already algined
            }
            else if (match == 6){
                tileImage[currentTile.first] = flipImageVertical(tileImage[currentTile.first]);
            }
            else if (match == 2){
                tileImage[currentTile.first] = rotateImageRight(tileImage[currentTile.first]);
                
            }
            else if (match == 1){
                tileImage[currentTile.first] = rotateImageRight(tileImage[currentTile.first]);
                tileImage[currentTile.first] = flipImageHorizontal(tileImage[currentTile.first]);

            }
            else if (match == 3){
                tileImage[currentTile.first] = rotateImageRight(tileImage[currentTile.first]);
                tileImage[currentTile.first] = rotateImageRight(tileImage[currentTile.first]);
                tileImage[currentTile.first] = rotateImageRight(tileImage[currentTile.first]);
                

            }
            else if (match == 4){
                tileImage[currentTile.first] = rotateImageRight(tileImage[currentTile.first]);
                tileImage[currentTile.first] = rotateImageRight(tileImage[currentTile.first]);
                tileImage[currentTile.first] = rotateImageRight(tileImage[currentTile.first]); 
                tileImage[currentTile.first] = flipImageHorizontal(tileImage[currentTile.first]);

            }
            setMatch(tilePosition, matchTile.second, currentTile.first, match);
            return;
        }

    }

}

int findSeaMonsters(vector<vector<int>> fullImage, vector<vector<int>> pattern){
    int nrOfSeaMonsters = 0;
    for (int row = 0; row<size(fullImage)-3;row++){
        for (int column = 0; column<size(fullImage)-19; column++){
            bool match = true;
            for (int i = 0; i<3;i++){
                for (int j = 0;j<size(pattern[i]); j++){
                    if (fullImage[row + i][column+pattern[i][j]] != 1){
                        match = false;
                        break;
                    }
                }
                if (!match)
                    break;
            }
            if (match)
                nrOfSeaMonsters++;
        }
    }
    return nrOfSeaMonsters;
}

int main()
{
    auto start = chrono::high_resolution_clock::now();
    ifstream myfile("input.txt");
    string line;
    map<int, pair<int, int>> tilePosition; //tile nr, position
    map<int, vector<vector<int>>> tileImage; //tile nr, tile
    int currentTileNr = 0;
    vector<vector<int>> currentTileImage;
    int tileY = -1;
    while (getline(myfile, line))
    {
        if (line.substr(0,2) == "Ti"){
            currentTileNr = stoi(line.substr(4, line.size()-1));
            currentTileImage.clear();
            tileY++;
        }
        else if (size(line) == 0){
            tileImage[currentTileNr] =  currentTileImage;
        }
        else
        {   
            vector<int> temp;
            for (int tileX = 0; tileX<line.size(); tileX++){
                temp.push_back(line[tileX] == '#');
            }
            currentTileImage.push_back(temp);
            
        }
    }
    tileImage[currentTileNr] =  currentTileImage;
    //Set the position of the one arbitrary tile
    tilePosition[currentTileNr] = {0,0}; //x, y position

    // loop until all tiles has a position
    while(tilePosition.size() < tileImage.size()){
        for (auto &currentTile:tileImage){
            //Check if the current tile has a positon
            if (tilePosition.count(currentTile.first) == 1)
                continue;
            matchTile(currentTile, tileImage, tilePosition);
        }
    }
    int maxX= -100;
    int minX = 100;
    int maxY= -100;
    int minY = 100;
    for (auto current:tilePosition){
        maxX = max(current.second.first, maxX);
        maxY = max(current.second.second, maxY);
        minX = min(current.second.first, minX);
        minY = min(current.second.second, minY);
    }

    long long int corner1;
    long long int corner2;
    long long int corner3;
    long long int corner4;
    for (auto current:tilePosition){
        if (current.second.first == maxX && current.second.second == maxY)
            corner1 = current.first;
        else if (current.second.first == maxX && current.second.second == minY)
            corner2 = current.first;
        else if (current.second.first == minX && current.second.second == maxY)
            corner3 = current.first;
        else if (current.second.first == minX && current.second.second == minY)
            corner4 = current.first;
    }
    cout << long long (corner1*corner2*corner3*corner4)<< endl;


    // part 2
    vector<vector<int>> pattern;
    pattern.push_back({18});
    pattern.push_back({0,5,6,11,12,17,18,19});
    pattern.push_back({1,4,7,10,13,16});

    //initialize the full image
    vector<int> temp(size(tilePosition)*8, 0);
    vector<vector<int>> fullImage;

    for (int i = 0; i<size(temp);i++){
        fullImage.push_back(temp);
    }

    // fill the full image vector
    const int dimension = sqrt(size(tilePosition));
    for (int i = 0; i< dimension; i++){
        for (int j = 0; j<dimension; j++){
            bool matchFound = false;
            for (auto current:tilePosition){
                if (current.second.first == (i + minX) && current.second.second == (maxY-j)){
                    vector<vector<int>> currentImage = tileImage[current.first];
                    for (int ii = 1; ii<9;ii++){
                        for (int jj = 1; jj<9;jj++){
                            fullImage[j*8 + jj-1][i*8 + ii - 1] = currentImage[jj][ii];
                        }
                    }
                    break;
                }
            }
        }
    }

    // Search the first side for sea monster
    int nrOfSeaMonsters = 0;
    for (int i = 0;i<4;i++){
        nrOfSeaMonsters = findSeaMonsters(fullImage, pattern);
        if (nrOfSeaMonsters > 0)
            break;
        fullImage = rotateImageRight(fullImage);
    }
    
    // if no found monsters, flip image and search all rotations. 
    if (nrOfSeaMonsters == 0){
        fullImage = flipImageHorizontal(fullImage);
        for (int i = 0;i<4;i++){
            nrOfSeaMonsters = findSeaMonsters(fullImage, pattern);
            if (nrOfSeaMonsters > 0)
                break;
            fullImage = rotateImageRight(fullImage);
        }
    }
    int nrOfHashTags = 0;
    for (int i = 0; i<size(fullImage); i++){
        nrOfHashTags+=count(fullImage[i].begin(), fullImage[i].end(), 1);
    }

    int nrOfHashTagsNotPartOfSeaMonster = nrOfHashTags - nrOfSeaMonsters*15;

    cout << "Sea monsters: " <<  nrOfHashTagsNotPartOfSeaMonster<< endl;
    auto stop = chrono::high_resolution_clock::now();
    auto duration = chrono::duration_cast<chrono::milliseconds>(stop - start);
    cout << "Time: " << duration.count() << endl;
    //cout << "Result A: " << 0 << endl;
}