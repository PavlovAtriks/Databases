namespace ProcessingJSON
{
    using Newtonsoft.Json;

    public class Video
    {
        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }
    }
}
