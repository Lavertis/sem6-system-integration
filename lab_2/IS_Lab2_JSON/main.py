import yaml

from convert_json_to_yaml import ConvertJsonToYaml
from deserialize_json import DeserializeJson
from serialize_json import SerializeJson


def serialize():
    SerializeJson.run(
        newDeserializer.data,
        config['paths']['source_folder'] + config['paths']['json_destination_file']
    )


def convert():
    if config['serialization_source'] == 'file':
        ConvertJsonToYaml.run(
            config['paths']['source_folder'] + config['paths']['json_source_file'],
            config['paths']['source_folder'] + config['paths']['yaml_destination_file']
        )
    elif config['serialization_source'] == 'object':
        ConvertJsonToYaml.run(
            newDeserializer.data,
            config['paths']['source_folder'] + config['paths']['yaml_destination_file']
        )


config_file = open('Assets/basic_config.yaml', encoding="utf8")
config = yaml.load(config_file, Loader=yaml.FullLoader)

newDeserializer = DeserializeJson(config['paths']['source_folder'] + config['paths']['json_source_file'])

actions = {
    'dolnośląskie': newDeserializer.some_stats,
    'show_number_of_offices': newDeserializer.number_of_individual_offices_in_each_voivodeship,
    'serialize': serialize,
    'convert': convert
}

for action in config['actions']:
    actions[action]()
