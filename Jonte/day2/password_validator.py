# coding: utf-8

import re

def read_file(filename):
    with open(filename) as f:
        content = f.readlines()        
    return content

data = read_file("data.txt")
reg_exp = r"(\d+)-(\d+) (\w): (\w+)" 

# part 1
def check_reg_match(m):
    lower_bound = int(m[1])
    upper_bound = int(m[2])
    
    return lower_bound <= m[4].count(m[3]) <= upper_bound

print(sum([check_reg_match(m) for m in (re.match(reg_exp, d) for d in data)]))

# part 2
def check_reg_match_2(m):
    first = int(m[1]) - 1
    second = int(m[2]) - 1
    char = m[3]
    password = m[4]
    
    return sum([password[first] == char, password[second] == char]) == 1

print(sum([check_reg_match_2(m) for m in (re.match(reg_exp, d) for d in data)]))