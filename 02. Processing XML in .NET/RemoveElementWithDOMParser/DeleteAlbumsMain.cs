namespace RemoveElementWithDOMParser
{
    using System.Xml;
    using System;

    public class DeleteAlbumsMain
    {
        private const string PathToXmlFile = "../../../catalog.xml";

        public static void Main()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(PathToXmlFile);

            var root = doc.DocumentElement;
            
            DeleteAlbums(root, 20.0);
            doc.Save("../../../catalogWithAlbumsUnder20Dollars.xml");

            Console.WriteLine("New Xml file with all albums under 20$ was saved!");
        }

        private static void DeleteAlbums(XmlElement catalog, double maxAlbumPrice)
        {
            double albumPrice = 0;

            var albums = catalog.ChildNodes;

            for(int i = 0; i < albums.Count; i++)
            {
                var album = albums[i];

                albumPrice = double.Parse(album["price"].InnerText);

                if (albumPrice > maxAlbumPrice)
                {
                    catalog.RemoveChild(album);
                }
            }
        }
    }
}
