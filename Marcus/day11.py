from day11_data import data

seat_layout = [list(d) for d in data.split('\n')]

w = len(seat_layout[0])
h = len(seat_layout)


def get_number_of_adjacent_occupied_seats(layout, seat_y, seat_x):
    adj_seats_offsets = [(-1, -1), (-1, 0), (-1, 1), (0, -1), (0, 1), (1, -1), (1, 0), (1, 1)]
    adj_seats = [layout[y + seat_y][x + seat_x] for y, x in adj_seats_offsets if
                 0 <= y + seat_y < h and 0 <= x + seat_x < w]

    return adj_seats.count('#')


def update_until_stable(layout):
    new_layout = [row.copy() for row in layout]
    updated = False

    for y, seat_row in enumerate(layout):
        for x, seat in enumerate(seat_row):
            if seat == 'L' and get_number_of_adjacent_occupied_seats(layout, y, x) == 0:
                new_layout[y][x] = '#'
                updated = True
            elif seat == '#' and get_number_of_adjacent_occupied_seats(layout, y, x) >= 4:
                new_layout[y][x] = 'L'
                updated = True
            else:
                pass

    if updated:
        return update_until_stable(new_layout)

    return new_layout


print(sum(d.count('#') for d in update_until_stable(seat_layout)))


def get_number_of_visible_occupied_seats(layout, seat_y, seat_x):
    directions = [(-1, -1), (-1, 0), (-1, 1), (0, -1), (0, 1), (1, -1), (1, 0), (1, 1)]
    seen_occupied_seats = 0

    for direction in directions:
        y, x = map(int.__add__, (seat_y, seat_x), direction)

        while 0 <= y < h and 0 <= x < w:
            if layout[y][x] == '#':
                seen_occupied_seats += 1
                break
            elif layout[y][x] == 'L':
                break
            y, x = map(int.__add__, (y, x), direction)

    return seen_occupied_seats


def update_until_stable_v2(layout):
    new_layout = [row.copy() for row in layout]
    updated = False

    for y, seat_row in enumerate(layout):
        for x, seat in enumerate(seat_row):
            if seat == 'L' and get_number_of_visible_occupied_seats(layout, y, x) == 0:
                new_layout[y][x] = '#'
                updated = True
            elif seat == '#' and get_number_of_visible_occupied_seats(layout, y, x) >= 5:
                new_layout[y][x] = 'L'
                updated = True
            else:
                pass

    if updated:
        return update_until_stable_v2(new_layout)

    return new_layout


print(sum(d.count('#') for d in update_until_stable_v2(seat_layout)))
