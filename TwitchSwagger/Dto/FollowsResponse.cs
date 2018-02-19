using System;

namespace TwitchSwagger.Dto
{
    public class FollowsResponse
    {
        public int total { get; set; }
        public FollowsDatum[] data { get; set; }
        public Pagination pagination { get; set; }
    }

    public class FollowsDatum
    {
        public string from_id { get; set; }
        public string to_id { get; set; }
        public DateTime followed_at { get; set; }
    }
}
