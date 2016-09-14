namespace ProcessingJSON
{
    using System;
    using System.Net;
    using System.Xml;
    using System.Linq;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using System.IO;
    using System.Collections.Generic;

    public class Services
    {
        public Services()
        {
        }

        public void DownloadRss(string url, string fileName)
        {
            var webClient = new WebClient();
            webClient.DownloadFile(url, fileName);
        }

        public XmlDocument GetXml(string path)
        {
            var xmlDoc = new XmlDocument();
            xmlDoc.Load(path);

            return xmlDoc;
        }

        public JObject ParseXmlToJson(XmlDocument xml)
        {
            string json = JsonConvert.SerializeXmlNode(xml);
            var jsonObject = JObject.Parse(json);

            return jsonObject;
        }

        public void PrintAllVideoTitles(JObject jsonObj)
        {
            var allVideotitles = jsonObj["feed"]["entry"].Select(x => x["title"]);

            foreach(var title in allVideotitles)
            {
                Console.WriteLine($"Title: {title}");
            }
        }

        public IEnumerable<Video> GetVideosAsCollection(JObject videosAsJson)
        {
            return videosAsJson["feed"]["entry"]
                   .Select(e => JsonConvert.DeserializeObject<Video>(e.ToString()));
        }

        public void CreateHtmlForVideos(string htmlPath, IEnumerable<Video> videos)
        {
            var template = new { id = string.Empty, title = string.Empty };

            var htmlCreator = new StreamWriter(htmlPath);
            htmlCreator.Write("<html><head><title>Telerik Videos</title><meta charset=\"UTF-8\"></head><body>");

            foreach (var video in videos)
            {
                htmlCreator.WriteLine(
                    "<div style=\"display: inline-block;\"><iframe width=420 height=315 src=\"https://www.youtube.com/embed/"
                    + video.Id.Substring(video.Id.LastIndexOf(":") + 1) + "\"></iframe><br />"
                    + "<a style=\"text-decoration: none; font-family: Arial; color: #444;\""
                    + " href=\"https://youtu.be/"
                    + video.Id.Substring(video.Id.LastIndexOf(":") + 1) + "\" target=\"_blank\">" + video.Title + "</a></div"
                    + ">");
            }

            htmlCreator.Write("</body></html>");
            htmlCreator.Close();
        }
    }
}
