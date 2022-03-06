using IS_Labs;

var medicalProductsXmlPath = Path.Combine("Assets", "medical_products.xml");
var warehousesXmlPath = Path.Combine("Assets", "warehouses.xml");

// odczyt danych z wykorzystaniem DOM
Console.WriteLine("==================== XML loaded by DOM Approach ====================");
XmlReadWithDomApproach.ReadMedicalProducts(medicalProductsXmlPath);
XmlReadWithDomApproach.ReadWarehouses(warehousesXmlPath);

// odczyt danych z wykorzystaniem SAX
Console.WriteLine("\n==================== XML loaded by SAX Approach ====================");
XmlReadWithSaxApproach.ReadMedicalProducts(medicalProductsXmlPath);
XmlReadWithSaxApproach.ReadWarehouses(warehousesXmlPath);

// odczyt danych z wykorzystaniem XPath i DOM
Console.WriteLine("\n==================== XML loaded with XPath ====================");
XmlReadWithXsltDomApproach.ReadMedicalProducts(medicalProductsXmlPath);
XmlReadWithXsltDomApproach.ReadWarehouses(warehousesXmlPath);

// głębsza analiza treści dokumentu
Console.WriteLine("\n==================== Deeper analysis ====================");
DeeperAnalysis.AnalyzeMedicalProducts(medicalProductsXmlPath);