using CustomLogger.Misc;
using CustomLogger.Appenders.Interfaces;
using CustomLogger.Loggers.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomLogger.Loggers.Models
{
    public class Logger : ILogger
    {
        public Logger(params IAppender[] appenders)
        {
            Appenders = appenders;
        }

        public IAppender[] Appenders { get; }

        public void Critical(string dateAndTime, string textBody)
        {
            foreach (var appender in Appenders)
            {
                appender.OutputText = (dateAndTime, ReportLevel.Critical, textBody);
                appender.Append();
            }
        }

        public void Error(string dateAndTime, string textBody)
        {
            foreach (var appender in Appenders)
            {
                appender.OutputText = (dateAndTime, ReportLevel.Error, textBody);
                appender.Append();
            }
        }

        public void Fatal(string dateAndTime, string textBody)
        {
            foreach (var appender in Appenders)
            {
                appender.OutputText = (dateAndTime, ReportLevel.Fatal, textBody);
                appender.Append();
            }
        }

        public void Info(string dateAndTime, string textBody)
        {
            foreach (var appender in Appenders)
            {
                appender.OutputText = (dateAndTime, ReportLevel.Info, textBody);
                appender.Append();
            }
        }

        public void Warning(string dateAndTime, string textBody)
        {
            foreach (var appender in Appenders)
            {
                appender.OutputText = (dateAndTime, ReportLevel.Warning, textBody);
                appender.Append();
            }
        }
    }
}