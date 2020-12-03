from day3_data import data


# part one and two
def slope(right, down):
    line_nr = 0
    position = 0
    trees = 0

    for line in data.split():
        if not line_nr % down:
            if position >= len(line):
                position -= len(line)

            if line[position] == "#":
                trees += 1
            position += right
        line_nr += 1
    return trees


s1 = slope(1, 1)
s2 = slope(3, 1)
s3 = slope(5, 1)
s4 = slope(7, 1)
s5 = slope(1, 2)

print("Part 1: " + str(s2))
print("Part 2: " + str(s1*s2*s3*s4*s5))
