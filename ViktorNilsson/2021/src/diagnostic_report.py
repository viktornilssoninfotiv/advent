import numpy as np
from file_reader import FileReader


class DiagnosticReport:
    """Implementation for Day 3"""

    def __init__(self, file_name):
        report_raw = FileReader.to_list("../Day3/" + file_name)

        # Parse the string data into a multi-dim int array.
        # This to simplify extraction of columns to get most common bits
        self.report = self.to_bit_array(report_raw)

    @classmethod
    def to_bit_row(cls, bit_string):
        bit_split = list(bit_string)
        bit_row = list(map(int, bit_split))

        return bit_row

    @classmethod
    def to_bit_array(cls, bit_string_list):
        # Initialize the array based on row length and number of rows
        columns = len(bit_string_list[0])
        rows = len(bit_string_list)
        report = np.empty([rows, columns], dtype=int)

        for idx, row in enumerate(bit_string_list):
            report[idx] = cls.to_bit_row(row)

        return report

    def get_most_common_bits(self):
        return self.report[0]
