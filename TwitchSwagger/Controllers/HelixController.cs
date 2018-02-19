using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using TwitchSwagger.Dto;

namespace TwitchSwagger.Controllers
{

    [Produces("application/json")]
    [Route("")]
    [Authorize]
    public class HelixController : Controller
    {
        /// <summary>
        /// https://dev.twitch.tv/docs/api/reference#get-users-follows
        /// </summary>
        /// <param name="from_id">User ID. The request returns information about users who are being followed by the from_id user.</param>
        /// <param name="to_id">User ID. The request returns information about users who are following the to_id user.</param>
        /// <param name="first">Maximum number of objects to return. Maximum: 100. Default: 20.</param>
        /// <param name="after">Cursor for forward pagination: tells the server where to start fetching the next set of results, in a multi-page response.</param>
        /// <param name="before">Cursor for backward pagination: tells the server where to start fetching the next set of results, in a multi-page response.</param>
        /// <returns></returns>
        [HttpGet("users/follows")]
        public FollowsResponse Follows(
            string from_id,
            string to_id,
            int? first,
            string after,
            string before)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// https://dev.twitch.tv/docs/api/reference#get-videos
        /// </summary>
        /// <param name="id">ID of the video being queried. Limit: 100. If this is specified, you cannot use any of the optional query string parameters below.</param>
        /// <param name="user_id">ID of the user who owns the video. Limit 1.</param>
        /// <param name="game_id">ID of the game the video is of. Limit 1.</param>
        /// <param name="after">Cursor for forward pagination: tells the server where to start fetching the next set of results, in a multi-page response.</param>
        /// <param name="before">Cursor for backward pagination: tells the server where to start fetching the next set of results, in a multi-page response.</param>
        /// <param name="first">Number of values to be returned when getting videos by user or game ID. Limit: 100. Default: 20.</param>
        /// <param name="language">Language of the video being queried. Limit: 1.</param>
        /// <param name="period">Period during which the video was created. Valid values: "all", "day", "month", and "week". Default: "all".</param>
        /// <param name="sort">Sort order of the videos. Valid values: "time", "trending", and "views". Default: "time".</param>
        /// <param name="type">Type of video. Valid values: "all", "upload", "archive", and "highlight". Default: "all".</param>
        /// <returns></returns>
        [HttpGet("videos")]
        public FollowsResponse Videos(
            string[] id,
            string user_id,
            string game_id,
            string after,
            string before,
            string first,
            string language,
            Period? period,
            Sort? sort,
            VideoType? type)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// https://dev.twitch.tv/docs/api/reference#get-streams
        /// </summary>
        /// <param name="user_login">Returns streams broadcast by one or more specified user login names. You can specify up to 100 names.</param>
        /// <param name="user_id">Returns streams broadcast by one or more specified user IDs. You can specify up to 100 IDs.</param>
        /// <param name="game_id">Returns streams broadcasting a specified game ID. You can specify up to 100 IDs.</param>
        /// <param name="comunity_id"></param>
        /// <param name="language">Stream language. You can specify up to 100 languages.</param>
        /// <param name="type">Stream type: "all", "live", "vodcast". Default: "all".</param>
        /// <param name="first">Maximum number of objects to return. Maximum: 100. Default: 20.</param>
        /// <param name="after">Cursor for forward pagination: tells the server where to start fetching the next set of results, in a multi-page response.</param>
        /// <param name="before">Cursor for backward pagination: tells the server where to start fetching the next set of results, in a multi-page response.</param>
        /// <returns></returns>
        [HttpGet("streams")]
        public StreamsResponse Streams(
            string[] user_login,
            string[] user_id,
            string[] game_id,
            string[] comunity_id,
            string[] language,
            StreamType? type,
            int? first,
            string after,
            string before)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// https://dev.twitch.tv/docs/api/reference#get-users
        /// </summary>
        /// <param name="id">User ID. Multiple user IDs can be specified. Limit: 100.</param>
        /// <param name="login">User login name. Multiple login names can be specified. Limit: 100.</param>
        /// <returns></returns>
        [HttpGet("users")]
        public UsersResponse Users(
            string[] id,
            string[] login
            )
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// https://dev.twitch.tv/docs/api/reference#create-clip
        /// </summary>
        /// <param name="broadcaster_id">	ID of the stream from which the clip will be made.</param>
        /// <returns></returns>
        [HttpPost("clips")]
        public ClipsResponse Clips(string broadcaster_id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// https://dev.twitch.tv/docs/api/reference#create-entitlement-grants-upload-url
        /// </summary>
        /// <param name="manifest_id">Unique identifier of the manifest file to be uploaded. Must be 1-64 characters.</param>
        /// <param name="type">Type of entitlement being granted. Only bulk_drops_grant is supported.</param>
        /// <returns></returns>
        [HttpPost("entitlements/upload")]
        public EntitlementsUploadResponse EntitlementsUpload(
            [Required] string manifest_id,
            EntitlementsUploadType type
            )
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// https://dev.twitch.tv/docs/api/reference#get-games
        /// </summary>        
        /// <param name="id">Game ID. At most 100 id values can be specified.</param>
        /// <param name="name">Game name. The name must be an exact match. For instance, "Pokemon" will not return a list of Pokemon games; instead, query the specific Pokemon game(s) in which you are interested. At most 100 name values can be specified.</param>
        /// <returns></returns>
        [HttpGet("games")]
        public GamesResponse Games(
            string[] id,
            string[] name
            )
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// https://dev.twitch.tv/docs/api/reference#get-streams-metadata
        /// </summary>
        /// <param name="user_id">Returns streams broadcast by one or more of the specified user IDs. You can specify up to 100 IDs.</param>
        /// <param name="user_login">Returns streams broadcast by one or more of the specified user login names. You can specify up to 100 names.</param>
        /// <param name="comunity_id">Returns streams in a specified community ID. You can specify up to 100 IDs.</param>
        /// <param name="game_id">Returns streams broadcasting the specified game ID. You can specify up to 100 IDs.</param>
        /// <param name="first">Maximum number of objects to return. Maximum: 100. Default: 20.</param>
        /// <param name="after">Cursor for forward pagination: tells the server where to start fetching the next set of results, in a multi-page response.</param>
        /// <param name="before">Cursor for backward pagination: tells the server where to start fetching the next set of results, in a multi-page response.</param>
        /// <param name="language">Stream language. You can specify up to 100 languages.</param>
        /// <param name="type">Stream type: "all", "live", "vodcast". Default: "all".</param>
        /// <returns></returns>
        [HttpGet("streams/metadata")]
        public StreamMetadataResponse StreamsMetaData(
            string[] user_id,
            string[] user_login,
            string[] comunity_id,
            string[] game_id,
            string first,
            string after,
            string before,
            string[] language,
            StreamType? type
            )
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// https://dev.twitch.tv/docs/api/reference#get-top-games
        /// </summary>
        /// <param name="first">Maximum number of objects to return. Maximum: 100. Default: 20.</param>
        /// <param name="after">Cursor for forward pagination: tells the server where to start fetching the next set of results, in a multi-page response.</param>
        /// <param name="before">Cursor for backward pagination: tells the server where to start fetching the next set of results, in a multi-page response.</param>
        /// <returns></returns>
        [HttpGet("games/top")]
        public GamesResponse TopGames(
            string first,
            string after,
            string before
            )
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// https://dev.twitch.tv/docs/api/reference#update-user
        /// </summary>
        /// <param name="description"></param>
        /// <returns></returns>
        [HttpPut("users")]
        public UsersResponse UpdateUsersDescription([Required] string description)
        {
            throw new NotImplementedException();
        }
    }



    public static class MyExtensions
    {
        // Write custom extension methods here. They will be available to all queries.
        public static string ToJson(this object o, bool prettyPrint = true, bool camelCasing = false)
        {
            var formatting = prettyPrint ? Newtonsoft.Json.Formatting.Indented : Newtonsoft.Json.Formatting.None;
            var serializerSettings = new JsonSerializerSettings
            {
                ContractResolver = camelCasing ? new CamelCasePropertyNamesContractResolver() : null,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            };
            return JsonConvert.SerializeObject(o, formatting, serializerSettings);
        }
        public static object FromJson(this string s)
        {
            return JsonConvert.DeserializeObject(s);
        }
        public static T FromJson<T>(this string s)
        {
            return JsonConvert.DeserializeObject<T>(s);
        }
    }
}