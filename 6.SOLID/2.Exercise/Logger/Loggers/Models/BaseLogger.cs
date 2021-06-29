using CustomLogger.Appenders.Interfaces;
using CustomLogger.Misc;
using System;

namespace CustomLogger.Loggers.Models
{
    public abstract class BaseLogger
    {
        public BaseLogger(params BaseAppender[] appenders)
        {
            Appenders = appenders;
        }

        protected BaseAppender[] Appenders { get; }

        public void Critical(string dateAndTime, string textBody)
        {
            foreach (var appender in Appenders)
            {
                appender.OutputText = (dateAndTime, ReportLevel.Critical, textBody);
                appender.Append();
            }
        }

        public void DisplayLoggerInfo()
        {
            foreach (var appender in Appenders)
            {
                appender.LogFile.Write(
                Environment.NewLine +
                $"Logger info" +
                Environment.NewLine +
                $"Appender type:{appender.GetType().Name}" +
                $", Layout type: {appender.Layout.GetType().Name}" +
                $", Report level: {appender.ReportLevel}" +
                $", Messages appended: {appender.MessagesAppended}");
            }
        }

        public void DumpCollectedData()
        {
            foreach (var appender in Appenders)
            {
                appender.DumpLoggedData();
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