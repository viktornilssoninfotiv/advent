
def get_num(num, t, history):
    if num in history:
        t_h = history[num]
        return t - t_h
    else:
        return 0

def simulate_numbers(input, finish):
    # use dictionary to keep track of last occurences
    d = {}

    for i, n in enumerate(input):
        d[n] = i  

    start = len(input)
    last_num = input[-1]
    for t in range(start, finish):  
        t0 = t - 1 
        curr_num = get_num(last_num, t0, d)

        # update last occurence
        d[last_num] = t0

        last_num = curr_num
    
    return last_num


input = [0,6,1,7,2,19,20]

# part 1
print(simulate_numbers(input, finish = 2020))

# part 2
print(simulate_numbers(input, finish = 30000000))