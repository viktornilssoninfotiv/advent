from data import data
import re

r = re.compile("(\w+) ([+-]\d+)")

def parse_command(line):
    m = r.findall(line)
    cmd, n = m[0]
    return cmd, int(n)

def find_infinite_loop(commands):
    has_executed = [False] * len(commands)

    acc = 0
    i = 0
    while i < len(commands):
        if has_executed[i]:
            return (i, acc)

        has_executed[i] = True

        c_i, n_i = commands[i]
        
        if c_i == 'acc':
            acc += n_i
            i += 1
        elif c_i == 'jmp':
            i += n_i
        elif c_i == 'nop':
            i += 1
        else:
            raise Exception("invalid command")
    
    return (i, acc)

def replace_command(commands):
    n = len(commands)
    mirror = {'jmp': 'nop', 'nop': 'jmp'}

    for i in range(n):        
        c_i, n_i = commands[i]
        if c_i != 'acc':
            commands_copy = commands.copy()
            commands_copy[i] = (mirror[c_i], n_i)
            
            res = find_infinite_loop(commands_copy)

            if res[0] == n: # program terminates, success
                return res

    return (0, 0) # failure

# load data
lines = data.split('\n')
commands = list(map(parse_command, lines))

# part 1
_, s1 = find_infinite_loop(commands)
print(s1)

# part 2
idx, s2 = replace_command(commands)
print(s2)