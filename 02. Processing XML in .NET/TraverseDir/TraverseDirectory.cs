namespace TraverseDir
{
    using System;
    using System.IO;
    using System.Text;
    using System.Xml;
    
    public class TraverseDirectory
    {
        public static void Main()
        {
            string fileName = "../../result.xml";

            using (XmlTextWriter writer = new XmlTextWriter(fileName, Encoding.UTF8))
            {
                writer.Formatting = Formatting.Indented;
                writer.IndentChar = '\t';
                writer.Indentation = 1;

                writer.WriteStartDocument();
                writer.WriteStartElement("directory");
                TraverseDirectories(writer, "../../");
                writer.WriteEndDocument();
            }

            Console.WriteLine("New xml file was created!");
        }

        private static void TraverseDirectories(XmlTextWriter writer, string dir)
        {
            foreach (var directory in Directory.GetDirectories(dir))
            {
                writer.WriteStartElement("dir");
                writer.WriteAttributeString("path", directory);
                TraverseDirectories(writer, directory);
                writer.WriteEndElement();
            }

            foreach (var file in Directory.GetFiles(dir))
            {
                writer.WriteStartElement("file");
                writer.WriteAttributeString("name", Path.GetFileName(file));
                writer.WriteEndElement();
            }
        }
    }
}
