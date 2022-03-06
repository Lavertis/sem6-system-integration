using System.Xml;
using IS_Labs.Helpers;

namespace IS_Labs;

public static class XmlReadWithDomApproach
{
    public static void ReadMedicalProducts(string filepath)
    {
        var doc = new XmlDocument();
        doc.Load(filepath);
        var drugs = doc.GetElementsByTagName("produktLeczniczy");

        var mpm = new MedicalProductsManager();

        foreach (XmlNode d in drugs)
        {
            var form = d.Attributes!.GetNamedItem("postac")!.Value;
            var commonName = d.Attributes.GetNamedItem("nazwaPowszechnieStosowana")!.Value;
            if (form == null || commonName == null)
                throw new Exception();

            mpm.AddProduct(commonName, form);
        }

        mpm.PrintMometasoniFuroasCount();
        mpm.PrintNumberOfProductsWithTheSameCommonNameButInDifferentForms();
    }

    public static void ReadWarehouses(string filepath)
    {
        var doc = new XmlDocument();
        doc.Load(filepath);
        var warehouses = doc.GetElementsByTagName("Hurtownia");

        var wm = new WarehouseManager();

        foreach (XmlNode w in warehouses)
        {
            var status = w.Attributes!.GetNamedItem("status")!.Value!;
            var voivodeship = w.FirstChild!.Attributes!.GetNamedItem("wojewodztwo")!.Value!.ToUpper();
            var city = w.FirstChild!.Attributes!.GetNamedItem("miejscowosc")!.Value!.ToUpper();

            wm.AddWarehouseToVoivodeship(voivodeship, status);
            wm.AddWarehouseToCity(city, status);
        }

        // wm.PrintAllVoivodeships();
        wm.PrintVoivodeshipsWithMaxActiveAndInactiveWarehouses();
        wm.PrintTopThreeCitiesWithMostActiveWarehouses();
    }
}