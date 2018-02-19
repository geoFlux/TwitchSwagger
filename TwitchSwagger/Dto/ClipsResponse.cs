namespace TwitchSwagger.Dto
{
    public class ClipsResponse
    {
        public ClipsDatum[] data { get; set; }
    }

    public class ClipsDatum
    {
        public string id { get; set; }
        public string edit_url { get; set; }
    }

}
