import json
import xml.etree.ElementTree as ElementTree

from json2xml import json2xml

from data_extractor import DataExtractor


class XmlToJsonConverter:

    @staticmethod
    def convert(input_xml_file_path, output_json_file_path):
        tree = ElementTree.parse(input_xml_file_path)
        root = tree.getroot()

        extracted_json_data = DataExtractor.extract_from_xml(root.findall("item"))

        with open(output_json_file_path, 'w', encoding='utf-8') as f:
            json.dump(extracted_json_data, f, ensure_ascii=False)


class JsonToXmlConverter:

    @staticmethod
    def convert(input_json_file_path, output_xml_file_path):
        print("Json to Xml conversion")
        with open(input_json_file_path, 'r', encoding='utf-8') as f:
            deserialized_data = json.load(f)
        extracted_data = DataExtractor.extract_from_json(deserialized_data)

        xml_data = json2xml.Json2xml(extracted_data).to_xml()
        with open(output_xml_file_path, 'w', encoding='utf-8') as f:
            f.write(str(xml_data))
