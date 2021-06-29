using CustomLogger.Appenders.Interfaces;

namespace CustomLogger.Loggers.Models
{
    public class Logger : BaseLogger
    {
        public Logger(params BaseAppender[] appenders)
            : base(appenders)
        {
        }
    }
}