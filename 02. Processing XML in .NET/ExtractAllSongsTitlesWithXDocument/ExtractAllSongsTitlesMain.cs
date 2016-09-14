namespace ExtractAllSongsTitlesWithXDocument
{
    using System;
    using System.Linq;
    using System.Xml.Linq;

    public class ExtractAllSongsTitlesMain
    {
        private const string PathToXmlFile = "../../../catalog.xml";

        static void Main()
        {
            var doc = XDocument.Load(PathToXmlFile);
            var albums = doc.Element("catalog").Elements("album");

            var titles = from title in albums.Descendants("title")
                         select title.Value;

            foreach (var title in titles)
            {
                Console.WriteLine(title);
            }

        }
    }
}
