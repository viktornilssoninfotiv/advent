from day4_data import data
import re

data = [d.split() for d in data.split('\n\n')]

# part one
pattern = r"^(?=.*byr:)(?=.*iyr:)(?=.*eyr:)(?=.*hgt:)(?=.*hcl:)(?=.*ecl:)(?=.*pid:).*$"


def check_required_fields(passport):
    return not not re.fullmatch(pattern, " ".join(passport))


print(sum([check_required_fields(p) for p in data]))


# part two
def field_validation(field):
    key, value = field.split(':')

    if key == "byr":
        return 1920 <= int(value) <= 2002

    elif key == "iyr":
        return 2010 <= int(value) <= 2020

    elif key == "eyr":
        return 2020 <= int(value) <= 2030

    elif key == "hgt":
        if value[-2:] == "in" and 59 <= int(value[:-2]) <= 76:
            return True
        elif value[-2:] == "cm" and 150 <= int(value[:-2]) <= 193:
            return True
        else:
            return False

    elif key == "hcl":
        return re.fullmatch(r"^#[0-9a-f]{6}$", value) is not None

    elif key == "ecl":
        return value in {"amb", "blu", "brn", "grn", "gry", "hzl", "oth"}

    elif key == "pid":
        return not not re.findall('^[0-9]{9}$', value)

    else:
        return True


def validate_passport(passport):
    if check_required_fields(passport):
        for field in passport:
            if not field_validation(field):
                return False
        return True
    return False


print(sum([validate_passport(p) for p in data]))
