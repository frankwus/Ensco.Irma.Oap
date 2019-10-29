using Ensco.Irma.Interfaces.Services.Configuration;
using System.Xml.Serialization;

namespace Ensco.Environment.Data
{
    [XmlRoot("Data", Namespace = "urn:transocean-config")]
    public class DataConfiguration : IDataConfiguration
    {
        /// <summary>
        /// Gets or sets the name of the database server.
        /// </summary>
        /// <value>
        /// The server.
        /// </value>
        [XmlAttribute("server")]
        public string Server { get; set; }

        /// <summary>
        /// Gets or sets the name of the database.  If not specified, the Application Name is used
        /// </summary>
        /// <value>
        /// The database.
        /// </value>
        [XmlAttribute("database")]
        public string Database { get; set; }

        /// <summary>
        /// Gets or sets the username to use to connect to SQL Server.  If not specified, Windows Authentication is used
        /// </summary>
        /// <value>
        /// The username.
        /// </value>
        [XmlAttribute("username")]
        public string Username { get; set; }

        /// <summary>
        /// Gets or sets the password to use to connect to SQL Server.  If not specified, Windows Authentication is used
        /// </summary>
        /// <value>
        /// The password.
        /// </value>
        [XmlAttribute("password")]
        public string Password { get; set; }

        /// <summary>
        /// Gets or sets the command time out for commands executed using the context.
        /// </summary>
        /// <value>
        /// The size of the page.
        /// </value>
        [XmlAttribute("commandTimeOut")]
        public int CommandTimeOut { get; set; }
    }
}
