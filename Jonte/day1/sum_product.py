
# coding: utf-8

with open('data.txt') as f:
    content = f.readlines()    
x = [int(x.strip()) for x in content]

prod = 2020

# part 1
for i in range(len(x)):
    for j in range(i, len(x)):
        if x[i] + x[j] == prod:
            print(x[i] * x[j])
            break

# part 2
for i in range(len(x)):
    for j in range(i, len(x)):
        for k in range(j, len(x)):
            if x[i] + x[j] + x[k] == prod:
                print(x[i] * x[j] * x[k])
                break