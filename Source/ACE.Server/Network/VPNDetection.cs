using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.IO;
using System.Threading.Tasks;
using System.Text.Json;

namespace ACE.Server.Network
{
    public class ISPInfo
    {
        public string ASN { get; set; }
        public string Provider { get; set; }
        public string Continent { get; set; }
        public string Country { get; set; }
        public string IsoCode { get; set; }
        public string Region { get; set; }
        public string RegionCode { get; set; }
        public string City { get; set; }
        public float Latitude { get; set; }
        public float Longitude { get; set; }
        public string Proxy { get; set; }
        public string Type { get; set; }
    }
    
    public static class VPNDetection
    {
        public static string ApiKey { get; set; } = ACE.Common.ConfigManager.Config.Foredawn.ProxyCheckApiKey;

        public static async Task<ISPInfo> CheckVPN(string ip)
        {
            var url = $"https://proxycheck.io/v2/{ip}?vpn=1&asn=1&key={ApiKey}";
            if (!string.IsNullOrWhiteSpace(ApiKey))
                url += "&key=" + ApiKey;
            var req = WebRequest.Create(url);
            var task = req.GetResponseAsync();
            if (!(await Task.WhenAny(task, Task.Delay(3000)) == task))
                return null; //timed out
            var resp = task.Result;
            using (var stream = resp.GetResponseStream())
            {
                using (var sr = new StreamReader(stream))
                {
                    var data = sr.ReadToEnd();
                    var options = new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true,
                    };
                    
                    var d1 = Newtonsoft.Json.JsonConvert.DeserializeObject<dynamic>(data);
                    var d = d1[ip];
                    var ispinfo = new ISPInfo()
                    {
                        ASN = d["asn"],
                        Provider = d["provider"],
                        City = d["city"],
                        Continent = d["continent"],
                        Country = d["country"],
                        IsoCode = d["isocode"],
                        Latitude = d["latitude"],
                        Longitude = d["longitude"],
                        Proxy = d["proxy"],
                        Region = d["region"],
                        RegionCode = d["regioncode"],
                        Type = d["type"]
                    };

                    return ispinfo;
                }
            }
        }
    }
}
