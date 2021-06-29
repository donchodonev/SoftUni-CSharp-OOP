using CustomLogger.Appenders.Models;
using CustomLogger.Engine.Models;
using CustomLogger.Appenders.Interfaces;
using CustomLogger.Layouts.Interfaces;
using CustomLogger.Layouts.Models;
using CustomLogger.Loggers.Interfaces;
using CustomLogger.Loggers.Models;
using CustomLogger.Misc;
using System;
using CustomLogger.Engine.Interfaces;

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
            ILogger logger = new Logger(consoleAppender, fileAppender);

            consoleAppender.ReportLevel = Misc.ReportLevel.Info;

            logger.Error("3/26/2015 2:08:11 PM", "Error parsing JSON.");
            logger.Info("3/26/2015 2:08:11 PM", "User Pesho successfully registered.");

            ICommander commander = new BaseCommander();
        }
    }
}