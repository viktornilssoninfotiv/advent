
with open('data.txt') as f:
    lines = f.readlines()

time = int(lines[0].strip())
ids = [int(c) for c in lines[1].split(',') if c != 'x']

def wait_time(start_time, id):
    elapsed = start_time % id
    return id - elapsed if elapsed != 0 else 0 


# part 1


wait_times = [wait_time(time, id) for id in ids]

min_idx = wait_times.index(min(wait_times))
print(ids[min_idx] * wait_times[min_idx])


# part 2


def find_num(t1, c1, t2, c2):
    for i in range(1, 1000):
        n = c1 * i - t1
        if (n + t2) % c2 == 0:
            return n

def find_time(IDs):
    n, w = IDs[0]

    for t, c in IDs[1:]:
        n = find_num(-n, w, t, c)
        w = w * c
    
    return n

import time

ids = [(i, int(c)) for i, c in enumerate(lines[1].split(',')) if c != 'x']

t0 = time.time()

print(find_time(ids))

t1 = time.time()

print("fast search took {} microseconds".format((t1 - t0) * 1e6))

# tests

ids1 = [(0, 67), (1, 7), (2, 59), (3, 61)]
ids2 = [(0, 67), (2, 7), (3, 59), (4, 61)]
ids3 = [(0, 67), (1, 7), (3, 59), (4, 61)]
ids4 = [(0, 1789), (1, 37), (2, 47), (3, 1889)]

print(find_time(ids1))
print(find_time(ids2))
print(find_time(ids3))
print(find_time(ids4))


