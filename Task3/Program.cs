using System.Xml;

namespace Task3
{
    internal class Program
    {
        static void WriteTelephoneBookToXml(Dictionary<string, string> phoneNumbersAndNames)
        {
            using(var xmlWriter = new XmlTextWriter("../../../TelephoneBook.xml", null))
            {
                xmlWriter.WriteStartDocument();
                xmlWriter.WriteStartElement("MyContacts");
                foreach (var contact in phoneNumbersAndNames)
                {
                    xmlWriter.WriteStartElement("Contact");
                    xmlWriter.WriteStartAttribute("TelephoneNumber");
                    xmlWriter.WriteString(contact.Key);
                    xmlWriter.WriteEndAttribute();
                    xmlWriter.WriteString(contact.Value);
                    xmlWriter.WriteEndElement();
                }
                xmlWriter.WriteEndElement();
            }
        }
        static void Main(string[] args)
        {
            var contacts = new Dictionary<string, string>
            {
                { "0959353169", "me" },
                { "0666772189", "Karl" },
                { "0236432189", "Pem" },
                { "0506767186", "Pork" },
                { "0975432734", "Clark" }
            };
            WriteTelephoneBookToXml (contacts);
        }
    }
}
