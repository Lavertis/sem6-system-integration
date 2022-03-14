using Newtonsoft.Json;

namespace IS_Lab2_Extra;

public static class JsonSerializer
{
    public static void Run(List<Dictionary<string, object?>> deserializedData, string filePath)
    {
        var extractedData = DataExtractor.Extract(deserializedData);
        var serializedList = JsonConvert.SerializeObject(new {departaments = extractedData});
        var path = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, @"..\..\..\", filePath));
        File.WriteAllText(path, serializedList);
    }
}