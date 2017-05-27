namespace Rachio.NET.Service.Model
{
    using Newtonsoft.Json;

    public class Error
    {
        public string Code { get; set; }
        [JsonProperty("Error")]
        public string Message { get; set; }
    }
}
