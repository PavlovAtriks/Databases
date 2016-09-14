namespace XsdSchema
{
    using System;
    using System.Xml.Linq;
    using System.Xml.Schema;

    public class XsdSchemaMain
    {
        private const string PathToXmlFile = "../../../catalog.xml";

        static void Main()
        {
            var schema = new XmlSchemaSet();
            schema.Add(string.Empty, "../../catalog.xsd");

            XDocument doc = XDocument.Load(PathToXmlFile);

            ValidateXML(schema, doc);
        }

        private static void ValidateXML(XmlSchemaSet schema, XDocument document)
        {
            bool hasError = false;

            document.Validate(schema, (o, e) =>
            {
                Console.WriteLine($"{e.Message}");
                hasError = true;
            });

            if (hasError)
            {
                Console.WriteLine("XML document validated");
            }
            else
            {
                Console.WriteLine("XML document did not validate");
            }
        }
    }
}
