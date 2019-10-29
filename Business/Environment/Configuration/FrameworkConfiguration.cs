using Ensco.Environment.Data; 
using System;
using System.IO;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace Ensco.Irma.Framework.Configuration
{
    [XmlRoot("Framework", Namespace = "urn:framework-config")]
    [XmlInclude(typeof(DataConfiguration))]
    public class FrameworkConfiguration : IFrameworkConfiguration
    {
        protected static Lazy<XmlSerializer> Serializer;

        /// <summary>
        ///   Gets or sets the name of the application.
        /// </summary>
        /// <value>The application.</value>
        [XmlAttribute("name")]
        public string Name { get; set; }

        public object Create(object parent, object configContext, XmlNode section)
        {
            /* Validation for config section with xsd's*/
            using (var rd = new StringReader(section.OuterXml))
            {
                var settings = new XmlReaderSettings { ValidationType = ValidationType.Schema };
                settings.ValidationEventHandler += ConfigurationValidation;

                XmlReader xmlReader;
                try
                {
                    xmlReader = XmlReader.Create(rd, settings);
                }
                catch (Exception e)
                {

                    throw e;
                }
                using (xmlReader)
                {
                    //empty loop - if Read fails it will raise an error via the 
                    //ValidationEventHandler wired to the XmlReaderSettings object
                    while (xmlReader.Read()) { }
                }
            }
             
            //Deserialize the Section to Configuration Object
            using (var rd = new StringReader(section.OuterXml))
            {
                return Load<FrameworkConfiguration>(rd);
            }
        }

        private void ConfigurationValidation(object sender, ValidationEventArgs e)
        {
            throw new ApplicationException(string.Format("Invalid configuraiton :{0}", e.Message), e.Exception);
        }

        /// <summary>
        ///   Gets or sets the data layer configuration
        /// </summary>
        /// <value>The data.</value>
        [XmlElement("Data")]
        public DataConfiguration Data { get; set; }

        /// <summary>
        /// Gets the connection string specified in the <seealso cref="Data"/> property, or generated based on the app name
        /// </summary>
        /// <returns></returns>
        public string GetConnectionString(bool useMaster = false)
        {
            var data = Data;

            var server = data.Server ?? ".\\sqlexpress";
            var db = useMaster ? "master" : data.Database ?? Name;

            return (String.IsNullOrEmpty(data.Username) || String.IsNullOrEmpty(data.Password))
                ? String.Format("Server={0};Database={1};Integrated Security=True;multipleactiveresultsets=True;", server, db)
                : String.Format("Server={0};Database={1};User Id={2};Password={3};multipleactiveresultsets=True;", server, db, data.Username, data.Password);
        }

        /// <summary>
        ///   Loads the specified stream.
        /// </summary>
        /// <param name="reader">The stream.</param>
        /// <returns></returns>
        public static TConfig Load<TConfig>(TextReader reader) where TConfig : FrameworkConfiguration
        { 
            Serializer = new Lazy<XmlSerializer>(() => new XmlSerializer(typeof(TConfig)));
            return Serializer.Value.Deserialize(reader) as TConfig;
        }
    }
}
