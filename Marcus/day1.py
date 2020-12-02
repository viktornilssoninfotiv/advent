from day1_data import data


def magic(numbers):
    while numbers:
        n = numbers.pop(0)
        for i in numbers:
            if n + i == 2020:
                return "ding ding ding!", n, i, n*i


print(magic(data))


def magic_p2(numbers):
    while numbers:
        n = numbers.pop(0)
        for i in numbers:
            for j in numbers[numbers.index(i):-1]:
                if n + i + j == 2020:
                    return "ding ding ding!", n, i, j, n*i*j


print(magic_p2(data))
