using IS_Labs;

var xmlPath = Path.Combine("Assets", "data.xml");

// odczyt danych z wykorzystaniem DOM
Console.WriteLine("==================== XML loaded by DOM Approach ====================");
XmlReadWithDomApproach.Read(xmlPath);

// odczyt danych z wykorzystaniem SAX
Console.WriteLine("\n==================== XML loaded by SAX Approach ====================");
XmlReadWithSaxApproach.Read(xmlPath);

// odczyt danych z wykorzystaniem XPath i DOM
Console.WriteLine("\n==================== XML loaded with XPath ====================");
XmlReadWithXsltDomApproach.Read(xmlPath);

// głębsza analiza treści dokumentu
Console.WriteLine("\n==================== Deeper analysis ====================");
DeeperAnalysis.AnalyzeMedicalProducts(xmlPath);