
from data import data

directions = {'N': (0, -1), 'E': (1, 0), 'S': (0, 1), 'W': (-1, 0)}
directions_pi2 = [(0, -1), (1, 0), (0, 1), (-1, 0)]

def parse_command(cmd, old_pos, old_dir):
    c = cmd[0]
    val = int(cmd[1:])

    if c == 'R':
        dir = (old_dir + int(val / 90)) % 4
        return old_pos, dir
    elif c== 'L':
        dir = ( old_dir + (4 - int(val / 90)) ) % 4
        return old_pos, dir
    elif c == 'F':
        dir = directions_pi2[old_dir]
        pos = (old_pos[0] + val * dir[0], old_pos[1] + val * dir[1])
        return pos, old_dir
    else:
        dir = directions[c]
        pos = (old_pos[0] + val * dir[0], old_pos[1] + val * dir[1])
        return pos, old_dir

def rotate_0(p):
    return p

def rotate_pi2(p):
    return (-p[1], p[0])

def rotate_pi(p):
    return (-p[0], -p[1])    

def rotate_3pi2(p):
    return (p[1], -p[0]) 

rotations = [rotate_0, rotate_pi2, rotate_pi, rotate_3pi2]

def parse_command_2(cmd, pos, waypoint):
    c = cmd[0]
    val = int(cmd[1:])

    if c == 'R':
        f = rotations[int(val / 90)]
        new_waypoint = f(waypoint)
        return pos, new_waypoint
    elif c== 'L':
        f = rotations[((4 - int(val / 90)) % 4)] # modulo if L0 exists
        new_waypoint = f(waypoint)
        return pos, new_waypoint
    elif c == 'F':
        new_pos = (pos[0] + val * waypoint[0], pos[1] + val * waypoint[1])
        return new_pos, waypoint
    else:
        dir = directions[c]
        new_waypoint = (waypoint[0] + val * dir[0], waypoint[1] + val * dir[1])
        return pos, new_waypoint


# part 1

curr_dir = 1 # east
curr_pos = (0, 0)

for l in data.split('\n'):
    curr_pos, curr_dir = parse_command(l, curr_pos, curr_dir)
print(abs(curr_pos[0]) + abs(curr_pos[1]))

# part 2

waypoint = (10, -1)
pos = (0, 0)

for l in data.split('\n'):
    pos, waypoint = parse_command_2(l, pos, waypoint)

print(abs(pos[0]) + abs(pos[1]))


