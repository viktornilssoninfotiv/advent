from data import data

seats = data.split('\n')

n_row = len(seats)
n_col = len(seats[0])

# pad seats with floor
seats = [['.', *s, '.'] for s in seats]
seats = [['.'] * (n_col + 2), *seats, ['.'] * (n_col + 2)]

neighbors = [
         (-1, -1), (0, -1), (1, -1),
         (-1,  0),          (1,  0),
         (-1,  1), (0,  1), (1,  1)
      ]

def change_empty(old_seats, i, j):
  return not any(old_seats[i+di][j+dj] == '#' for dj, di in neighbors)

def change_occupied(old_seats, i, j):
  return sum(old_seats[i+di][j+dj] == '#' for dj, di in neighbors) >= 4

def get_first(old_seats, i, j, direction):
  while (0 < i < n_row + 1) & (0 < j < n_col + 1):
    i += direction[0]
    j += direction[1]

    c = old_seats[i][j]
    if c != '.':
      return c

  # found nothing
  return '.' 

def change_empty_2(old_seats, i, j):
  return not any(get_first(old_seats, i, j, direction) == '#' for direction in neighbors)

def change_occupied_2(old_seats, i, j):
  return sum(get_first(old_seats, i, j, direction) == '#' for direction in neighbors) >= 5


def run_simulation(input_seats, change_empty_f, change_occupied_f):
  seats = [s.copy() for s in input_seats] # local copy

  iterations = 0
  changed = True

  while changed:
    changed = False
    old_seats = [s.copy() for s in seats]

    for i in range(1, n_row + 1):
      for j in range(1, n_col + 1):
        if old_seats[i][j] == 'L':
          if change_empty_f(old_seats, i, j):
            seats[i][j] = '#'
            changed = True
        elif old_seats[i][j] == '#':
          if (change_occupied_f(old_seats, i, j)):
            seats[i][j] = "L"
            changed = True

    iterations += 1

  count = 0
  for r in seats:
    for s in r:
      if s == '#':
        count += 1

  return (iterations, count)


# part 1
print(run_simulation(seats, change_empty, change_occupied))

# part 2
print(run_simulation(seats, change_empty_2, change_occupied_2))

