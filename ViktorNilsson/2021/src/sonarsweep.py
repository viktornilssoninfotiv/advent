from file_reader import FileReader


class SonarSweep:
    def __init__(self, file_name):
        self.depth_report = FileReader.to_list(file_name)

    def count_depth_increases(self):
        increases = 0
        for i_depth in range(1, len(self.depth_report)):
            if self.depth_report[i_depth] > self.depth_report[i_depth - 1]:
                increases += 1
        return increases
