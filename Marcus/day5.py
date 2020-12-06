from day5_data import data

# part 1

taken_seats = {}

for seat_id in data.split():

    row_characters = seat_id[0:7]
    column_characters = seat_id[7:]

    rows = list(range(0, 128))
    for char in row_characters:
        if char == 'F':
            rows = rows[:int(len(rows) / 2)]
        elif char == 'B':
            rows = rows[int((len(rows) / 2)):]

    columns = list(range(0, 8))
    for char in column_characters:
        if char == 'L':
            columns = columns[:int(len(columns) / 2)]
        elif char == 'R':
            columns = columns[int((len(columns) / 2)):]

    taken_seats[seat_id] = rows.pop() * 8 + columns.pop()


print(max(taken_seats.values()))


# part two

highest = max(taken_seats.values())
lowest = min(taken_seats.values())
print(set(range(lowest, highest + 1)) - set(taken_seats.values()))


