from file_reader import FileReader


class SonarSweep:
    """Implementation for Day 1"""
    def __init__(self, file_name):
        self.depth_report = FileReader.to_float_list("../Day1/" + file_name)

    def count_depth_increases(self):
        increases = 0
        for i_depth in range(1, len(self.depth_report)):
            if self.depth_report[i_depth] > self.depth_report[i_depth - 1]:
                increases += 1
        return increases

    def count_depth_increases_3sum(self):
        increases = 0
        for i_depth in range(4, len(self.depth_report) + 1):
            # Obtain the sum of 3 elements
            current_sum = sum(self.depth_report[i_depth-3:i_depth])
            previous_sum = sum(self.depth_report[i_depth-4:i_depth-1])
            if current_sum > previous_sum:
                increases += 1
        return increases
