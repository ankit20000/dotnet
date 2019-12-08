using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using log4net;

namespace Common
{
    public static class Logging
    {
        public static void ErrorLog(Exception objException)
        {
            StringBuilder sbException = new StringBuilder();
            ILog log = LogManager.GetLogger(typeof(Logging));
            log4net.Config.XmlConfigurator.Configure();

            try
            {
                sbException.AppendLine("\n");
                sbException.AppendLine("\n");
                sbException.AppendLine("Source: " + objException.Source.ToString().Trim());
                sbException.AppendLine("Method: " + objException.TargetSite.Name.ToString());
                sbException.AppendLine("Date: " + DateTime.Now.ToShortDateString());
                sbException.AppendLine("Time: " + DateTime.Now.ToLongTimeString());
                sbException.AppendLine("Computer: " + Dns.GetHostName().ToString());
                sbException.AppendLine("Error: " + objException.Message.ToString().Trim());
                sbException.AppendLine("\n");
                sbException.AppendLine("Stack Trace: " + objException.StackTrace.ToString().Trim());
                sbException.AppendLine("\n");
                sbException.AppendLine("^^----------------------------------------------Error Details End---------------------------------------------^^");

                log.Error(sbException.ToString());
            }
            catch (Exception ex)
            {
                ErrorLog(ex);
            }
        }
    }
}
