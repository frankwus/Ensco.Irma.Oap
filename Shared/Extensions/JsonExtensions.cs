using Newtonsoft.Json;

namespace Ensco.Irma.Extensions
{
    public static class JsonExtensions
    {
        private static JsonSerializerSettings settings = new JsonSerializerSettings()
        {
            NullValueHandling = NullValueHandling.Ignore,
            ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
            PreserveReferencesHandling = PreserveReferencesHandling.Objects
        };

         

        public static string ToJson(this object value)
        {
            return JsonConvert.SerializeObject(value, settings);
        }
    }
}
