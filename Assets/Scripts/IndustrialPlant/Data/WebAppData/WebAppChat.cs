using System;

using Newtonsoft.Json;

namespace IndustrialPlant.Data.WebAppData
{
    [Serializable]
    public class WebAppChat
    {
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public int id;

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string type;

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string title;

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string username;

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public bool photo_url;
    }
}