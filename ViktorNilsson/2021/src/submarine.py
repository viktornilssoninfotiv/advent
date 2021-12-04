from dataclasses import dataclass

from file_reader import FileReader


class Submarine:
    """Implementation for Day 2"""
    def __init__(self, file_name):
        commands_raw = FileReader.to_list(file_name)
        self.commands = []
        for row in commands_raw:
            current_command_raw = row.split(" ")
            command = Command(current_command_raw[0], int(current_command_raw[1]))
            self.commands.append(command)

    def get_position(self):
        horizontal = 0
        depth = 0
        for command in self.commands:
            match command.control:
                case "up":
                    depth -= command.amount
                case "down":
                    depth += command.amount
                case "forward":
                    horizontal += command.amount
        return horizontal, depth


@dataclass
class Command:
    """Helper class to hold components of a command"""
    control: str
    amount: int

    def __init__(self, control, amount):
        self.control = control
        self.amount = amount
