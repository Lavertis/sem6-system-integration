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

        var mpm = new MedicalProductsManager();

        foreach (XmlNode d in drugs)
        {
            var commonName = d.Attributes!.GetNamedItem("nazwaPowszechnieStosowana")!.Value;
            var form = d.Attributes!.GetNamedItem("postac")!.Value;
            if (form == null || commonName == null)
                throw new Exception();

            var activeSubstancesCount = d.FirstChild!.ChildNodes.Count;
            mpm.AddProduct(commonName, form, activeSubstancesCount: activeSubstancesCount);
        }

        mpm.PrintNumberOfProductsWithOnlyOneActiveSubstanceAndWithMultipleActiveSubstances();
        mpm.PrintNumberOfProductsWithEveryCountOfActiveSubstances();
    }
}