
# 

data = """##.#####
#.##..#.
.##...##
###.#...
.#######
##....##
###.###.
.#.#.#.."""

import numpy as np

size = 21 # grid expands at most 1 unit/cycle in each direction 
center = 10

grid_3d = np.zeros((size, size, size))
grid_4d = np.zeros((size, size, size, size))

inactive = 0
active = 1

init_slice = [[inactive if c == '.' else active for c in l] for l in data.split('\n')]

s0 = grid_3d[:, : ,center]
s0[center - 4 : center + 4, center - 4 : center + 4] = init_slice


def make_neighbors(dimension):
    if dimension < 1:
        return [[]]
    else:
        indices = [-1, 0, 1]
        return  [[i] + l for l in make_neighbors(dimension - 1) for i in indices]

def valid_coordinate(coord, size):
    return all(0 <= x < size for x in coord)

def count_neighbors(grid, coord, neighbors, size):
    num_active = 0

    for nb in neighbors:
        pp = [x + dx for x, dx in zip(coord, nb)]
        
        if valid_coordinate(pp, size):
            cube = grid[pp[0], pp[1], pp[2]]
            if cube == active:
                num_active += 1
    
    return num_active


# part 1

neighbors = make_neighbors(3)
neighbors.remove([0,0,0])

def simulate_cycle(grid, size):
    old_grid = grid.copy()

    # check all cubes
    for i in range(size):
        for j in range(size):
            for k in range(size):
                n_active = count_neighbors(old_grid, [i, j, k], neighbors, size)

                if old_grid[i, j, k] == active:
                    if not (n_active == 2 or n_active == 3):
                        grid[i, j, k] = inactive

                elif old_grid[i, j, k] == inactive:
                    if n_active == 3:
                        grid[i, j, k] = active


import time

t0 = time.time()
for _ in range(6):
    simulate_cycle(grid_3d, size)
t1 = time.time()

print('ran 3-D simulation in {} s'.format(t1 - t0))
sum(grid_3d.flatten() == active)


def count_neighbors_4d(grid, coord, neighbors, size):
    num_active = 0

    for nb in neighbors:
        pp = [x + dx for x, dx in zip(coord, nb)]
        
        if valid_coordinate(pp, size):
            cube = grid[pp[0], pp[1], pp[2], pp[3]]
            if cube == active:
                num_active += 1
    
    return num_active

neighbors = make_neighbors(4)
neighbors.remove([0, 0, 0, 0])

def simulate_cycle_4d(grid, size):
    old_grid = grid.copy()

    # check all cubes
    for i in range(size):
        for j in range(size):
            for k in range(size):
                for l in range(size):
                    n_active = count_neighbors_4d(old_grid, [i, j, k, l], neighbors, size)

                    if old_grid[i, j, k, l] == active:
                        if not (n_active == 2 or n_active == 3):
                            grid[i, j, k, l] = inactive

                    elif old_grid[i, j, k, l] == inactive:
                        if n_active == 3:
                            grid[i, j, k, l] = active



grid_4d = np.zeros((size, size, size, size))

inactive = 0
active = 1

init_slice = [[inactive if c == '.' else active for c in l] for l in data.split('\n')]
s0 = grid_4d[:, : ,center, center]
s0[center - 4 : center + 4, center - 4 : center + 4] = init_slice
# print(s0)

import time

t0 = time.time()
for _ in range(6):
    simulate_cycle_4d(grid_4d, size)
t1 = time.time()

print('ran 4-D simulation in {} s'.format(t1 - t0))
print(sum(grid_4d.flatten() == active))


