from day9_data import data

preamble_size = 25
xmas_code = list(map(int, data.split('\n')))


# part one
def check_if_next_number_is_valid(preamble, number):
    sorted_preamble = sorted(preamble)

    while len(sorted_preamble) > 1:

        if sorted_preamble[0] + sorted_preamble[-1] == number:
            return True

        elif sorted_preamble[0] + sorted_preamble[-1] < number:
            sorted_preamble.pop(0)

        else:
            sorted_preamble.pop()

    return False


def find_first_invalid(xmas):
    for i in range(preamble_size, len(xmas)):
        if not check_if_next_number_is_valid(xmas[i - preamble_size: i], xmas[i]):
            return xmas[i]


first_invalid_number = find_first_invalid(xmas_code)
print(first_invalid_number)


# part two
def find_contiguous_set(xmas, number):
    contiguous_set = []

    while sum(contiguous_set) != number:
        if sum(contiguous_set) < number:
            contiguous_set.append(xmas.pop(0))
        else:
            contiguous_set.pop(0)
    return contiguous_set


the_set = find_contiguous_set(xmas_code, first_invalid_number)
print(min(the_set) + max(the_set))
