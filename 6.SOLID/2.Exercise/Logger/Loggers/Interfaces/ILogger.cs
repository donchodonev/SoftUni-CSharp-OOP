using CustomLogger.Appenders.Interfaces;

namespace CustomLogger.Loggers.Interfaces
{
    public interface ILogger
    {
        public IAppender[] Appenders { get; }

        public void Critical(string dateAndTime, string textBody);

        public void DisplayLoggerInfo();

        public void DumpCollectedData();

        public void Error(string dateAndTime, string textBody);

        public void Fatal(string dateAndTime, string textBody);

        public void Info(string dateAndTime, string textBody);

        public void Warning(string dateAndTime, string textBody);
    }
}