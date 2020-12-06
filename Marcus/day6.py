from day6_data import data


# part one

print(sum([len(set(g)-set("\n")) for g in data.split("\n\n")]))


# part two

new_answers = 0


def get_common_yeses(group):
    sets = list(map(set, group.split()))
    return len(set.intersection(*sets))


print(sum([get_common_yeses(group) for group in data.split("\n\n")]))




