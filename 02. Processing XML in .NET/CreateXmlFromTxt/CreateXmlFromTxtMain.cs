namespace CreateXmlFromTxt
{
    using System;
    using System.IO;
    using System.Xml.Linq;

    public class CreateXmlFromTxtMain
    {
        private const string PathToTxtFile = "../../personInfo.txt";
        private const string OutputXmlFile = "../../person.xml";

        static void Main()
        {
            StreamReader reader = new StreamReader(PathToTxtFile);

            var name = reader.ReadLine();
            var address = reader.ReadLine();
            var phone = reader.ReadLine();
            
            var person = new Person(name, address, phone);

            var personElement = new XElement("person",
                new XElement("name", name),
                new XElement("address", address),
                new XElement("phone", phone));

            personElement.Save(OutputXmlFile);
            
            Console.WriteLine("New XML file was created from the provided txt file!");
        }
    }
}
