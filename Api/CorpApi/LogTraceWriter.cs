using Ensco.Irma.Interfaces.Services.Logging;
using Ensco.Irma.Extensions;
using System;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web.Http.Tracing;

namespace Ensco.Irma.RigApi
{
    public class LogTraceWriter : ITraceWriter
    {
        private ILog Log { get; set; }

        public LogTraceWriter(ILog log)
        {
            Log = log;
        }

       public void Trace(HttpRequestMessage request, string category, TraceLevel level, Action<TraceRecord> traceAction)
        {
            if (level != TraceLevel.Off)
            {
                if (traceAction != null && traceAction.Target != null)
                {
                    category = category + System.Environment.NewLine + "Action Parameters : " + traceAction.Target.ToJson();
                }
                var record = new TraceRecord(request, category, level);
                if (traceAction != null) traceAction(record);
                WriteLog(record);
            }
        }

        #region Private member methods.
        /// <summary>
        /// Logs info/Error to Log file
        /// </summary>
        /// <param name="record"></param>
        private void WriteLog(TraceRecord record)
        {
            var message = new StringBuilder();

            if (!string.IsNullOrWhiteSpace(record.Message))
                message.Append("").Append(record.Message + System.Environment.NewLine);

            if (record.Request != null)
            {
                if (record.Request.Method != null)
                    message.Append("Method: " + record.Request.Method + System.Environment.NewLine);

                if (record.Request.RequestUri != null)
                    message.Append("").Append("URL: " + record.Request.RequestUri + System.Environment.NewLine);

                if (record.Request.Headers != null && record.Request.Headers.Contains("Token") && record.Request.Headers.GetValues("Token") != null && record.Request.Headers.GetValues("Token").FirstOrDefault() != null)
                    message.Append("").Append("Token: " + record.Request.Headers.GetValues("Token").FirstOrDefault() + System.Environment.NewLine);
            }

            if (!string.IsNullOrWhiteSpace(record.Category))
                message.Append("").Append(record.Category);

            if (!string.IsNullOrWhiteSpace(record.Operator))
                message.Append(" ").Append(record.Operator).Append(" ").Append(record.Operation);

            switch(record.Level)
            {
                case TraceLevel.Debug:
                    Log.Debug(Convert.ToString(message) + System.Environment.NewLine);
                    break;
                case TraceLevel.Error:
                    Log.Error(Convert.ToString(message) + System.Environment.NewLine);
                    break;
                case TraceLevel.Fatal:
                    Log.Fatal(Convert.ToString(message) + System.Environment.NewLine);
                    break;
                case TraceLevel.Info:
                    Log.Info(Convert.ToString(message) + System.Environment.NewLine);
                    break;
                case TraceLevel.Warn:
                    Log.Warn(Convert.ToString(message) + System.Environment.NewLine);
                    break;

            } 
        }
        #endregion

    }
}