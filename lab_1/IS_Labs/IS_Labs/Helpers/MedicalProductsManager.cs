namespace IS_Labs.Helpers;

public class MedicalProductsManager
{
    public readonly Dictionary<string, HashSet<string>> MedicalProducts = new();
    public int MometasoniFuroasCount;

    public void AddProduct(string commonName, string form)
    {
        if (form == "Krem" && commonName == "Mometasoni furoas")
            MometasoniFuroasCount++;

        if (MedicalProducts.ContainsKey(commonName))
            MedicalProducts[commonName].Add(form);
        else
            MedicalProducts.Add(commonName, new HashSet<string> {form});
    }

    public void PrintNumberOfProductsWithTheSameCommonNameButInDifferentForms()
    {
        var sameNameDifferentFormCount = MedicalProducts.Values.Count(set => set.Count > 1);
        var str2 = "Liczba preparatów leczniczych o takiej samej nazwie powszechnej pod różnymi " +
                   $"postaciami: {sameNameDifferentFormCount}";
        Console.WriteLine(str2);
    }

    public void PrintMometasoniFuroasCount()
    {
        var str1 = "Liczba produktów leczniczych w postaci kremu, których jedyną substancją czynną jest " +
                   $"Mometasoni furoas: {MometasoniFuroasCount}";
        Console.WriteLine(str1);
    }
}