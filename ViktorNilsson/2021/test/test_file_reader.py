import unittest
from file_reader import FileReader


class TestFileReader(unittest.TestCase):
    """Test cases for the helper class that reads files"""
    def test_file_reader_to_float_list(self):
        data = FileReader.to_float_list("../Day1/test_data.txt")
        expected = [199, 200, 208, 210, 200, 207, 240, 269, 260, 263]
        self.assertEqual(expected, data)

    def test_file_reader_to_list(self):
        data = FileReader.to_list("../Day1/test_data.txt")
        expected = "199, 200, 208, 210, 200, 207, 240, 269, 260, 263".split(", ")
        self.assertEqual(expected, data)
