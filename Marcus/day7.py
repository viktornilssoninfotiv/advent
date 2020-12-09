from day7_data import data

# part one

bags = dict()
for line in data.split('\n'):

    bag, content = line.split(' bags contain ')

    if content == "no other bags.":
        content = []

    else:
        content = [(c.strip().split(" ")[:-1]) for c in content.split(",")]
        content = [[" ".join(c[1:3]), c[0]] for c in content]

    bags[bag] = content

new_shiny_set = {'shiny gold'}
shiny_bags = set()

while new_shiny_set:

    old_shiny_set = new_shiny_set
    new_shiny_set = set()

    for bag, content in bags.items():
        for c in content:
            if c[0] in old_shiny_set:
                new_shiny_set.add(bag)

    shiny_bags = shiny_bags.union(new_shiny_set)

    for k in new_shiny_set:
        del bags[k]

print(len(shiny_bags - {'shiny gold'}))


# part two


def get_bag_count(bag):
    n = 0
    for b, k in bags[bag]:
        b_in = get_bag_count(b)
        n += int(k) * (1 + b_in)
    return n


print(get_bag_count("shiny gold"))
