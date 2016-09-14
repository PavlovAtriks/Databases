namespace ExtractAllSongTitles
{
    using System.Xml;
    using System;

    public class ExtractAllSongTitles
    {
        private const string PathToXmlFile = "../../../catalog.xml";

        static void Main()
        {
            using (XmlReader reader = XmlReader.Create(PathToXmlFile))
            {
                while (reader.Read())
                {
                    if ((reader.NodeType == XmlNodeType.Element) &&
                       (reader.Name == "title"))
                    {
                        Console.WriteLine(reader.ReadElementContentAsString());
                    }
                }
            }

        }
    }
}
