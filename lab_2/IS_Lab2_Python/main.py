import yaml

from json_deserializer import JsonDeserializer
from json_serializer import JsonSerializer
from json_to_yaml_converter import JsonToYamlConverter
from json_xml_converter import JsonToXmlConverter, XmlToJsonConverter


def serialize():
    JsonSerializer.run(
        newDeserializer.data,
        config['paths']['source_folder'] + config['paths']['json_destination_file']
    )


def convert_json_to_yaml():
    if config['serialization_source'] == 'file':
        JsonToYamlConverter.run(
            config['paths']['source_folder'] + config['paths']['json_source_file'],
            config['paths']['source_folder'] + config['paths']['yaml_destination_file']
        )
    elif config['serialization_source'] == 'object':
        JsonToYamlConverter.run(
            newDeserializer.data,
            config['paths']['source_folder'] + config['paths']['yaml_destination_file']
        )


config_file = open('Assets/basic_config.yaml', encoding="utf8")
config = yaml.load(config_file, Loader=yaml.FullLoader)

newDeserializer = JsonDeserializer(config['paths']['source_folder'] + config['paths']['json_source_file'])

actions = {
    'some_stats': newDeserializer.some_stats,
    'show_number_of_offices': newDeserializer.number_of_individual_offices_in_each_voivodeship,
    'serialize': serialize,
    'convert_json_to_yaml': convert_json_to_yaml
}

for action in config['actions']:
    actions[action]()

JsonToXmlConverter.convert(
    config['paths']['source_folder'] + config['paths']['json_source_file'],
    config['paths']['source_folder'] + config['paths']['xml_destination_file']
)

XmlToJsonConverter.convert(
    config['paths']['source_folder'] + config['paths']['xml_source_file'],
    config['paths']['source_folder'] + config['paths']['json_from_xml_file']
)
