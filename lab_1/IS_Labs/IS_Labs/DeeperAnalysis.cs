using System.Xml;
using IS_Labs.Helpers;

namespace IS_Labs;

public static class DeeperAnalysis
{
    public static void AnalyzeMedicalProducts(string filepath)
    {
        var doc = new XmlDocument();
        doc.Load(filepath);
        var drugs = doc.GetElementsByTagName("produktLeczniczy");

        var medicalProducts = new HashSet<MedicalProduct>();

        foreach (XmlNode d in drugs)
        {
            var form = d.Attributes!.GetNamedItem("postac")!.Value;
            var commonName = d.Attributes.GetNamedItem("nazwaPowszechnieStosowana")!.Value;
            var productName = d.Attributes.GetNamedItem("nazwaProduktu")!.Value;
            if (form == null || commonName == null || productName == null)
                throw new Exception();

            var activeSubstancesCount = d.ChildNodes.Item(0)!.ChildNodes.Count;

            var medicalProduct = new MedicalProduct
            {
                CommonName = commonName,
                Form = form,
                ActiveSubstancesCount = activeSubstancesCount
            };
            medicalProducts.Add(medicalProduct);
        }

        var oneActiveSubstanceCount = medicalProducts.Count(p => p.ActiveSubstancesCount == 1);
        var multipleActiveSubstancesCount = medicalProducts.Count(p => p.ActiveSubstancesCount > 1);
        Console.WriteLine($"Products with only one active substance: {oneActiveSubstanceCount}");
        Console.WriteLine($"Products with multiple active substances: {multipleActiveSubstancesCount}");
    }
}