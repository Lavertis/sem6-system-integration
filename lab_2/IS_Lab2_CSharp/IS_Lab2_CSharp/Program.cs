using IS_Lab2_Extra;
using YamlDotNet.Serialization;

var file = new StreamReader("Assets/basic_config.yaml");
var deserializer = new DeserializerBuilder().Build();
var config = deserializer.Deserialize<dynamic>(file);

var jsonDeserializer = new JsonDeserializer(config["paths"]["source_folder"] + config["paths"]["json_source_file"]);

foreach (string action in config["actions"])
{
    switch (action)
    {
        case "some_stats":
            jsonDeserializer.SomeStats();
            break;
        case "show_number_of_offices":
            jsonDeserializer.NumberOfIndividualOfficesInEachVoivodeship();
            break;
        case "serialize":
            JsonSerializer.Run(jsonDeserializer.Data,
                config["paths"]["source_folder"] + config["paths"]["json_destination_file"]);
            break;
        case "convert":
            if (config["serialization_source"] == "file")
            {
                JsonToYamlConverter.Convert(
                    config["paths"]["source_folder"] + config["paths"]["json_source_file"],
                    config["paths"]["source_folder"] + config["paths"]["yaml_destination_file"]
                );
            }
            else if (config["serialization_source"] == "object")
            {
                JsonToYamlConverter.Convert(
                    jsonDeserializer.Data,
                    config["paths"]["source_folder"] + config["paths"]["yaml_destination_file"]
                );
            }

            break;
    }
}