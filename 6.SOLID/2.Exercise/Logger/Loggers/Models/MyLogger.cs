using CustomLogger.Misc;
using Logger.Appenders.Interfaces;
using Logger.Loggers.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logger.Loggers.Models
{
    public class MyLogger : ILogger
    {
        public MyLogger(IAppender appender)
        {
            this.Appender = appender;
        }

        public IAppender Appender { get; }

        public void Critical(string dateAndTime, string textBody)
        {
            Appender.OutputText = (dateAndTime, "Critical", textBody);
            Appender.Append();
        }

        public void Error(string dateAndTime, string textBody)
        {
            Appender.OutputText = (dateAndTime, "Error", textBody);
            Appender.Append();
        }

        public void Fatal(string dateAndTime, string textBody)
        {
            Appender.OutputText = (dateAndTime, "Fatal", textBody);
            Appender.Append();
        }

        public void Info(string dateAndTime, string textBody)
        {
            Appender.OutputText = (dateAndTime, "Info", textBody);
            Appender.Append();
        }

        public void Warning(string dateAndTime, string textBody)
        {
            Appender.OutputText = (dateAndTime, "Warning", textBody);
            Appender.Append();
        }
    }
}