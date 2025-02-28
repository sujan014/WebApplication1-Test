using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace WebApplication1.Model
{
    public class Result
    {
        [JsonProperty("@ID")]
        public string ID { get; set; }
        public string calculation { get; set; }
        public List<string> Inputs { get; set; }       
        public Result? result { get; set; }
    }
}
