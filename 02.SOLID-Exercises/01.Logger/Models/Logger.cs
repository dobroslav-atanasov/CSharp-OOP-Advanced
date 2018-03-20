namespace Logger.Models
{
    using System;
    using System.Text;
    using Enums;
    using Interfaces;

    public class Logger : ILogger
    {
        private IAppender[] appenders;

        public Logger(params IAppender[] appenders)
        {
            this.appenders = appenders;
        }

        public void Error(string time, string message)
        {
            this.Log(time, "Error", message);
        }

        public void Info(string time, string message)
        {
            this.Log(time, "Info", message);
        }

        public void Fatal(string time, string message)
        {
            this.Log(time, "Fatal", message);
        }

        public void Critical(string time, string message)
        {
            this.Log(time, "Critical", message);
        }

        public void Warning(string time, string message)
        {
            this.Log(time, "Warning", message);
        }

        private void Log(string time, string reportLevel, string message)
        {
            foreach (IAppender appender in this.appenders)
            {
                ReportLevel currentReportLevel = Enum.Parse<ReportLevel>(reportLevel);

                if (appender.ReportLevel <= currentReportLevel)
                {
                    appender.Append(time, reportLevel, message);
                }
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Logger info");
            foreach (IAppender appender in this.appenders)
            {
                sb.AppendLine(appender.ToString());
            }
            return sb.ToString().Trim();
        }
    }
}