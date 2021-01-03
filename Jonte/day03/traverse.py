
# coding: utf-8

with open('data.txt') as f:
    lines = f.readlines()
    lines = [l.strip() for l in lines]

def traverse(tree_map, stride_x, stride_y):
    n = len(tree_map)
    m = len(tree_map[0])
    
    i = 0
    j = 0
    count = 0
    
    while i < n:
        curr = tree_map[i][j]
        
        if curr == '#':
            count += 1
        
        i += stride_x
        j =  (j + stride_y) % m
        
    return count

counts = [traverse(lines, *s) for s in [(1, 1), (1, 3), (1, 5), (1, 7), (2, 1)]]

# part 1
print(counts[1])

# part 2
product = 1
for c in counts:
    product *= c

print (product)