using System.Xml;
using IS_Labs.Helpers;

namespace IS_Labs;

public static class XmlReadWithSaxApproach
{
    public static void Read(string filepath)
    {
        // konfiguracja początkowa dla XmlReadera
        var settings = new XmlReaderSettings
        {
            IgnoreComments = true,
            IgnoreProcessingInstructions = true,
            IgnoreWhitespace = true
        };

        var reader = XmlReader.Create(filepath, settings); // odczyt zawartości dokumentu
        reader.MoveToContent();

        var mpm = new MedicalProductsManager();

        while (reader.Read()) // analiza każdego z węzłów dokumentu
        {
            if (reader.NodeType != XmlNodeType.Element || reader.Name != "produktLeczniczy")
                continue;

            var form = reader.GetAttribute("postac")!;
            var commonName = reader.GetAttribute("nazwaPowszechnieStosowana")!;
            var entityResponsible = reader.GetAttribute("podmiotOdpowiedzialny")!;

            mpm.AddProduct(commonName, form, entityResponsible);
        }

        mpm.PrintMometasoniFuroasCount();
        mpm.PrintNumberOfProductsWithTheSameCommonNameButInDifferentForms();
        mpm.PrintEntitiesResponsibleWithMostCreamAndMostPills();
        mpm.PrintTopThreeEntitiesWithMostCreams();
    }
}