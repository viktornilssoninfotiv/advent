
from data import data
import re

lines = data.split('\n')

regex_mask = re.compile('mask = ([10X]+)')
regex_assignment = re.compile('mem\[(\d+)\] = (\d+)')


def parse_lines(lines):
    out = []

    assignments = []
    mask = ""

    for line in lines:
        m = regex_mask.match(line)
        if m:
            # append old
            out.append((mask, assignments))
            
            # reset
            mask, = m.groups()
            assignments = []
        else:
            m2 = regex_assignment.match(line)
            if m2:
                address, val = m2.groups()
                assignments.append((int(address), int(val)))        

    # append last element
    out.pop(0)
    out.append((mask, assignments))
    
    return out


# part 1 function

def apply_mask(mask, val):
    or_mask = ['1' if c == '1' else '0' for c in mask]
    and_mask = ['0' if c == '0' else '1' for c in mask]

    v = val | int(''.join(or_mask), 2)
    v = v & int(''.join(and_mask), 2)

    return v    


# part 2 functions

def float_combos(floats):
    if not floats:
        return [[]]
    
    tail = float_combos(floats[1:])
    head = floats[0]

    f = [[(head[0], False)] + ff for ff in tail]
    t = [[(head[0], True)] + ff for ff in tail]

    return f + t

def set_bit(val, idx, b):
    if b:
        return val | (1 << idx)
    else:
        return val & ~(1 << idx)

def set_bits(val, bits):
    for idx, b in bits:
       val = set_bit(val, idx, b)
    return val


def get_addresses(mask, address):
    # write 1s 
    or_mask = ['1' if c == '1' else '0' for c in mask]
    v = address | int(''.join(or_mask), 2)
    
    # apply floats
    fs = [(len(mask) - 1 - i, False) for i, c in enumerate(mask) if c =='X']
    bit_sets = float_combos(fs)

    return [set_bits(v, bs) for bs in bit_sets]


# part 1

commands = parse_lines(lines)

# flatten list of list:  [val for inner in outer for val in inner] 
addresses = [int(a) for _, assignments in commands for a, _ in assignments]
memory_buffer = [0] * (1 + max(addresses))

# write to memory
for mask, assignments in commands:
    for address, val in assignments:
        memory_buffer[address] = apply_mask(mask, val)

print(sum(memory_buffer))


# part 2 

memory_dict = {}

# write to memory
for mask, assignments in commands:
    for address, val in assignments:
        for float_address in get_addresses(mask, address):
            memory_dict[float_address] = val

print(sum([v for _, v in memory_dict.items()]))


# part 2 with test data

test_commands = [
    ('000000000000000000000000000000X1001X',
     [(42, 100)]),
    ('00000000000000000000000000000000X0XX',
     [(26, 1)])    
    ]

print("running part 2 with test data...")
memory_dict = {}

print("addresses:")
for mask, assignments in test_commands:
    for address, val in assignments:
        for float_address in get_addresses(mask, address):
            print(float_address)
            memory_dict[float_address] = val
            
print("sum:", sum([v for _, v in memory_dict.items()]))