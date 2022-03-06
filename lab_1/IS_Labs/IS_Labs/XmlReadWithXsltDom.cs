using System.Xml;
using System.Xml.XPath;
using IS_Labs.Helpers;

namespace IS_Labs;

public static class XmlReadWithXsltDom
{
    public static void ReadMedicalProducts(string filepath)
    {
        var document = new XPathDocument(filepath);
        var navigator = document.CreateNavigator();

        const string namespaceUri = "http://rejestrymedyczne.ezdrowie.gov.pl/rpl/eksport-danych-v1.0";
        var manager = new XmlNamespaceManager(navigator.NameTable);
        manager.AddNamespace("x", namespaceUri);

        var query = navigator.Compile("/x:produktyLecznicze/x:produktLeczniczy");
        query.SetContext(manager);
        var iterator = navigator.Select(query);

        var mpm = new MedicalProductsManager();

        while (iterator.MoveNext())
        {
            XPathNavigator iteratorCopy = iterator.Current!.Clone();
            XPathNodeIterator attributesIterator = iteratorCopy.Select("@*");

            var form = string.Empty;
            var commonName = string.Empty;

            while (attributesIterator.MoveNext())
            {
                switch (attributesIterator.Current!.Name)
                {
                    case "postac":
                        form = attributesIterator.Current.Value;
                        break;
                    case "nazwaPowszechnieStosowana":
                        commonName = attributesIterator.Current.Value;
                        break;
                }
            }

            mpm.AddProduct(commonName, form);
        }

        mpm.PrintMometasoniFuroasCount();
        mpm.PrintNumberOfProductsWithTheSameCommonNameButInDifferentForms();
    }

    public static void ReadWarehouses(string filepath)
    {
        var document = new XPathDocument(filepath);
        var navigator = document.CreateNavigator();

        const string namespaceUri = "http://rejestrymedyczne.csioz.gov.pl/rhf/eksport-danych-v1.0";
        var manager = new XmlNamespaceManager(navigator.NameTable);
        manager.AddNamespace("x", namespaceUri);

        var query = navigator.Compile("/x:Hurtownie/x:Hurtownia");
        query.SetContext(manager);
        var iterator = navigator.Select(query);

        var wm = new WarehouseManager();

        while (iterator.MoveNext())
        {
            XPathNavigator iteratorCopy = iterator.Current!.Clone();
            XPathNodeIterator attributesIterator = iteratorCopy.Select("@status");
            attributesIterator.MoveNext();
            var status = attributesIterator.Current!.Value;

            // Województwa
            iteratorCopy = iterator.Current!.Clone();
            var voivodeship = iteratorCopy.SelectSingleNode("./x:Adres/@wojewodztwo", manager)!.Value.ToUpper();
            wm.AddWarehouseToVoivodeship(voivodeship, status);

            // Miasta
            iteratorCopy = iterator.Current!.Clone();
            var city = iteratorCopy.SelectSingleNode("./x:Adres/@miejscowosc", manager)!.Value.ToUpper();
            wm.AddWarehouseToCity(city, status);
        }

        // wm.PrintAllVoivodeships();
        wm.PrintVoivodeshipsWithMaxActiveAndInactiveWarehouses();
        wm.PrintTopThreeCitiesWithMostActiveWarehouses();
    }
}