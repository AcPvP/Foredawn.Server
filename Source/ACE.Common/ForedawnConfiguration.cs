using Newtonsoft.Json;

namespace ACE.Common
{
    public class ForedawnConfiguration
    {
        [System.ComponentModel.DefaultValue("")]
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Populate)]
        public string ProxyCheckApiKey { get; set; }
    }
}
