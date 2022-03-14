namespace IS_Lab2_Extra;

public static class DataExtractor
{
    public static List<dynamic> Extract(List<Dictionary<string, object?>> deserializedData)
    {
        var lst = new List<dynamic>();

        foreach (var rawDep in deserializedData)
        {
            var dep = rawDep
                .Select(pair => new KeyValuePair<string, string?>(pair.Key, pair.Value?.ToString()?.Trim()))
                .ToDictionary(pair => pair.Key, pair => pair.Value);

            var entry = new
            {
                Kod_TERYT = dep["Kod_TERYT"],
                Województwo = dep["Województwo"],
                Powiat = dep["Powiat"],
                typ_JST = dep["typ_JST"],
                nazwa_urzędu_JST = dep["nazwa_urzędu_JST"],
                miejscowość = dep["miejscowość"],
                telefon_z_numerem_kierunkowym = dep["telefon kierunkowy"] + '-' + dep["telefon"]
            };
            lst.Add(entry);
        }

        return lst;
    }
}