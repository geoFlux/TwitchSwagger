using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace TwitchSwagger.Dto
{
    public class StreamMetadataResponse
    {
        public StreamMetaDatum[] data { get; set; }
        public Pagination pagination { get; set; }
    }
    
    public class StreamMetaDatum
    {
        public string user_id { get; set; }
        public string game_id { get; set; }
        public Overwatch overwatch { get; set; }
        public Hearthstone hearthstone { get; set; }
    }

    public class Overwatch
    {
        public OverwatchBroadcaster broadcaster { get; set; }
    }

    public class OverwatchBroadcaster
    {
        public OverwatchHero hero { get; set; }
    }
    public class OverwatchHero
    {
        public string role { get; set; }
        public string name { get; set; }
        public string ability { get; set; }
    }

    public class Hearthstone
    {
        public HearthstoneBroadcaster broadcaster { get; set; }
        public Opponent opponent { get; set; }
    }

    public class HearthstoneBroadcaster
    {
        public HearthstoneHero hero { get; set; }
    }

    public class HearthstoneHero
    {
        public string type { get; set; }
        public string @class { get; set; }
        public string name { get; set; }
    }

    public class Opponent
    {
        public HearthstoneHero hero { get; set; }
    }            
}
