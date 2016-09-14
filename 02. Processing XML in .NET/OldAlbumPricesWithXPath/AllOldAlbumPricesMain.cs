namespace OldAlbumPricesWithXPath
{
    using System;
    using System.Xml;

    public class AllOldAlbumPricesMain
    {
        private const string PathToXmlFile = "../../../catalog.xml";
        private const int YearBefore = 2011;

        static void Main()
        {
            XmlDocument catalogue = new XmlDocument();
            catalogue.Load(PathToXmlFile);

            string xPathQuery = "/catalog/album";

            XmlNodeList albumList = catalogue.SelectNodes(xPathQuery);

            foreach (XmlNode node in albumList)
            {
                int year = int.Parse(node.SelectSingleNode("year").InnerText);

                if (year < YearBefore)
                {
                    double price = double.Parse(node.SelectSingleNode("price").InnerText);
                    string name = node.SelectSingleNode("name").InnerText;
                    Console.WriteLine($"Album {name} was released in {year} costs {price:C2}");
                }
            }
        }
    }
}
