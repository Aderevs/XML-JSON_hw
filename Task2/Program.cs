using System.Xml;

namespace Task2
{
    internal class Program
    {
        const string XmlFilePath = "../../../XMLFile.xml";
        static void Main(string[] args)
        {
            var xmlDoc = new XmlDocument();
            xmlDoc.Load(XmlFilePath);
            Console.WriteLine("Inner text: " + xmlDoc.InnerText);
            Console.WriteLine("name: " + xmlDoc.Name);
            Console.WriteLine("value: " + xmlDoc.Value);
            Console.WriteLine("doc element: " + xmlDoc.DocumentElement);
            Console.WriteLine("Inner xml: " + xmlDoc.InnerXml);
            Console.WriteLine("node type: " + xmlDoc.NodeType);
            Console.WriteLine("-------------------------------\n\n");

            using (var fileStream = new FileStream(XmlFilePath, FileMode.Open))
            {
                using (var xmlReader = new XmlTextReader(fileStream))
                {
                    while (xmlReader.Read())
                    {
                        Console.WriteLine("{0,-15} Attributes count: {1,-10} {2,-10} {3,-10}",
                            xmlReader.NodeType,
                            xmlReader.AttributeCount,
                            xmlReader.Name,
                            xmlReader.Value);
                    }
                }
            }
        }
    }
}
