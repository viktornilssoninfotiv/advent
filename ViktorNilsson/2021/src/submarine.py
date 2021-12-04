from dataclasses import dataclass

from file_reader import FileReader


class Submarine:
    """Implementation for Day 2"""
    def __init__(self, file_name):
        commands_raw = FileReader.to_list("../Day2/" + file_name)
        self.commands = []
        for row in commands_raw:
            current_command_raw = row.split(" ")
            command = Command(current_command_raw[0], int(current_command_raw[1]))
            self.commands.append(command)

    def get_position(self):
        trace = self.get_position_trace()
        horizontal, depth = trace[-1]
        return horizontal, depth

    def get_position_trace(self):
        # Set initial position
        horizontal = 0
        depth = 0

        # Save the data in a list
        trace = [(horizontal, depth)]
        for command in self.commands:
            match command.control:
                case "up":
                    depth -= command.amount
                case "down":
                    depth += command.amount
                case "forward":
                    horizontal += command.amount
            trace.append((horizontal, depth))
        return trace

    def get_aim_position_trace(self):
        # Set initial position
        horizontal = 0
        depth = 0
        aim = 0

        # Save the data in a list
        trace = [(horizontal, depth, aim)]
        for command in self.commands:
            match command.control:
                case "up":
                    aim -= command.amount
                case "down":
                    aim += command.amount
                case "forward":
                    horizontal += command.amount
                    depth += aim * command.amount
            trace.append((horizontal, depth, aim))
        return trace

    def get_aim_position(self):
        trace = self.get_aim_position_trace()
        horizontal, depth, aim = trace[-1]
        return horizontal, depth


@dataclass
class Command:
    """Helper class to hold components of a command"""
    control: str
    amount: int

    def __init__(self, control, amount):
        self.control = control
        self.amount = amount
