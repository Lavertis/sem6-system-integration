using Newtonsoft.Json;

namespace IS_Lab2_Extra;

public class JsonDeserializer
{
    public JsonDeserializer(string filePath)
    {
        using (var r = new StreamReader(filePath))
        {
            var json = r.ReadToEnd();
            Data = JsonConvert.DeserializeObject<List<Dictionary<string, object?>>>(json)!;
        }
    }

    public List<Dictionary<string, object?>> Data { get; set; }

    public void SomeStats()
    {
        var count = 0;

        foreach (var dep in Data)
        {
            if (dep["typ_JST"]!.ToString() == "GM" && dep["Województwo"]!.ToString() == "dolnośląskie")
                count++;
        }

        Console.WriteLine($"Liczba urzędów miejskich w województwie dolnośląskim: {count}");
    }

    public void NumberOfIndividualOfficesInEachVoivodeship()
    {
        var voivodeshipNames = new HashSet<string>();

        foreach (var dep in Data)
        {
            var voivodeshipName = dep["Województwo"]!.ToString()?.Trim();
            if (voivodeshipName != null)
                voivodeshipNames.Add(voivodeshipName);
        }

        var voivodeships = new Dictionary<string, Voivodeship>();

        foreach (var voivodeshipName in voivodeshipNames)
        {
            voivodeships.Add(voivodeshipName, new Voivodeship(voivodeshipName));
        }

        foreach (var dep in Data)
        {
            var jstType = dep["typ_JST"]!.ToString()?.Trim();
            var voivodeshipName = dep["Województwo"]!.ToString()!.Trim();

            switch (jstType)
            {
                case "GW":
                    voivodeships[voivodeshipName].GW += 1;
                    break;
                case "GMW":
                    voivodeships[voivodeshipName].GMW += 1;
                    break;
                case "MNP":
                    voivodeships[voivodeshipName].MNP += 1;
                    break;
                case "dzielnica":
                    voivodeships[voivodeshipName].dzielnica += 1;
                    break;
                case "W":
                    voivodeships[voivodeshipName].W += 1;
                    break;
                case "GM":
                    voivodeships[voivodeshipName].GM += 1;
                    break;
                case "P":
                    voivodeships[voivodeshipName].P += 1;
                    break;
            }
        }

        foreach (var voivodeship in voivodeships.Values)
        {
            Console.WriteLine(voivodeship);
        }
    }
}