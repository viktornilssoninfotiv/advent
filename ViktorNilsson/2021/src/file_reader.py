class FileReader:
    @classmethod
    def to_float_list(cls, file_name):
        file_list = cls.to_list(file_name)
        # Use list comprehension to convert tu numeric values
        number_list = [float(i) for i in file_list]
        return number_list

    @classmethod
    def to_list(cls, file_name):
        file = open(file_name, "r", encoding="utf-8")
        file_data = file.read()
        file_list = file_data.split("\n")
        file.close()
        return file_list
