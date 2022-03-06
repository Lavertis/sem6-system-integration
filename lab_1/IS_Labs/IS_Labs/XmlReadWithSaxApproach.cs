using System.Xml;
using IS_Labs.Helpers;

namespace IS_Labs;

public static class XmlReadWithSaxApproach
{
    public static void ReadMedicalProducts(string filepath)
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

            mpm.AddProduct(commonName, form);
        }

        mpm.PrintMometasoniFuroasCount();
        mpm.PrintNumberOfProductsWithTheSameCommonNameButInDifferentForms();
    }

    public static void ReadWarehouses(string filepath)
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

        var wm = new WarehouseManager();

        while (reader.ReadState != ReadState.EndOfFile) // analiza każdego z węzłów dokumentu
        {
            while (reader.Read())
            {
                if (reader.NodeType == XmlNodeType.Element && reader.Name == "Hurtownia")
                    break;
            }

            var status = reader.GetAttribute("status");
            if (status == null)
                break;

            while (reader.Read())
            {
                if (reader.NodeType == XmlNodeType.Element && reader.Name == "Adres")
                    break;
            }

            var voivodeship = reader.GetAttribute("wojewodztwo")!.ToUpper();
            var city = reader.GetAttribute("miejscowosc")!.ToUpper();

            wm.AddWarehouseToVoivodeship(voivodeship, status);
            wm.AddWarehouseToCity(city, status);
        }

        // wm.PrintAllVoivodeships();
        wm.PrintVoivodeshipsWithMaxActiveAndInactiveWarehouses();
        wm.PrintTopThreeCitiesWithMostActiveWarehouses();
    }
}