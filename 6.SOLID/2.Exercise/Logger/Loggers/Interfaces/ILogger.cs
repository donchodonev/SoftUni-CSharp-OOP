using Logger.Appenders.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logger.Loggers.Interfaces
{
    public interface ILogger
    {
        public IAppender Appender { get; }

        public void Critical(string dateAndTime, string textBody);

        public void Error(string dateAndTime, string textBody);

        public void Fatal(string dateAndTime, string textBody);

        public void Info(string dateAndTime, string textBody);

        public void Warning(string dateAndTime, string textBody);
    }
}