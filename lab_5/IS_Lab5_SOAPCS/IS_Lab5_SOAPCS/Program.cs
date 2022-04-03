using ServiceReference1;

Console.WriteLine("My First SOAP Client!");
MyFirstSOAPInterfaceClient client = new MyFirstSOAPInterfaceClient();

string helloText = await client.getHelloWorldAsStringAsync("Świecie");
Console.WriteLine(helloText);

long days = await client.getDaysBetweenDatesAsync("03-02-2022", "10-02-2022");
Console.WriteLine(days);