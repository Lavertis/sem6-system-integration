namespace IS_Labs.Helpers;

public class MedicalProductsManager
{
    private readonly Dictionary<string, HashSet<string>> _medicalProducts = new();
    private int _mometasoniFuroasCount;

    public void AddProduct(string commonName, string form)
    {
        if (form == "Krem" && commonName == "Mometasoni furoas")
            _mometasoniFuroasCount++;

        if (_medicalProducts.ContainsKey(commonName))
            _medicalProducts[commonName].Add(form);
        else
            _medicalProducts.Add(commonName, new HashSet<string> {form});
    }

    public void PrintNumberOfProductsWithTheSameCommonNameButInDifferentForms()
    {
        var sameNameDifferentFormCount = _medicalProducts.Values.Count(set => set.Count > 1);
        var str2 = "Liczba preparatów leczniczych o takiej samej nazwie powszechnej pod różnymi " +
                   $"postaciami: {sameNameDifferentFormCount}";
        Console.WriteLine(str2);
    }

    public void PrintMometasoniFuroasCount()
    {
        var str1 = "Liczba produktów leczniczych w postaci kremu, których jedyną substancją czynną jest " +
                   $"Mometasoni furoas: {_mometasoniFuroasCount}";
        Console.WriteLine(str1);
    }
}