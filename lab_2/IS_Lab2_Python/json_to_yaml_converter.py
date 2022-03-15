import json

import yaml
from multipledispatch import dispatch

from data_extractor import DataExtractor


class JsonToYamlConverter:

    @staticmethod
    @dispatch(str, str)
    def run(source_json_file_location, destination_yaml_file_location):
        print("Json to Yaml conversion (source_path, destination_path)")
        file = open(source_json_file_location, encoding="utf8")
        deserialized_data = json.load(file)
        extracted_data = DataExtractor.extract_from_json(deserialized_data)
        with open(destination_yaml_file_location, 'w', encoding='utf8') as f:
            yaml.dump(extracted_data, f, allow_unicode=True)

    @staticmethod
    @dispatch(list, str)
    def run(deserialized_data, destination_yaml_file_location):
        print("Json to Yaml conversion (deserialized_data, destination_path)")
        extracted_data = DataExtractor.extract_from_json(deserialized_data)
        with open(destination_yaml_file_location, 'w', encoding='utf8') as f:
            yaml.dump(extracted_data, f, allow_unicode=True)
