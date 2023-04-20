using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DataAccessLayer.Logger
{
    public sealed class Logger
    {
        private static Logger logger;
        private Logger() { }
        public static Logger getInstance()
        {
            if (logger == null)
                logger = new Logger();
            return logger;
        }
        public void LogException(string message)
        {
            string fileName = string.Format("{0}_{1}.log", "Exception", DateTime.Now.ToShortDateString());
            string logFilePath = string.Format(@"{0}\{1}", AppDomain.CurrentDomain.BaseDirectory, fileName);
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("----------------------------------------");
            sb.AppendLine(DateTime.Now.ToString());
            sb.AppendLine(message);
            using (StreamWriter writer = new StreamWriter(logFilePath, true))
            {
                writer.Write(sb.ToString());
                writer.Flush();
            }
            LogTemp(message);
        }
        public void LogTemp(string msg)
        {
            string fileName = string.Format("{0}_{1}.log", "Exception", DateTime.Now.ToShortDateString());
            string logFilePath = string.Format("C:\\Logger Folder\\{0}", fileName);
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("----------------------------------------");
            sb.AppendLine(DateTime.Now.ToString());
            sb.AppendLine(msg);
            using (StreamWriter writer = new StreamWriter(logFilePath, true))
            {
                writer.Write(sb.ToString());
                writer.Flush();
            }
        }

        public void Exception(string Message)
        {
            throw new NotImplementedException();
        }

        public void LogException(object p)
        {
            throw new NotImplementedException();

        }
    }
}
