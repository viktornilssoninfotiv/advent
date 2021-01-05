
# AoC 2020 Day 19 - Monster Messages

def map_value(val):
    if val == '"a"':
        return 'a'
    elif val == '"b"':
        return 'b'
    else:
        return int(val)


def parse_rule(rule):
    id, cs = rule.split(': ')
    or_list = cs.split(' | ')
    ll = [[map_value(val) for val in sublist] for sublist in (l.split(' ') for l in or_list)]
    return (int(id), ll)


def match(s, rule, rule_dict):
    """Returns all possible remainders of the string, s, after matching against rule.
    Returns [] if the rule doesn't match any prefix of s or [''] if the rule matches s completely.
    """

    # check base cases    
    if not s:
        return [] # string already consumed

    if rule == [['a']]:
        return [ s[1:] ] if s[0] == 'a' else []
    
    if rule == [['b']]:        
        return [ s[1:] ] if s[0] == 'b' else []

    all_suffixes = []

    for subrules in rule: # rule is list of options
        prefixes = [s]

        for subrule in subrules:
            prefixes = advance(prefixes, subrule, rule_dict)

        for p in prefixes:
            all_suffixes.append(p) 

    return all_suffixes


# auxiliary functions

def advance(prefixes, subrule, rule_dict):
    all_suffixes = []

    for prefix in prefixes:
        sub_suffixes = match(prefix, rule_dict[subrule], rule_dict)
        
        for suffix in sub_suffixes:
            all_suffixes.append(suffix)

    return all_suffixes


def is_valid(match):
    if match:
        if match[0] == '':
            return True
    return False


# to run part 1, change rule 8 and 11 in data

from data import data, test_data

rule_str, messages = data.split('\n\n')

rule_dict = {id: matches for id, matches in (parse_rule(r) for r in rule_str.split('\n'))}

import time

rule = rule_dict[0]

t0 = time.time()
print(sum(is_valid(m) for m in (match(mess, rule, rule_dict) for mess in messages.split('\n'))))
t1 = time.time()

print(t1 - t0)


# -------------- legacy code for part 1 --------------

def gen_valid_strings(or_list, rule_dict):
    # generate a list of all possible matches for a rule <- doesn't work for part 2
    
    if or_list == [['a']] or or_list == [['b']]:
        return or_list

    all_possible_matches = []

    for item in or_list:
        prefixes = [[]]

        for rule in item:
            suffixes = gen_valid_strings(rule_dict[rule], rule_dict)    

            new_prefixes = []

            # append all suffix lists to each prefix list  
            for p in prefixes:
                for s in suffixes:
                    new_prefixes.append(p + s)
                
            prefixes = new_prefixes

        
        for p in prefixes:
            all_possible_matches.append(p)

    return all_possible_matches