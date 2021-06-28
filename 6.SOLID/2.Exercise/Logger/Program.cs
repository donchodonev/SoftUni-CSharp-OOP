using CustomLogger.Appenders.Models;
using Logger.Appenders.Interfaces;
using Logger.Appenders.Models;
using Logger.Layouts.Interfaces;
using Logger.Layouts.Models;
using Logger.Loggers.Interfaces;
using Logger.Loggers.Models;
using System;

namespace CustomLogger
{
    public class Program
    {
        public static void Main(string[] args)
        {
            ILayout simpleLayout = new SimpleLayout();
            IAppender consoleAppender =
            new ConsoleAppender(simpleLayout);
            IAppender fileAppender =
            new FileAppender(simpleLayout);
            ILogger logger = new MyLogger(consoleAppender);

            consoleAppender.ReportLevel = Misc.ReportLevel.Critical;

            logger.Error("3/26/2015 2:08:11 PM", "Error parsing JSON.");
            logger.Info("3/26/2015 2:08:11 PM", "User Pesho successfully registered.");
        }
    }
}