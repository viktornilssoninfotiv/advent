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


def gen_valid_strings(or_list, rule_dict):
    if or_list == [['a']] or or_list == [['b']]:
        return or_list

    all_matches = []

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

        #
        for p in prefixes:
            all_matches.append(p)

    return all_matches


from data import data

rule_str, messages = data.split('\n\n')

rule_dict = {id: matches for id, matches in (parse_rule(r) for r in rule_str.split('\n'))}

# part 1

import time

t0 = time.time()
valid_strings = {''.join(s) for s in gen_valid_strings(rule_dict[0], rule_dict)}
t1 = time.time()

print(t1 - t0)

print(sum(m in valid_strings for m in messages.split('\n')))

