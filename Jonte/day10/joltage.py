from data import data
import numpy as np
import time

def find_paths(jolt_list):
    paths = []

    for i in range(len(jolt_list)):
        n_i = jolt_list[i]
        p_i = [j for j, node in enumerate(jolt_list[:i]) if n_i - node <= 3]
        paths.append(p_i)
        
    return paths

def fast_count(paths):
    num_paths = [1] * len(paths)

    for i in range(1, len(paths)):
        p_i = paths[i]
        num_paths[i] = sum(num_paths[j] for j in p_i)

    return num_paths[-1]


joltages = sorted(list(map(int, data.split('\n'))))
joltages = [0, *joltages, max(joltages) + 3]

# part 1
dj = np.diff(joltages)
print(sum(dj == 1) * sum(dj == 3))

t0 = time.time()

# part 2
paths = find_paths(joltages)
print(fast_count(paths))

t1 = time.time()
print("counted paths in {:0.0f} microseconds".format((t1 - t0) * 1e6))