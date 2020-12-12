from day10_data import example_2 as data

adaptor_list = list(map(int, data.split('\n')))


# part one
def get_joltage_differences(adaptors):
    adaptors.extend([0, max(adaptors) + 3])
    s = sorted(adaptors)
    z = zip(s[1:], s[:-1])
    d = list(map(lambda x: x[0] - x[1], z))

    return d


diff = get_joltage_differences(adaptor_list)
print(diff.count(1) * diff.count(3))


# Part two not working
def count_unnecessary_adaptors(adaptor_differences):
    the_string = "".join(map(str, adaptor_differences))
    combinations = 1
    for ones in the_string.split('3'):
        if len(ones) > 1:
            combinations *= (len(ones) - 1)
    return combinations


print(count_unnecessary_adaptors(diff))
