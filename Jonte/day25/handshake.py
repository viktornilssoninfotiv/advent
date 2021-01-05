
# AoC 2020 Day 25

def compute_key(subject_number, loop_size):
    val = 1
    denominator = 20201227

    for _ in range(loop_size):
        val = val * subject_number
        val = val % denominator
    
    return val

subject_number = 7
denominator = 20201227

def next_value(val):
    next_val = val * subject_number
    return next_val % denominator


# values for all loop sizes up to 1e8

max_size = 100000000
values = [1] * max_size

for i in range(1, max_size):
    values[i] = next_value(values[i - 1])

card_public_key = 2959251
door_public_key = 4542595

loop_size_card = next(i for i, v in enumerate(values) if v == card_public_key)
loop_size_door = next(i for i, v in enumerate(values) if v == door_public_key)

print(loop_size_card, loop_size_door)

encryption_key = compute_key(door_public_key, loop_size_card)
print(encryption_key)


