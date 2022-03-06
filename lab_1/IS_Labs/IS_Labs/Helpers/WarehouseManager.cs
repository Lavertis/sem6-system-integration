namespace IS_Labs.Helpers;

public class WarehouseManager
{
    public readonly Dictionary<string, WarehouseCount> Cities = new();
    public readonly Dictionary<string, WarehouseCount> Voivodeships = new();

    public void AddWarehouseToVoivodeship(string voivodeship, string status)
    {
        if (!Voivodeships.ContainsKey(voivodeship))
            Voivodeships.Add(voivodeship, new WarehouseCount());

        if (status.Equals("Aktywna"))
            Voivodeships[voivodeship].Active++;
        else
            Voivodeships[voivodeship].Inactive++;
    }

    public void AddWarehouseToCity(string city, string status)
    {
        if (!Cities.ContainsKey(city))
            Cities.Add(city, new WarehouseCount());

        if (status.Equals("Aktywna"))
            Cities[city].Active++;
        else
            Cities[city].Inactive++;
    }

    public void PrintAllVoivodeships()
    {
        foreach (var (voivodeship, warehouseCount) in Voivodeships)
        {
            var str = $"{voivodeship} [ aktywne: {warehouseCount.Active}, nieaktywne: {warehouseCount.Inactive} ]";
            Console.WriteLine(str);
        }
    }

    public void PrintVoivodeshipsWithMaxActiveAndInactiveWarehouses()
    {
        var voivodeshipWithMostActive = Voivodeships.MaxBy(pair => pair.Value.Active).Key;
        var voivodeshipWithMostInactive = Voivodeships.MaxBy(pair => pair.Value.Inactive).Key;
        Console.WriteLine($"Województwo z największą liczbą aktywnych hurtowni: {voivodeshipWithMostActive}");
        Console.WriteLine($"Województwo z największą liczbą nieaktywnych hurtowni: {voivodeshipWithMostInactive}");
    }

    public void PrintTopThreeCitiesWithMostActiveWarehouses()
    {
        var topThreeCities =
            (from entry in Cities orderby entry.Value.Active descending select entry).Take(3);

        Console.WriteLine("Trzy miasta, w których jest najwięcej aktywnych hurtowni:");
        foreach (var (city, warehouseCount) in topThreeCities)
        {
            var str = $"{city} [ aktywne: {warehouseCount.Active} ]";
            Console.WriteLine(str);
        }
    }
}