namespace Ensco.Irma.Interfaces.Services.Configuration
{
    public interface IDataConfiguration
    {
        int CommandTimeOut { get; set; }
        string Database { get; set; }
        string Password { get; set; }
        string Server { get; set; }
        string Username { get; set; }
    }
}