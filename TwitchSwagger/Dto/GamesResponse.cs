namespace TwitchSwagger.Dto
{
    public class GamesResponse
    {
        public GamesDatum[] data { get; set; }
    }

    public class GamesDatum
    {
        public string id { get; set; }
        public string name { get; set; }
        public string box_art_url { get; set; }
    }
}
