
# AoC 2020 Jurassic Jigsaw

# ------------- part 1 auxiliary functions -------------

def rotate_90(edges):
    left, right, top, bottom = edges
    return [bottom, top, left[::-1], right[::-1]]


def flip(edges):
    left, right, top, bottom = edges
    return [right, left, top[::-1], bottom[::-1]]


def get_rotations(edges):
    edges90 = rotate_90(edges)
    edges180 = rotate_90(edges90)
    edges270 = rotate_90(edges180)
    return [edges, edges90, edges180, edges270]


def get_orientations(edges):
    flipped_edges = flip(edges)
    return get_rotations(edges) + get_rotations(flipped_edges)


def parse_tile(tile_str):
    id, im_str = tile_str.split(':\n')    
    im = im_str.split('\n')

    return int(id.split(' ')[1]), im


def get_edges(tile):
    left = ''.join([line[0] for line in tile])
    right = ''.join([line[-1] for line in tile])
    
    top = tile[0]
    bottom = tile[-1]
    
    edges = [left, right, top, bottom]
    redges = [''.join(reversed(edge)) for edge in edges]
    edge_IDs = ['left', 'right', 'top', 'bottom', 'rleft', 'rright', 'rtop', 'rbottom']

    return dict(zip(edges + redges, edge_IDs)) # TODO: no need for IDs


def get_edge_dict(tiles):    
    edge_dict = dict()

    for id, tile in tiles:
        edges = get_edges(tile)

        for edge, _ in edges.items():
            if edge in edge_dict:
                edge_dict[edge].add(id)
            else:
                edge_dict[edge] = {id}

    return edge_dict


def get_tile_dict(tiles):
    tile_dict = dict()

    for id, tile in tiles:
        edges = [edge for edge, _ in get_edges(tile).items()]
        tile_dict[id] = edges[:4]            
    
    return tile_dict


def build_jigsaw_puzzle(tile_dict, edge_dict):
    # edge order: 'left', 'right', 'top', 'bottom'    
    complementary_sides = [1, 0, 3, 2] # left -> right, right -> left, top->bottom, bottom->top
    directions = [(-1, 0), (1, 0), (0, -1), (0, 1)] # left, right, top, bottom 

    # initialize puzzle with 1 piece
    unplaced_tiles = tile_dict.copy()
    start_ID, start_edges = unplaced_tiles.popitem()
    
    puzzle = {start_ID: ((0, 0), 0)}
    puzzle_edges = dict(zip(start_edges, zip([(0, 0)] * 4, [0, 1, 2, 3])))
    
    while unplaced_tiles:
        # take edge and find matching tile
        puzzle_edge, edge_meta = next(iter(puzzle_edges.items()))
        pos, side = edge_meta

        dx, dy = directions[side]
        new_pos = (pos[0] +  dx, pos[1] + dy)

        if puzzle_edge in edge_dict:
            new_piece_set = edge_dict.pop(puzzle_edge)            
            new_piece_ID = new_piece_set.pop()

            if new_piece_ID in puzzle:
                if new_piece_set:
                    new_piece_ID = new_piece_set.pop()
                else: # outer edge of the puzzle
                    continue

            # find orientation that matches puzzle edge
            new_piece_edges = unplaced_tiles.pop(new_piece_ID)
            new_side = complementary_sides[side]
            transformed_edges, q = next((es, i) for i, es in enumerate(get_orientations(new_piece_edges))
                                                          if es[new_side] == puzzle_edge)

            # add tile to puzzle at the matched position            
            puzzle[new_piece_ID] = (new_pos, q)
            
            # for each matched tile edge: remove matched edges from edge_dict and puzzle_edges
            for i, edge in enumerate(transformed_edges):
                if edge in puzzle_edges: 
                    # remove all matched edges from list of puzzle edges
                    _ = puzzle_edges.pop(edge)
                else:
                    # orientation?
                    puzzle_edges[edge] = (new_pos, i)
        
        else:
            _ = puzzle_edges.pop(puzzle_edge)


    return puzzle, puzzle_edges


# ------------- part 2 auxiliary functions -------------

import numpy as np

def tile_to_matrix(tile):
    m = [[1 if c == '#' else 0 for c in line] for line in tile]
    return np.array(m)

def get_tile_rotations(tile):
    tile270 = np.rot90(tile)
    tile180 = np.rot90(tile270)
    tile90 = np.rot90(tile180)
    return [tile, tile90, tile180, tile270]

def flip_tile(tile):
    return np.rot90(tile.transpose(), k = 3)

def get_tile_orientations(tile):
    flipped_tile = flip_tile(tile)
    return get_tile_rotations(tile) + get_tile_rotations(flipped_tile)


def stitch_tiles(puzzle_grid, tiles, grid_size, tile_size):
    im = np.zeros((grid_size * tile_size, grid_size * tile_size))

    for i, row in enumerate(puzzle_grid):
        i_start = i * tile_size
        i_end = i_start + tile_size

        for j, tile_data in enumerate(row):
            id, q = tile_data
            tile = tile_to_matrix(tiles[id])

            j_start = j * tile_size
            j_end = j_start + tile_size

            tile_orientations = get_tile_orientations(tile)
            transformed_tile = tile_orientations[q]

            im[j_start:j_end, i_start:i_end] = transformed_tile[1 : -1, 1 : -1]

    return im


def find_sea_monster(im):
    monster = np.array([[0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0],
                        [1, 0, 0, 0, 0, 1, 1, 0, 0, 0, 0, 1, 1, 0, 0, 0, 0, 1, 1, 1],
                        [0, 1, 0, 0, 1, 0, 0, 1, 0, 0, 1, 0, 0, 1, 0, 0, 1, 0, 0, 0]])

    h, w = monster.shape
    h_im, w_im = im.shape

    len_monster = sum(monster.ravel())
    n_sea_monsters = 0

    for i in range(h_im - h):
        for j in range(w_im - w):
            m_ij = im[i : i + h, j : j + w] * monster
            if sum(m_ij.ravel()) == len_monster:
                n_sea_monsters += 1

    return n_sea_monsters


# load data and build puzzle

from data import data

tiles = [parse_tile(s) for s in data.split('\n\n')]
edge_dict = get_edge_dict(tiles)
tile_dict = get_tile_dict(tiles)

puzzle, puzzle_edges = build_jigsaw_puzzle(tile_dict, edge_dict)

x_pos = [pos[0][0] for _, pos in puzzle.items()]
y_pos = [pos[0][1] for _, pos in puzzle.items()]

size = max(y_pos) - min(y_pos) + 1
grid = [[0] * size for _ in range(size)]

for id, meta in puzzle.items():
    x, y = meta[0]
    grid[x - min(x_pos)][y - min(y_pos)] = (id, meta[1])


# part 1

print(grid[0][0][0] * grid[0][-1][0] * grid[-1][0][0] * grid[-1][-1][0])


# part 2 

puzzle_image = stitch_tiles(grid, dict(tiles), size, len(tiles[0][1]) - 2)

n_monsters = [find_sea_monster(im) for im in get_tile_orientations(puzzle_image)]
print(sum(puzzle_image.ravel()) - max(n_monsters) * 15)