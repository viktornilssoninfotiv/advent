from day8_data import data

# create data structure
code_lines = [(l[0:3], l[4:5] == '+', int(l[5:])) for l in data.split("\n")]


# part 1
def program_runner(code, modified_line=None):
    visited_lines = []

    current_line = 0
    accumulator = 0

    while current_line not in visited_lines:

        visited_lines.append(current_line)
        instruction, add, value = code[current_line]

        if modified_line == current_line:  # part 2
            instruction = "nop" if instruction == "jmp" else "jmp"

        if instruction == "nop":
            current_line += 1

        elif instruction == "jmp":
            current_line = current_line + value if add else current_line - value

        else:
            accumulator = accumulator + value if add else accumulator - value
            current_line += 1

        if current_line >= len(code):
            return True, accumulator

    return False, accumulator


print(program_runner(code_lines)[1])


# part 2
def program_fixer(code):
    for i in range(0, len(code)):
        if code[i][0] in {"nop", "jmp"}:
            result, acc = program_runner(code, i)
            if result:
                return acc


print(program_fixer(code_lines))
