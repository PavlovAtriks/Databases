﻿namespace XslTransform
{
    public class XslTransformMain
    {
        static void Main()
        {
            static void Main()
        {
                XslCompiledTransform xslt = new XslCompiledTransform();
                xslt.Load("../../style.xslt");
                xslt.Transform("../../../catalog.xml", "../../catalogue.html");

                var currentDir = Directory.GetCurrentDirectory();
                var savedDir = currentDir.Substring(0, currentDir.IndexOf("bin\\Debug"));
                Console.WriteLine("result saved as " + savedDir + "catalogue.html");
            }
        }
    }
}
