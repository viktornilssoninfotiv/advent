
# 

from data import data
import re

def parse_rules(rules_str):
    rules_regex = re.compile('([\w ]+): (\d+)-(\d+) or (\d+)-(\d+)')
    matches =  rules_regex.findall(rules_str)
    return [(id, (int(lb0), int(ub0) + 1), (int(lb1), int(ub1) + 1))
            for id, lb0, ub0, lb1, ub1 in matches]

def check_value(val, rules):    
    return any(val in range(*r0) or val in range(*r1) for _, r0, r1 in rules)

def error_rate(ticket, rules):
    invalid_values = (val for val in ticket if not check_value(val, rules))
    return sum(invalid_values)

def is_valid(ticket, rules):
    return all(check_value(val, rules) for val in ticket)


# load data

rules_str, my_ticket, nearby_tickets = data.split('\n\n')
rules = parse_rules(rules_str)

_, *ticket_strings = nearby_tickets.split('\n')
tickets = [[int(n) for n in t] for t in (ts.split(',') for ts in ticket_strings)]

_, my_ticket_str = my_ticket.split('\n')
my_ticket_values = [int(s) for s in my_ticket_str.split(',')]


# part 1

print(sum(error_rate(ticket, rules) for ticket in tickets))


# part 2

valid_tickets = [t for t in tickets if is_valid(t, rules)]

unassigned_fields = dict()
inferred_fields = dict()

for id, *_ in rules:
    unassigned_fields[id] = set()

for rule in rules:
    for i in range(len(tickets[0])):
        if all(check_value(t[i], [rule]) for t in valid_tickets):
            unassigned_fields[rule[0]].add(i)

while unassigned_fields:
    # find the element with only one possible field 
    field_id, curr_set = next(x for x in unassigned_fields.items() if len(x[1]) == 1)
    curr_index = curr_set.pop()

    inferred_fields[field_id] = curr_index
    for ids, possible_indices in unassigned_fields.items():
        possible_indices.discard(curr_index)

    _ = unassigned_fields.pop(field_id)

departure_field_indices = [idx for id, idx in inferred_fields.items() if 'departure' in id] 

_, my_ticket_str = my_ticket.split('\n')
my_ticket_values = [int(s) for s in my_ticket_str.split(',')]

# math.prod unavailable before Python 3.8
prod = 1 
for i in departure_field_indices:
    prod *= my_ticket_values[i]
print(prod)