using CustomLogger.Appenders.Interfaces;
using CustomLogger.Layouts.Interfaces;
using CustomLogger.Misc;
using System;
using System.IO;

namespace CustomLogger.Appenders.Models
{
    public class FileAppender : IAppender
    {
        private string path;
        private string separator = System.IO.Path.DirectorySeparatorChar.ToString();

        public FileAppender(ILayout layout)
        {
            Layout = layout;
            path = string.Format("Misc{0}log.txt", separator);
            ReportLevel = ReportLevel.Info;
            LogFile = new LogFile();
        }

        public ILayout Layout { get; }
        public ILogFile LogFile { get; set; }
        public int MessagesAppended { get; set; }
        public (string date, ReportLevel msgType, string text) OutputText { get; set; }

        public string Path
        {
            get => path;
            set { path = value; }
        }

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
            File.AppendAllText(Path, LogFile.Log.ToString());
        }
    }
}