using log4net;
using System; 
namespace Ensco.Irma.Logging
{
    public class Log : Ensco.Irma.Interfaces.Services.Logging.ILog
    {
        private log4net.ILog LogInstance { get; set; }

        private Log(log4net.ILog log)
        {
            LogInstance = log;
        }
        public void Debug(object message, Exception exception = null)
        {
            if (exception == null)
            {
                LogInstance.Debug(message);
            }
            else
            {
                LogInstance.Debug(message, exception);
            }
        }

        public void Error(object message, Exception exception = null)
        {
            if (exception == null)
            {
                LogInstance.Error(message);
            }
            else
            {
                LogInstance.Error(message, exception);
            }
        }

        public void Fatal(object message, Exception exception = null)
        {
            if (exception == null)
            {
                LogInstance.Fatal(message);
            }
            else
            {
                LogInstance.Fatal(message, exception);
            }
        }

        public void Info(object message, Exception exception = null)
        {
            if (exception == null)
            {
                LogInstance.Info(message);
            }
            else
            {
                LogInstance.Info(message, exception);
            }
        }

        public void Warn(object message, Exception exception = null)
        {
            if (exception == null)
            {
                LogInstance.Warn(message);
            }
            else
            {
                LogInstance.Warn(message, exception);
            }
        }

        public static Interfaces.Services.Logging.ILog GetLogger(Type type)
        {
            return new Log(LogManager.GetLogger(type));
        }
    }
}
