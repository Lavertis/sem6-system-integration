using System.Xml;
using IS_Labs.Helpers;

namespace IS_Labs;

public static class XmlReadWithDomApproach
{
    public static void Read(string filepath)
    {
        var doc = new XmlDocument();
        doc.Load(filepath);
        var drugs = doc.GetElementsByTagName("produktLeczniczy");

        var mpm = new MedicalProductsManager();

        foreach (XmlNode d in drugs)
        {
            var form = d.Attributes!.GetNamedItem("postac")!.Value;
            var commonName = d.Attributes.GetNamedItem("nazwaPowszechnieStosowana")!.Value;
            var entityResponsible = d.Attributes.GetNamedItem("podmiotOdpowiedzialny")!.Value;
            if (form == null || commonName == null || entityResponsible == null)
                throw new Exception();

            mpm.AddProduct(commonName, form, entityResponsible);
        }

        mpm.PrintMometasoniFuroasCount();
        mpm.PrintNumberOfProductsWithTheSameCommonNameButInDifferentForms();
        mpm.PrintEntitiesResponsibleWithMostCreamAndMostPills();
        mpm.PrintTopThreeEntitiesWithMostCreams();
    }
}