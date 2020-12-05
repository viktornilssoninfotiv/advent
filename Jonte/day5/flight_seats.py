from data import data

seat_IDs = data.split('\n')

def row_num(seat_IDs):
    row_num = 0
    for i in range(7):
        s_i = seat_IDs[i]
        b = 0 if s_i == 'F' else 1
        row_num += 2 ** (6-i) * b
    
    col_num = 0    
    for i in range(7, 10):
        s_i = seat_IDs[i]
        b = 0 if s_i == 'L' else 1
        col_num += 2 ** (9-i) * b
        
    return row_num, col_num

IDs = sorted([8 * r + c for r, c in (row_num(seat_ID) for seat_ID in seat_IDs)])

# part 1
print(max(IDs))

# part 2
for i in range(len(IDs) - 1):
    if IDs[i + 1] - IDs[i] > 1:
        print(IDs[i] + 1)