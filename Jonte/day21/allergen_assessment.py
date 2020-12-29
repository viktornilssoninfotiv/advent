
#

from data import data
import re

def parse_line(line):
    ingredients, allergens = line.split(' (contains ')
    return set(ingredients.split(' ')), set(allergens[:-1].split(', '))


lines = [parse_line(line) for line in data.split('\n')]

all_ingredients = {ingredient for ingredients, _ in lines for ingredient in ingredients}
all_allergens = {allergens for _, allergens in lines for allergens in allergens}


# find the sets of ingredients that always co-occur with each allergen

candidate_dictionary = dict()

for query_allergen in all_allergens:
    candidate_ingredients = all_ingredients.copy()
    
    for ingredients, allergens in lines:
        if query_allergen in allergens:
            candidate_ingredients = candidate_ingredients.intersection(ingredients)

    candidate_dictionary[query_allergen] = candidate_ingredients


# infer ingredients with uniquely co-occuring allergens

inferred_ingredients = dict()

while True:
    unique_ingredients = [item for item in candidate_dictionary.items() if len(item[1]) == 1]

    if not unique_ingredients:
        break
    else:        
        curr_allergen, curr_ingredient_set = unique_ingredients[0]
        curr_ingredient = curr_ingredient_set.pop()

        inferred_ingredients[curr_allergen] = curr_ingredient

        for _, val in candidate_dictionary.items():
            val = val.discard(curr_ingredient) 

        _ = candidate_dictionary.pop(curr_allergen)


known_allergens = {v for _, v in inferred_ingredients.items()}
safe = all_ingredients.difference(known_allergens)

# part 1

count = sum(sum(safe_ingredient in ingredients for safe_ingredient in safe) for ingredients, _ in lines)
print(count)

# part 2

sorted_pairs = sorted([(k, v) for k, v in inferred_ingredients.items()])
print(','.join([v for _, v in sorted_pairs]))


