namespace TwitchSwagger.Dto
{
    public class EntitlementsUploadResponse
    {
        public EntitlementsUploadDatum[] data { get; set; }
    }

    public class EntitlementsUploadDatum
    {
        public string url { get; set; }
    }
}
