from data import data

import re
regexpr_parent = r"(.+) bag"
regexpr_child = r"(\d+) (.+) bag"

def parse_line(line):
    # return list of tuples
    bag_match = re.findall(regexpr_parent, line[0]) 

    children = line[1].split(',')
    child_list = []
    for child in children:
        m = re.findall(regexpr_child, child)
        if m:
            child_list.append(m[0])        

    return (bag_match[0], child_list)

def build_tree(lines):
    d = dict()

    for l in lines:
        bag, bags = parse_line(l)
        d[bag] = bags

    return d

def has_bag(container_bag, query_bag, tree_dict):
    if not container_bag in tree_dict:
        return False

    bags = tree_dict[container_bag]
    bag_names = [s for _, s in bags]
    if query_bag in bag_names:
        return True

    # recursive call
    return any(has_bag(b, query_bag, tree_dict) for b in bag_names)

# read data and inititialize tree
lines = data.split('\n')
bag_data = [l.split(' contain ') for l in lines]
tree = build_tree(bag_data)

# part 1
print(sum([has_bag(bag, 'shiny gold', tree) for bag in tree]))

# part 2
def count_bags(query_bag, tree_dict):
    children = tree_dict[query_bag]
    return sum([int(num) * (1 + count_bags(name, tree_dict)) for num, name in children])

print(count_bags('shiny gold', tree))