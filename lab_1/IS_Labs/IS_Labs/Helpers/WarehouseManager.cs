namespace IS_Labs.Helpers;

public class WarehouseManager
{
    private readonly Dictionary<string, WarehouseCount> _cities = new();
    private readonly Dictionary<string, WarehouseCount> _voivodeships = new();

    public void AddWarehouseToVoivodeship(string voivodeship, string status)
    {
        if (!_voivodeships.ContainsKey(voivodeship))
            _voivodeships.Add(voivodeship, new WarehouseCount());

        if (status.Equals("Aktywna"))
            _voivodeships[voivodeship].Active++;
        else
            _voivodeships[voivodeship].Inactive++;
    }

    public void AddWarehouseToCity(string city, string status)
    {
        if (!_cities.ContainsKey(city))
            _cities.Add(city, new WarehouseCount());

        if (status.Equals("Aktywna"))
            _cities[city].Active++;
        else
            _cities[city].Inactive++;
    }

    public void PrintAllVoivodeships()
    {
        foreach (var (voivodeship, warehouseCount) in _voivodeships)
        {
            var str = $"{voivodeship} [ aktywne: {warehouseCount.Active}, nieaktywne: {warehouseCount.Inactive} ]";
            Console.WriteLine(str);
        }
    }

    public void PrintVoivodeshipsWithMaxActiveAndInactiveWarehouses()
    {
        var voivodeshipWithMostActive = _voivodeships.MaxBy(pair => pair.Value.Active).Key;
        var voivodeshipWithMostInactive = _voivodeships.MaxBy(pair => pair.Value.Inactive).Key;
        Console.WriteLine($"Województwo z największą liczbą aktywnych hurtowni: {voivodeshipWithMostActive}");
        Console.WriteLine($"Województwo z największą liczbą nieaktywnych hurtowni: {voivodeshipWithMostInactive}");
    }

    public void PrintTopThreeCitiesWithMostActiveWarehouses()
    {
        var topThreeCities =
            (from entry in _cities orderby entry.Value.Active descending select entry).Take(3);

        Console.WriteLine("Trzy miasta, w których jest najwięcej aktywnych hurtowni:");
        foreach (var (city, warehouseCount) in topThreeCities)
        {
            var str = $"{city} [ aktywne: {warehouseCount.Active} ]";
            Console.WriteLine(str);
        }
    }
}