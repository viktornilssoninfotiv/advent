import unittest
from submarine import Submarine
from submarine import Command


class TestSubmarine(unittest.TestCase):
    def test_command_list(self):
        submarine = Submarine("test_data.txt")
        command = submarine.commands[1]
        self.assertIsInstance(command, Command)
        self.assertEqual(6, len(submarine.commands))

    def test_command(self):
        command = Command("forward", 5)
        self.assertEqual("forward", command.control)
        self.assertEqual(5, command.amount)

    def test_get_position(self):
        submarine = Submarine("test_data.txt")
        horizontal, depth = submarine.get_position()
        self.assertEqual(15, horizontal)
        self.assertEqual(10, depth)

    def test_solve_day2_puzzle1(self):
        submarine = Submarine("input_data.txt")
        horizontal, depth = submarine.get_position()
        self.assertEqual(1938402, horizontal* depth)


if __name__ == '__main__':
    unittest.main()
