namespace IS_Labs.Helpers;

public class MedicalProductsManager
{
    private readonly List<MedicalProduct> _medicalProducts = new();

    public void AddProduct(string? commonName = null, string? form = null,
        string? entityResponsible = null, int? activeSubstancesCount = null)
    {
        var product = new MedicalProduct
        {
            CommonName = commonName,
            Form = form,
            EntityResponsible = entityResponsible,
            ActiveSubstancesCount = activeSubstancesCount
        };
        _medicalProducts.Add(product);
    }

    public void PrintMometasoniFuroasCount()
    {
        var count = _medicalProducts.Count(p => p.CommonName!.Equals("Mometasoni furoas") && p.Form!.Equals("Krem"));
        var str1 = "Liczba produktów leczniczych w postaci kremu, których jedyną substancją czynną jest " +
                   $"Mometasoni furoas: {count}";
        Console.WriteLine(str1);
    }

    public void PrintNumberOfProductsWithTheSameCommonNameButInDifferentForms()
    {
        var medicalProductsByCommonName = new Dictionary<string, HashSet<string>>();
        foreach (var product in _medicalProducts)
        {
            if (medicalProductsByCommonName.ContainsKey(product.CommonName!))
                medicalProductsByCommonName[product.CommonName!].Add(product.Form!);
            else
                medicalProductsByCommonName.Add(product.CommonName!, new HashSet<string> {product.Form!});
        }

        var sameNameDifferentFormCount = medicalProductsByCommonName.Values.Count(set => set.Count > 1);
        var str2 = "Liczba preparatów leczniczych o takiej samej nazwie powszechnej pod różnymi " +
                   $"postaciami: {sameNameDifferentFormCount}";
        Console.WriteLine(str2);
    }

    public void PrintEntitiesResponsibleWithMostCreamAndMostPills()
    {
        var creamsCountByEntityResponsible = new Dictionary<string, int>();
        var pillsCountByEntityResponsible = new Dictionary<string, int>();

        foreach (var product in _medicalProducts)
        {
            switch (product.Form)
            {
                case "Krem":
                {
                    if (creamsCountByEntityResponsible.ContainsKey(product.EntityResponsible!))
                        creamsCountByEntityResponsible[product.EntityResponsible!]++;
                    else
                        creamsCountByEntityResponsible.Add(product.EntityResponsible!, 1);
                    break;
                }
                case { } f when f.ToUpper().Contains("TABLETKI"):
                {
                    if (pillsCountByEntityResponsible.ContainsKey(product.EntityResponsible!))
                        pillsCountByEntityResponsible[product.EntityResponsible!]++;
                    else
                        pillsCountByEntityResponsible.Add(product.EntityResponsible!, 1);
                    break;
                }
            }
        }

        var entityWithMostCreams = creamsCountByEntityResponsible.MaxBy(pair => pair.Value);
        var entityWithMostPills = pillsCountByEntityResponsible.MaxBy(pair => pair.Value);
        Console.WriteLine($"Entity responsible with most creams: {entityWithMostCreams}");
        Console.WriteLine($"Entity responsible with most pills: {entityWithMostPills}");
    }

    public void PrintTopThreeEntitiesWithMostCreams()
    {
        var creamsByEntityResponsible = new Dictionary<string, int>();

        foreach (var product in _medicalProducts)
        {
            if (product.Form!.Equals("Krem"))
            {
                if (creamsByEntityResponsible.ContainsKey(product.EntityResponsible!))
                    creamsByEntityResponsible[product.EntityResponsible!]++;
                else
                    creamsByEntityResponsible.Add(product.EntityResponsible!, 1);
            }
        }

        var topThreeEntitiesWithMostCreams =
            (from pair in creamsByEntityResponsible orderby pair.Value descending select pair).Take(3);
        Console.WriteLine("Entities responsible with most creams:");
        foreach (var entityPair in topThreeEntitiesWithMostCreams)
        {
            Console.WriteLine(entityPair);
        }
    }

    public void PrintNumberOfProductsWithOnlyOneActiveSubstanceAndWithMultipleActiveSubstances()
    {
        var oneActiveSubstanceCount = _medicalProducts.Count(p => p.ActiveSubstancesCount == 1);
        var multipleActiveSubstancesCount = _medicalProducts.Count(p => p.ActiveSubstancesCount > 1);
        Console.WriteLine($"Products with only one active substance: {oneActiveSubstanceCount}");
        Console.WriteLine($"Products with multiple active substances: {multipleActiveSubstancesCount}");
    }

    public void PrintNumberOfProductsWithEveryCountOfActiveSubstances()
    {
        var dict = new SortedDictionary<int, int>(); // number of active substances, number of products
        foreach (var product in _medicalProducts)
        {
            var activeSubstancesCount = product.ActiveSubstancesCount ?? -1;
            if (dict.ContainsKey(activeSubstancesCount))
                dict[activeSubstancesCount]++;
            else
                dict.Add(activeSubstancesCount, 1);
        }

        Console.WriteLine("Number of products by number of active substances:");
        foreach (var (activeSubstances, productCount) in dict)
        {
            Console.WriteLine($"{activeSubstances}: {productCount}");
        }
    }
}