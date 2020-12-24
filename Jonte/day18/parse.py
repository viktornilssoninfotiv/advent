
# AoC 2020 operation order by j-o-eriksson

operators = {'+': lambda x, y: x + y,
             '-': lambda x, y: x - y,
             '*': lambda x, y: x * y}


def eval_rpn(cs):
    # evaluate expression in Reverse Polish Notation

    s = []

    for c in cs:
        if c.isdigit():
            s.append(int(c))
        else: # is operator
            a = s.pop()
            b = s.pop()
            f = operators[c]
            s.append(f(a, b))

    return s
            
def to_rpn(cs, precedence):
    # Dijkstra's shunting-yard algorithm

    operator_stack = []
    output_queue = []

    for c in cs:
        if c.isdigit():
           output_queue.append(c)
        elif c == '(':
            operator_stack.append(c)
        elif c == ')':
            while True:
                op = operator_stack.pop()
                if op == '(':
                    break
                else:
                    output_queue.append(op)

        else: # c is an operator
            while True:
                if not operator_stack:
                    break

                top = operator_stack[-1]
                if top == '(':
                    break

                if precedence[c] < precedence[top]:
                    break

                # if precedence is higher or the same
                output_queue.append(operator_stack.pop())
                
            operator_stack.append(c)
    
    while operator_stack:
        output_queue.append(operator_stack.pop())                 

    return ''.join(output_queue)


from data import data

expressions = data.split('\n')

def remove_whitespace(s):
    return ''.join(s.split())


# part 1

precedence_1 = {'+': 1, '-': 1, '*': 1}
print(sum(eval_rpn(to_rpn(remove_whitespace(e), precedence_1))[0] for e in expressions))

# part 2

precedence_2 = {'+': 1, '-': 1, '*': 2}
print(sum(eval_rpn(to_rpn(remove_whitespace(e), precedence_2))[0] for e in expressions))