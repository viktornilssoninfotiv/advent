import unittest
from sonarsweep import SonarSweep


class TestSonarSweep(unittest.TestCase):
    def test_simple_depth_input(self):
        sonar_sweep = SonarSweep("test_data.txt")
        increases = sonar_sweep.count_depth_increases()
        self.assertEqual(7, increases)

    def test_solve_day1_puzzle1(self):
        sonar_sweep = SonarSweep("input.txt")
        increases = sonar_sweep.count_depth_increases()
        print("Number of increases for Day 1 Puzzle 1: " + str(increases))
        self.assertEqual(1559, increases)


if __name__ == '__main__':
    unittest.main()
