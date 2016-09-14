namespace AllArtistAndAlbumsMain
{
    using System.Collections.Generic;
    using System.Xml;
    using System;

    public class AllArtistAndAlbumsMain
    {
        private const string PathToXmlFile = "../../../catalog.xml";

        public static void Main()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(PathToXmlFile);

            string xPathExpressionAlbums = "/catalog/album";

            XmlNodeList allAlbumsNode = doc.SelectNodes(xPathExpressionAlbums);

            var allArtistsWithNuberOfTheirAlbums = GetArtistsAndNumberOfTheirAlbums(allAlbumsNode);

            foreach (var artist in allArtistsWithNuberOfTheirAlbums)
            {
                Console.WriteLine($"Artist: {artist.Key} - Albums: {artist.Value}");
            }
        }

        private static Dictionary<string, int> GetArtistsAndNumberOfTheirAlbums(XmlNodeList albums)
        {
            var allArtistWithCountedAlbums = new Dictionary<string, int>();
            var xPathExpressionArtistName = "artist";

            foreach (XmlElement album in albums)
            {
                var artistName = album.SelectSingleNode(xPathExpressionArtistName).InnerText;

                if (!allArtistWithCountedAlbums.ContainsKey(artistName))
                {
                    allArtistWithCountedAlbums.Add(artistName, 1);
                }
                else
                {
                    allArtistWithCountedAlbums[artistName]++;
                }
            }

            return allArtistWithCountedAlbums;
        }
    }
}
