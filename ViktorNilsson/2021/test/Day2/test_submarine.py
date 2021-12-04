import unittest
from submarine import Submarine
from submarine import Command


class TestSubmarine(unittest.TestCase):
    """Test Cases for Day 2 class Submarine"""

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
        self.assertEqual(1938402, horizontal * depth)

    def test_get_position_trace(self):
        submarine = Submarine("test_data.txt")
        trace = submarine.get_position_trace()
        self.assertEqual(7, len(trace))

    def test_get_aim_position_trace(self):
        expected_trace = [(0, 0, 0), (5, 0, 0), (5, 0, 5), (13, 40, 5),
                          (13, 40, 2), (13, 40, 10), (15, 60, 10)]
        submarine = Submarine("test_data.txt")
        trace = submarine.get_aim_position_trace()
        for idx, trace_point in enumerate(trace):
            with self.subTest(i=idx):
                self.assertEqual(expected_trace[idx], trace_point)

    def test_get_aim_position(self):
        submarine = Submarine("input_data.txt")
        horizontal, depth = submarine.get_aim_position()
        self.assertEqual(1947878632, horizontal * depth)



if __name__ == '__main__':
    unittest.main()
