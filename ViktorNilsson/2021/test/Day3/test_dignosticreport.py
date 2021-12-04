import unittest
import numpy as np
from diagnostic_report import DiagnosticReport


class TestDiagnosticReport(unittest.TestCase):
    """Tests for Day 3"""
    def test_get_most_common_bits(self):
        diagnostic_report = DiagnosticReport("test_data.txt")
        most_common = diagnostic_report.get_most_common_bits()
        self.assertEqual([1, 0, 1, 1, 0], most_common)

    def test_get_bit_array(self):
        array = DiagnosticReport.to_bit_array(["101", "010"])
        expected = np.array([[1, 0, 1], [0, 1, 0]])
        self.assertTrue(np.array_equal(expected, array))

    def test_to_bit_row(self):
        row = DiagnosticReport.to_bit_row("101")
        self.assertEqual([1, 0, 1], row)


if __name__ == '__main__':
    unittest.main()
