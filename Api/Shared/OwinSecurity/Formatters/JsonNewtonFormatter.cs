using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Threading.Tasks;

namespace Ensco.Irma.Oap.Api.Common.Formatters
{
    public class JsonNewtonFormatter : MediaTypeFormatter
    {

        public  static readonly Lazy<JsonSerializerSettings> Settings = new Lazy<JsonSerializerSettings>(GetSerializationSettings);

        public JsonNewtonFormatter()
        {
            SupportedMediaTypes.Add(new System.Net.Http.Headers.MediaTypeHeaderValue("application/json"));
        }

        public override bool CanWriteType(Type type)
        {
            // don't serialize JsonValue structure use default for that
            if (type == typeof(JValue) || type == typeof(JObject) || type == typeof(JArray))
                return false;

            return true;
        }

        public override bool CanReadType(Type type)
        { 
            return false;
        }
         
        public override System.Threading.Tasks.Task<object> ReadFromStreamAsync(Type type, Stream stream, HttpContent content, IFormatterLogger formatterLogger)
        {
            var task = Task<object>.Factory.StartNew(() => 
            {
                var ser = JsonSerializer.Create(Settings.Value);
                ser.Converters.Add(new IsoDateTimeConverter());

                object val = null;
                using (var sr = new StreamReader(stream))
                {
                    using (var jreader = new JsonTextReader(sr))
                    {
                        val = ser.Deserialize(jreader, type);
                        jreader.Close();
                    }
                    sr.Close();
                } 

                return val;
            });

            return task;
        }
        public override Task WriteToStreamAsync(Type type, object value, Stream writeStream, HttpContent content, TransportContext transportContext)
        {
            var task = Task.Factory.StartNew(() =>
            {
                var ser =  JsonSerializer.Create(Settings.Value);
                ser.Converters.Add(new IsoDateTimeConverter());

                var sb = new System.Text.StringBuilder();

                using (var sw = new StringWriter(sb))
                {
                    ser.Serialize(sw, value);
                }
                string json = sb.ToString();  // JsonConvert.SerializeObject(value, Formatting.Indented, new JsonConverter[1] { new IsoDateTimeConverter() });

                byte[] buf = System.Text.Encoding.Default.GetBytes(json);
                writeStream.Write(buf, 0, buf.Length);
                writeStream.Flush();
            });

            return task;
        }

        private static JsonSerializerSettings GetSerializationSettings()
        {
            return new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
                TypeNameHandling = TypeNameHandling.Objects,
                NullValueHandling = NullValueHandling.Ignore,
                ReferenceLoopHandling = ReferenceLoopHandling.Serialize,
                PreserveReferencesHandling = PreserveReferencesHandling.Objects,
                DateTimeZoneHandling = DateTimeZoneHandling.Utc,
                DateFormatHandling = DateFormatHandling.IsoDateFormat,
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            };
        }
    }
    
}