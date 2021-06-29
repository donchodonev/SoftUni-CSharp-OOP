using CustomLogger.Misc;
using CustomLogger.Appenders.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomLogger.Loggers.Interfaces
{
    public interface ILogger
    {
        public IAppender[] Appenders { get; }

        public void Critical(string dateAndTime, string textBody);

        public void Error(string dateAndTime, string textBody);

        public void Fatal(string dateAndTime, string textBody);

        public void Info(string dateAndTime, string textBody);

        public void Warning(string dateAndTime, string textBody);
    }
}