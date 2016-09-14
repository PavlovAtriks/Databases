namespace ProcessingJSON
{
    public class StartUp
    {
        private const string TelerikYouTubeRssURL = "https://www.youtube.com/feeds/videos.xml?channel_id=UCLC-vbm7OWvpbqzXaoAMGGw";
        private const string VideosXmlPath = "../../telerikVideos.xml";
        private const string VideosHtml = "../../index.html";

        static void Main()
        {
            var services = new Services();

            services.DownloadRss(TelerikYouTubeRssURL, VideosXmlPath);

            var xmlDoc = services.GetXml(VideosXmlPath);
            var jsonObject = services.ParseXmlToJson(xmlDoc);

            services.PrintAllVideoTitles(jsonObject);

            var videoCollection = services.GetVideosAsCollection(jsonObject);
            services.CreateHtmlForVideos(VideosHtml, videoCollection);
        }
    }
}




