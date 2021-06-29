using CustomLogger.Appenders.Interfaces;
using CustomLogger.Engine.Factories;
using CustomLogger.Layouts.Interfaces;
using CustomLogger.Loggers.Interfaces;
using CustomLogger.Loggers.Models;
using CustomLogger.Misc;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomLogger.Engine.Interfaces
{
    public abstract class ICommander
    {
        private List<IAppender> appenders;
        private string appenderType;
        private string layoutType;
        private ILogger logger;
        private ReportLevel reportLevel;
        private int NumberOfAppenders => int.Parse(Console.ReadLine());

        public virtual void Run()
        {
            for (int i = 0; i < NumberOfAppenders; i++)
            {
                ReadAppenderData();
                CreateAppender();
            }
        }

        private void CreateAppender()
        {
            AppenderFactory appenderFactory = new AppenderFactory(layoutType, appenderType, reportLevel);

            appenders.Add(appenderFactory.GetAppender());
        }

        private void CreateLogger()
        {
            logger = new Logger();
        }

        private void ReadAppenderData()
        {
            string[] inputArgs = Console.ReadLine()
                 .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            this.appenderType = inputArgs[0];
            this.layoutType = inputArgs[1];

            if (inputArgs.Length == 3)
            {
                this.reportLevel = (ReportLevel)Enum.Parse(typeof(ReportLevel), inputArgs[2], true);
            }
            else
            {
                this.reportLevel = ReportLevel.Info;
            }
        }
    }
}