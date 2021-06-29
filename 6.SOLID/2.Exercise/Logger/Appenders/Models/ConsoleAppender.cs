using CustomLogger.Appenders.Interfaces;
using CustomLogger.Layouts.Interfaces;
using CustomLogger.Misc;
using System;

namespace CustomLogger.Appenders.Models
{
    public class ConsoleAppender : IAppender
    {
        public ConsoleAppender(ILayout layout)
        {
            Layout = layout;
            LogFile = new LogFile();
        }

        public ILayout Layout { get; }
        public ILogFile LogFile { get; set; }
        public int MessagesAppended { get; set; }
        public (string date, ReportLevel msgType, string text) OutputText { get; set; }
        public ReportLevel ReportLevel { get; set; }

        public void Append()
        {
            if (OutputText.msgType >= ReportLevel)
            {
                LogFile.Write(string.Format(Layout.LayoutFormat, OutputText.date, OutputText.msgType, OutputText.text));
                MessagesAppended++;
            }
        }

        public void DumpLoggedData()
        {
            Console.Write(LogFile.Log);
        }
    }
}