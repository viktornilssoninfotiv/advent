import re
from day2_data import data

pat = r"(\d+)-(\d+) ([a-z]): (.+)"


def magic(passwords):
    no_of_valid_passwords = 0
    handled_passwords = re.findall(pat, passwords)
    for lower, upper, letter, password in handled_passwords:
        count = password.count(letter)
        if int(lower) <= count <= int(upper):
            no_of_valid_passwords += 1

    return no_of_valid_passwords


print(magic(data))


def magic_part2(passwords):
    no_of_valid_passwords = 0
    handled_passwords = re.findall(pat, passwords)
    for lower, upper, letter, password in handled_passwords:
        if (password[int(lower)-1]+password[int(upper)-1]).count(letter) == 1:
            no_of_valid_passwords += 1

    return no_of_valid_passwords


print(magic_part2(data))
