namespace AllOldAlbumPrices
{
    using System;
    using System.Linq;
    using System.Xml.Linq;

    public class AllOldAlbumPrices
    {
        private const string PathToXmlFile = "../../../catalog.xml";
        private const int YearBefore = 2011;

        public static void Main()
        {
            XDocument catalogue = XDocument.Load(PathToXmlFile);

            var albums =
                from album in catalogue.Descendants("album")
                where int.Parse(album.Element("year").Value) < YearBefore
                select new
                {
                    Name = album.Element("name").Value,
                    Year = int.Parse(album.Element("year").Value),
                    Price = double.Parse(album.Element("price").Value)
                };

            foreach (var album in albums)
            {
                Console.WriteLine($"Album {album.Name} was released in {album.Year} costs {album.Price:C2}");
            }
        }
    }
}
