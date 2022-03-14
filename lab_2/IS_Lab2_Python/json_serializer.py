import json

from data_extractor import DataExtractor


class JsonSerializer:

    @staticmethod
    def run(deserialized_data, file_location):
        extracted_data = DataExtractor.extract(deserialized_data)

        json_temp = {"departaments": extracted_data}
        with open(file_location, 'w', encoding='utf-8') as f:
            json.dump(json_temp, f, ensure_ascii=False)
