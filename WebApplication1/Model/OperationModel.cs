using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Model
{    
    public class OperationModel
    {
        [JsonProperty("@ID")]
        public string ID { get; set; }
        public List<string> Value { get; set; }
        public OperationModel? Operation { get; set; }
    }

    public class Maths
    {        
        public OperationModel Operation { get; set; }
    }    
    public class MathModel
    {
        public Maths Maths { get; set; }
    }
}
