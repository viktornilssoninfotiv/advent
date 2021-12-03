from file_reader import FileReader


class TestFileReader:
    def test_file_reader_to_list(self):
        data = FileReader.to_list("Day1/test_data.txt")
        expected = [199, 200, 208, 210, 200, 207, 240, 269, 260, 263]
        assert data == expected
