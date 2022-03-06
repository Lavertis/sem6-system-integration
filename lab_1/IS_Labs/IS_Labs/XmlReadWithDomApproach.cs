using System.Xml;

namespace IS_Labs;

public static class XmlReadWithDomApproach
{
    public static void ReadMedicalProducts(string filepath)
    {
        var lekiZPostaciami = new Dictionary<string, HashSet<string>>();
        var doc = new XmlDocument();
        doc.Load(filepath);
        var mometasoniFuroasCount = 0;
        var drugs = doc.GetElementsByTagName("produktLeczniczy");

        foreach (XmlNode d in drugs)
        {
            var postac = d.Attributes!.GetNamedItem("postac")!.Value;
            var nazwaPowszechna = d.Attributes.GetNamedItem("nazwaPowszechnieStosowana")!.Value;
            if (postac == null || nazwaPowszechna == null)
                throw new Exception();

            if (postac == "Krem" && nazwaPowszechna == "Mometasoni furoas")
                mometasoniFuroasCount++;

            if (lekiZPostaciami.ContainsKey(nazwaPowszechna))
                lekiZPostaciami[nazwaPowszechna].Add(postac);
            else
                lekiZPostaciami.Add(nazwaPowszechna, new HashSet<string> {postac});
        }

        var str1 = "Liczba produktów leczniczych w postaci kremu, których jedyną substancją czynną jest " +
                   $"Mometasoni furoas: {mometasoniFuroasCount}";
        Console.WriteLine(str1);

        var sameNameDifferentFormCount = lekiZPostaciami.Values.Count(set => set.Count > 1);
        var str2 = "Liczba preparatów leczniczych o takiej samej nazwie powszechnej pod różnymi " +
                   $"postaciami: {sameNameDifferentFormCount}";
        Console.WriteLine(str2);
    }

    public static void ReadWarehouses(string filepath)
    {
        var doc = new XmlDocument();
        doc.Load(filepath);
        var warehouses = doc.GetElementsByTagName("Hurtownia");

        var voivodeships = new Dictionary<string, WarehouseCount>();

        foreach (XmlNode w in warehouses)
        {
            var status = w.Attributes!.GetNamedItem("status")!.Value!;
            var voivodeship = w.FirstChild!.Attributes!.GetNamedItem("wojewodztwo")!.Value!.ToUpper();

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