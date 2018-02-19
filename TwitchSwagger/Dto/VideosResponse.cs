using System;

namespace TwitchSwagger.Dto
{
    public class VideosResponse
    {
        public VideoDatum[] data { get; set; }
        public Pagination pagination { get; set; }
    }

    public class VideoDatum
    {
        public string id { get; set; }
        public string user_id { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public DateTime created_at { get; set; }
        public DateTime published_at { get; set; }
        public string url { get; set; }
        public string thumbnail_url { get; set; }
        public string viewable { get; set; }
        public int view_count { get; set; }
        public string language { get; set; }
        public string type { get; set; }
        public string duration { get; set; }
    }
}
