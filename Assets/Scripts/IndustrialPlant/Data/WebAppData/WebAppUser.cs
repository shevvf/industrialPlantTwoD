using System;

using Newtonsoft.Json;

namespace IndustrialPlant.Data.WebAppData
{
    [Serializable]
    public class WebAppUser
    {
        [JsonProperty(Required = Required.Always)]
        public long id;

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public bool is_bot;

        [JsonProperty(Required = Required.Always)]
        public string first_name;

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string last_name;

        [JsonProperty(Required = Required.Always)]
        public string username;

        [JsonProperty(Required = Required.Always)]
        public string language_code;

        [JsonProperty(Required = Required.Always)]
        public bool is_premium;

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public bool? added_to_attachment_menu;

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public bool? allows_write_to_pm;

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string photo_url;
    }
}