namespace ExtractAllArtistsWithDomParser
{
    using System;
    using System.Collections.Generic;
    using System.Xml;

    public class AllArtistMain
    {
        private const string PathToXmlFile = "../../../catalog.xml";

        public static void Main()
        {
            var doc = new XmlDocument();
            doc.Load(PathToXmlFile);

            var root = doc.DocumentElement;

            var allArtistsAndNumberOfTheirAlbums = GetArtistsAndNumberOfTheirAlbums(root);

            foreach(var artist in allArtistsAndNumberOfTheirAlbums)
            {
                Console.WriteLine($"Artist: {artist.Key} - Albums: {artist.Value}");
            }
        }

        private static Dictionary<string, int> GetArtistsAndNumberOfTheirAlbums(XmlElement catalog)
        {
            var allArtistWithCountedAlbums = new Dictionary<string, int>();

            foreach (XmlElement album in catalog)
            {
                var artistName = album["artist"].InnerText;

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
