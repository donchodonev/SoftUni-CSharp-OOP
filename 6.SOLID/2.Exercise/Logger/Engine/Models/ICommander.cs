using CustomLogger.Appenders.Interfaces;
using CustomLogger.Engine.Factories;
using CustomLogger.Loggers.Interfaces;
using CustomLogger.Loggers.Models;
using CustomLogger.LogParser.Interfaces;
using CustomLogger.Misc;
using System;
using System.Collections.Generic;

namespace CustomLogger.Engine.Interfaces
{
    public abstract class ICommander
    {
        protected List<IAppender> Appenders { get; set; } = new List<IAppender>();
        protected string AppenderType { get; set; }
        protected string LayoutType { get; set; }
        protected ILogger Logger { get; set; }
        protected int NumberOfAppenders { get; set; }
        protected ReportLevel ReportLevel { get; set; }

        public virtual void Run()
        {
            NumberOfAppenders = int.Parse(Console.ReadLine());

            for (int i = 0; i < NumberOfAppenders; i++)
            {
                ReadAppenderData();
                CreateAppender();
            }

            CreateLogger();
            StartLogging();
        }

        protected virtual void CreateAppender()
        {
            AppenderFactory appenderFactory = new AppenderFactory(LayoutType, AppenderType, ReportLevel);

            Appenders.Add(appenderFactory.GetAppender());
        }

        protected virtual void CreateLogger()
        {
            Logger = new Logger(Appenders.ToArray());
        }

        protected virtual void ReadAppenderData()
        {
            string[] inputArgs = Console.ReadLine()
                 .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            AppenderType = inputArgs[0];
            LayoutType = inputArgs[1];

            if (inputArgs.Length == 3)
            {
                ReportLevel = (ReportLevel)Enum.Parse(typeof(ReportLevel), inputArgs[2], true);
            }
            else
            {
                ReportLevel = ReportLevel.Info;
            }
        }

        protected void StartLogging()
        {
            ILogParser parser = new LogParser.Models.LogParser();

            parser.Parse();

            while (!parser.IsDone())
            {
                switch (parser.Severity)
                {
                    case "INFO":
                        Logger.Info(parser.DateAndTime, parser.Message);
                        break;

                    case "WARNING":
                        Logger.Warning(parser.DateAndTime, parser.Message);
                        break;

                    case "ERROR":
                        Logger.Error(parser.DateAndTime, parser.Message);
                        break;

                    case "CRITICAL":
                        Logger.Critical(parser.DateAndTime, parser.Message);
                        break;

                    case "FATAL":
                        Logger.Fatal(parser.DateAndTime, parser.Message);
                        break;
                }

                parser.Parse();
            }
        }
    }
}