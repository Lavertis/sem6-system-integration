using System.Xml;

namespace IS_Labs;

public static class XmlReadWithSaxApproach
{
    public static void ReadMedicalProducts(string filepath)
    {
        // konfiguracja początkowa dla XmlReadera
        var settings = new XmlReaderSettings
        {
            IgnoreComments = true,
            IgnoreProcessingInstructions = true,
            IgnoreWhitespace = true
        };

        var reader = XmlReader.Create(filepath, settings); // odczyt zawartości dokumentu
        reader.MoveToContent();
        var count = 0;

        var lekiZPostaciami = new Dictionary<string, HashSet<string>>();

        while (reader.Read()) // analiza każdego z węzłów dokumentu
        {
            if (reader.NodeType != XmlNodeType.Element || reader.Name != "produktLeczniczy")
                continue;

            var postac = reader.GetAttribute("postac")!;
            var nazwaPowszechna = reader.GetAttribute("nazwaPowszechnieStosowana")!;

            if (postac == "Krem" && nazwaPowszechna == "Mometasoni furoas")
                count++;

            if (lekiZPostaciami.ContainsKey(nazwaPowszechna))
                lekiZPostaciami[nazwaPowszechna].Add(postac);
            else
                lekiZPostaciami.Add(nazwaPowszechna, new HashSet<string> {postac});
        }

        var str1 = "Liczba produktów leczniczych w postaci kremu, których jedyną substancją czynną jest " +
                   $"Mometasoni furoas: {count}";
        Console.WriteLine(str1);

        var sameNameDifferentFormCount = lekiZPostaciami.Values.Count(set => set.Count > 1);
        var str2 = "Liczba preparatów leczniczych o takiej samej nazwie powszechnej pod różnymi " +
                   $"postaciami: {sameNameDifferentFormCount}";
        Console.WriteLine(str2);
    }

    public static void ReadWarehouses(string filepath)
    {
        // konfiguracja początkowa dla XmlReadera
        var settings = new XmlReaderSettings
        {
            IgnoreComments = true,
            IgnoreProcessingInstructions = true,
            IgnoreWhitespace = true
        };

        var reader = XmlReader.Create(filepath, settings); // odczyt zawartości dokumentu
        reader.MoveToContent();

        var voivodeships = new Dictionary<string, WarehouseCount>();

        while (reader.ReadState != ReadState.EndOfFile) // analiza każdego z węzłów dokumentu
        {
            while (reader.Read())
            {
                if (reader.NodeType == XmlNodeType.Element && reader.Name == "Hurtownia")
                    break;
            }

            var status = reader.GetAttribute("status");
            if (status == null)
                break;

            while (reader.Read())
            {
                if (reader.NodeType == XmlNodeType.Element && reader.Name == "Adres")
                    break;
            }

            var voivodeship = reader.GetAttribute("wojewodztwo")!.ToUpper();

            if (!voivodeships.ContainsKey(voivodeship))
                voivodeships.Add(voivodeship, new WarehouseCount());

            if (status.Equals("Aktywna"))
                voivodeships[voivodeship].Active++;
            else
                voivodeships[voivodeship].Inactive++;
        }

        var voivodeshipWithMostActive = voivodeships.MaxBy(pair => pair.Value.Active).Key;
        var voivodeshipWithMostInactive = voivodeships.MaxBy(pair => pair.Value.Inactive).Key;
        Console.WriteLine($"Voivodeship with most active warehouses: {voivodeshipWithMostActive}");
        Console.WriteLine($"Voivodeship with most inactive warehouses: {voivodeshipWithMostInactive}");

        // foreach (var (voivodeship, warehouseCount) in voivodeships)
        // {
        //     var str = $"{voivodeship} [ aktywne: {warehouseCount.Active}, nieaktywne: {warehouseCount.Inactive} ]";
        //     Console.WriteLine(str);
        // }
    }
}