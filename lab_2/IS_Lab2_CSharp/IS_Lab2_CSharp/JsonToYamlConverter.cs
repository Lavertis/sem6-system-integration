using Newtonsoft.Json;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace IS_Lab2_Extra;

public static class JsonToYamlConverter
{
    public static void Convert(List<Dictionary<string, object?>> deserializedData, string outputFilePath)
    {
        Console.WriteLine("Json to Yaml conversion (deserialized_data, destination_path)");
        var extractedData = DataExtractor.Extract(deserializedData);
        var serializer = new SerializerBuilder()
            .WithNamingConvention(CamelCaseNamingConvention.Instance)
            .Build();
        var yaml = serializer.Serialize(extractedData);
        var path = Path.Combine(AppContext.BaseDirectory, @"..\..\..\", outputFilePath);
        File.WriteAllText(path, yaml);
    }

    public static void Convert(string inputFilePath, string outputFilePath)
    {
        Console.WriteLine("Json to Yaml conversion (source_path, destination_path)");
        List<Dictionary<string, object?>> deserializedData;
        using (var r = new StreamReader(inputFilePath))
        {
            var json = r.ReadToEnd();
            deserializedData = JsonConvert.DeserializeObject<List<Dictionary<string, object?>>>(json)!;
        }

        var extractedData = DataExtractor.Extract(deserializedData);

        var serializer = new SerializerBuilder()
            .WithNamingConvention(CamelCaseNamingConvention.Instance)
            .Build();
        var yaml = serializer.Serialize(extractedData);
        var path = Path.Combine(AppContext.BaseDirectory, @"..\..\..\", outputFilePath);
        File.WriteAllText(path, yaml);
    }
}