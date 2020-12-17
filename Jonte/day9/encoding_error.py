# To add a new cell, type '# %%'

with open('data.txt') as f:
    lines = f.readlines()
    lines = [l.strip() for l in lines]

def all_sums(i, n):
    sums = []
    for j in range(i - n, i):
        for k in range(j+1, i):
            sums.append(int(lines[j]) + int(lines[k]))
    return sums

# part 1

m = 25 

for i in range(m, len(lines)):
    if not int(lines[i]) in all_sums(i, m):
        magic = lines[i]
        print(i, ': ', magic)
        break


# part 2

numbers = [int(l) for l in lines]

def contiguous_sum(mynum):
    i = 0
    j = 0

    total = -1
    while True:
        total = sum(numbers[i:j])

        if total == mynum:
            break
        elif total > mynum:
            i += 1
        else:
            j += 1

    return (i, j, total)


i0, i1, total = contiguous_sum(int(magic))
print(min(numbers[i0:i1]) + max(numbers[i0:i1]))



