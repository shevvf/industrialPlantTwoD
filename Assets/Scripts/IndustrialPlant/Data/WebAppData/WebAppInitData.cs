using System;

using Newtonsoft.Json;

namespace IndustrialPlant.Data.WebAppData
{
    [Serializable]
    public class WebAppInitData
    {
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string query_id;

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public WebAppUser user;

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public WebAppUser receiver;

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public WebAppChat chat;

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string chat_type;

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string chat_instance;

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string start_param;

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public int? can_send_after;

        [JsonProperty(Required = Required.Always)]
        public int auth_date;

        [JsonProperty(Required = Required.Always)]
        public string hash;
    }
}