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


# 
import time
t0 = time.time()

# read data and inititialize tree
lines = data.split('\n')
bag_data = [l.split(' contain ') for l in lines]
tree = build_tree(bag_data)

t1 = time.time()

# part 1
print(sum([has_bag(bag, 'shiny gold', tree) for bag in tree]))

t2 = time.time()

# part 2
def count_bags(query_bag, tree_dict):
    children = tree_dict[query_bag]
    return sum([int(num) * (1 + count_bags(name, tree_dict)) for num, name in children])

print(count_bags('shiny gold', tree))

t3 = time.time()
print("execution time of building dict: {:0.2f} milliseconds".format((t1 - t0) * 1e3))
print("execution time of finding container bags: {:0.2f} milliseconds".format((t2 - t1) * 1e3))
print("execution time of counting bags: {:0.2f} microseconds".format((t3 - t2) * 1e6))