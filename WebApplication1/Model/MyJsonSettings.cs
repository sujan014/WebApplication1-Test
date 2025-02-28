using Newtonsoft.Json;

namespace WebApplication1.Model
{
    public static class MyJsonSettings {
        public static JsonSerializerSettings settings = new JsonSerializerSettings
        {
            NullValueHandling = NullValueHandling.Ignore,
            Formatting = Formatting.Indented
        };
    }    
}
